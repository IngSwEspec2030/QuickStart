using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickTaskApp.Models
{
    public class Result
    {
        [JsonProperty(PropertyName = "result")]
        public Item ItemResult { get; set; }
    }
}
