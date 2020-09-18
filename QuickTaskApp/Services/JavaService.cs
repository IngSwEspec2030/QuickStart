using Newtonsoft.Json;
using QuickTaskApp.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace QuickTaskApp.Services
{
    public class JavaService
    {
        IEnumerable<Item> items;
        bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;

        public JavaService()
        {
            //client = new HttpClient();
            //client.BaseAddress = new Uri($"{App.AWSBackednUrl}/");
            items = new List<Item>();
        }

        public async Task<IEnumerable<Item>> GetTaskAsync(bool forceRefresh = false)
        {
            try
            {
                if (forceRefresh && IsConnected)
                {
                    var url = "http://ec2-18-219-163-1.us-east-2.compute.amazonaws.com:8080/api/quicktask/tarea";
                    HttpClient client = new HttpClient();
                    var response = await client.GetAsync(url);
                    var json = await response.Content.ReadAsStringAsync();
                    //return JsonConvert.DeserializeObject<Item>(json);vert.DeserializeObject<IEnumerable<Item>>(json));
                    items = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Item>>(json));
                }

                return items;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> CreateItem(Item item)
        {
            try
            {
                HttpClient cliente = new HttpClient();
                if (item == null || !IsConnected)
                    return false;
                var json = JsonConvert.SerializeObject(item);
                var stringContent = new StringContent(json,
                                UnicodeEncoding.UTF8,
                                "application/json");
                var url = "http://ec2-18-219-163-1.us-east-2.compute.amazonaws.com:8080/api/quicktask/tarea";
                var response = await cliente.PostAsync(url, stringContent);
                return response.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Usuario> CreateUser(Usuario usuario)
        {
            try
            {
                HttpClient cliente = new HttpClient();
                if (usuario == null || !IsConnected)
                    return null;
                var json = JsonConvert.SerializeObject(usuario);
                var stringContent = new StringContent(json,
                                UnicodeEncoding.UTF8,
                                "application/json");
                var url = "http://ec2-18-219-163-1.us-east-2.compute.amazonaws.com:8081/api/quicktask/usuario";
                var response = await cliente.PostAsync(url, stringContent);
                var usuarioDes = JsonConvert.DeserializeObject<Usuario>(response.Content.ReadAsStringAsync().Result);

                return usuarioDes;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Usuario> ValidateUser(string correousuario, string passwordusuario)
        {
                try
                {
                    HttpClient cliente = new HttpClient();
                    //if (correousuario == null || passwordusuario == null)
                    //    return ;
                    var data = new { correousuario = correousuario, passwordusuario = passwordusuario };
                    var json = JsonConvert.SerializeObject(data);
                    var stringContent = new StringContent(json,
                                    UnicodeEncoding.UTF8,
                                    "application/json");
                    var url = "http://ec2-18-219-163-1.us-east-2.compute.amazonaws.com:8081/api/quicktask/usuario/validate";
                    var response = await cliente.PostAsync(url, stringContent);
                    var usuarioDes = JsonConvert.DeserializeObject<Usuario>(response.Content.ReadAsStringAsync().Result);
                    
                    return usuarioDes;
                }
                catch (Exception e)
                {
                    return null;
                }
        }
    }
}
