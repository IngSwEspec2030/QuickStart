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
        HttpClient client;
        IEnumerable<Item> items;
        bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;

        public JavaService()
        {
            //client = new HttpClient();
            //client.BaseAddress = new Uri($"{App.AWSBackednUrl}/");
            items = new List<Item>();
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            if (forceRefresh && IsConnected)
            {
                var url = "http://ec2-18-219-163-1.us-east-2.compute.amazonaws.com:8080/api/tarea/";
                HttpClient client = new HttpClient();
                var response = await client.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();
                //return JsonConvert.DeserializeObject<Item>(json);vert.DeserializeObject<IEnumerable<Item>>(json));
                items = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Item>>(json));
            }

            return items;
        }
    }
}
