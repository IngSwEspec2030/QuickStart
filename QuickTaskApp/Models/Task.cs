using Newtonsoft.Json;
using System;

namespace QuickTaskApp.Models
{
    public class Task
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
        public DateTime fechavencimiento { get; set; }
    }

    public class TaskSend 
    {
        public int idtarea { get; set; }
        public int idusuario { get; set; }
        public string urladjunto { get; set; }
        public string descripcion { get; set; }
    }
}