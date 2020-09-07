using Newtonsoft.Json;
using System;

namespace QuickTaskApp.Models
{
    public class Item
    {
        [JsonProperty(PropertyName = "idtarea")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "idusuario")]
        public int IdUsuario { get; set; }
        [JsonProperty(PropertyName = "nombreUsuario")]
        public string Text { get; set; }
        [JsonProperty(PropertyName = "desctarea")]
        public string Description { get; set; }
        //public string ImageUrl { get; set; }
        [JsonProperty(PropertyName = "preciounidadtarea")]
        public string Price { get; set; }
        [JsonProperty(PropertyName = "unidadestarea")]
        public string Quantity { get; set; }
        [JsonProperty(PropertyName = "saldounidadestarea")]
        public string Saldo { get; set; }
        public string condtarea { get; set; }

    }
}