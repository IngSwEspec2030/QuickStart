using System;
using System.Collections.Generic;
using System.Text;

namespace QuickTaskApp.Models
{
    public class Response
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public object DataResulr { get; set; }
    }
}
