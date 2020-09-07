using Microsoft.Azure.Management.ContainerRegistry.Fluent.Models;
using Microsoft.Rest;
using QuickTaskApp.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickTaskApp.ViewModels
{
    public class TaskViewModel: BaseViewModel
    {
        private readonly JavaService javaService;
        private int id;
        private int idUsuario;
        private string text;
        private string description;
        private string price;
        private string quantity;
        private string saldo;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int IdUsuario
        {
            get { return idUsuario; }
            set { idUsuario = value; }
        }
        public string Text 
        {
            get { return text; }
            set { text = value; }
        }

        public string Description 
        {
            get { return description; }
            set { description = value; }
        }

        public string Price
        {
            get { return price; }
            set { price = value; }
        }

        public string Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public string Saldo 
        {
            get { return saldo; }
            set { saldo = value; }
        }
    }
}
