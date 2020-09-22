using Newtonsoft.Json;
using QuickTaskApp.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace QuickTaskApp.Services
{
    public class JavaService
    {
        IEnumerable<Models.Task> tasks;
        bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;
        private HttpClient client;

        public JavaService()
        {
            //client = new HttpClient();
            //client.BaseAddress = new Uri($"{App.AWSBackednUrl}/");
            tasks = new List<Models.Task>();
        }

        public async Task<IEnumerable<Models.Task>> GetTaskAsync(bool forceRefresh = false)
        {
            try
            {
                if (forceRefresh && IsConnected)
                {
                    var url = "http://ec2-18-219-163-1.us-east-2.compute.amazonaws.com:8080/api/quicktask/tarea";
                    client = new HttpClient();
                    var response = await client.GetAsync(url);
                    var json = await response.Content.ReadAsStringAsync();
                    //return JsonConvert.DeserializeObject<Item>(json);vert.DeserializeObject<IEnumerable<Item>>(json));
                    tasks = await System.Threading.Tasks.Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Models.Task>>(json));
                }

                return tasks;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Models.Task>> GetDoneTaskAsync(int idUsuario, string Estado)
        {
            try
            {
                
                var url = "http://ec2-18-219-163-1.us-east-2.compute.amazonaws.com:8080/api/quicktask/tarea?usuario=" + idUsuario + "&estado=" + Estado;
                client = new HttpClient();
                var response = await client.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();
                    //return JsonConvert.DeserializeObject<Item>(json);vert.DeserializeObject<IEnumerable<Item>>(json));
                tasks = await System.Threading.Tasks.Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Models.Task>>(json));

                return tasks;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Models.Task>> GetTaskXUserAsync(int idUsuario)
        {
            try
            {

                var url = "http://ec2-18-219-163-1.us-east-2.compute.amazonaws.com:8080/api/quicktask/tarea?usuario=" + idUsuario;
                client = new HttpClient();
                var response = await client.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();
                //return JsonConvert.DeserializeObject<Item>(json);vert.DeserializeObject<IEnumerable<Item>>(json));
                tasks = await System.Threading.Tasks.Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Models.Task>>(json));

                return tasks;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<TaskSend>> GetTaskDetails(int idTarea)
        {
            try
            {
                IEnumerable<TaskSend> sendTask;
                var url = "http://ec2-18-219-163-1.us-east-2.compute.amazonaws.com:8080/api/quicktask/tarea/detalle?tarea=" + idTarea;
                client = new HttpClient();
                var response = await client.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();
                //return JsonConvert.DeserializeObject<Item>(json);vert.DeserializeObject<IEnumerable<Item>>(json));
                sendTask = await System.Threading.Tasks.Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<TaskSend>>(json));

                return sendTask;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> CreateTask(Models.Task task)
        {
            try
            {
                client = new HttpClient();
                if (task == null || !IsConnected)
                    return false;
                var json = JsonConvert.SerializeObject(task);
                var stringContent = new StringContent(json,
                                UnicodeEncoding.UTF8,
                                "application/json");
                var url = "http://ec2-18-219-163-1.us-east-2.compute.amazonaws.com:8080/api/quicktask/tarea";
                var response = await client.PostAsync(url, stringContent);
                return response.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> SendTask(TaskSend task)
        {
            try
            {
                client = new HttpClient();
                var json = JsonConvert.SerializeObject(task);
                var stringContent = new StringContent(json,
                                UnicodeEncoding.UTF8,
                                "application/json");
                var url = "http://ec2-18-219-163-1.us-east-2.compute.amazonaws.com:8080/api/quicktask/tarea/entrega";
                var response = await client.PostAsync(url, stringContent);
                var resultado = response.StatusCode;
                if (resultado == HttpStatusCode.Created)
                    return true;
                else
                    return false;


            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> LikedTask(int idTarea, int idusuario)
        {
            try
            {
                client = new HttpClient();
                //if (correousuario == null || passwordusuario == null)
                //    return ;
                var data = new { idtarea = idTarea, idusuario = idusuario };
                var json = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(json,
                                UnicodeEncoding.UTF8,
                                "application/json");
                var url = "http://ec2-18-219-163-1.us-east-2.compute.amazonaws.com:8080/api/quicktask/tarea/favorita";
                var response = await client.PostAsync(url, stringContent);
                var resultado = response.StatusCode;
                if (resultado == HttpStatusCode.Created)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<Usuario> CreateUser(Usuario usuario)
        {
            try
            {
                client = new HttpClient();
                if (usuario == null || !IsConnected)
                    return null;
                var json = JsonConvert.SerializeObject(usuario);
                var stringContent = new StringContent(json,
                                UnicodeEncoding.UTF8,
                                "application/json");
                var url = "http://ec2-18-219-163-1.us-east-2.compute.amazonaws.com:8081/api/quicktask/usuario";
                var response = await client.PostAsync(url, stringContent);
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
                    client = new HttpClient();
                    //if (correousuario == null || passwordusuario == null)
                    //    return ;
                    var data = new { correousuario = correousuario, passwordusuario = passwordusuario };
                    var json = JsonConvert.SerializeObject(data);
                    var stringContent = new StringContent(json,
                                    UnicodeEncoding.UTF8,
                                    "application/json");
                    var url = "http://ec2-18-219-163-1.us-east-2.compute.amazonaws.com:8081/api/quicktask/usuario/validate";
                    var response = await client.PostAsync(url, stringContent);
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
