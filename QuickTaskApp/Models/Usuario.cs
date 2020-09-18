using System;
using System.Collections.Generic;
using System.Text;

namespace QuickTaskApp.Models
{
    public class Usuario
    {
        public int idUsuario { get; set; }
        public string nombreusuario { get; set; }
        public string correousuario { get; set; }
        public string passwordusuario { get; set; }
        public bool isusuariovalido { get; set; }
    }
}
