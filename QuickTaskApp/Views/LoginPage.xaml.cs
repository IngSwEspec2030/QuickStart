﻿using QuickTaskApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace QuickTaskApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        Usuario usuario = new Usuario();
        public LoginPage()
        {
            BindingContext = usuario;
            InitializeComponent();
        }

        private async void Signup_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new SignupPage()));
        }

        private async void Start_Clicked(object sender, EventArgs e)
        {
            try
            {
                usuario = BindingContext as Usuario;
                if (usuario.Correo.Equals("alejandro.nino@gmail.com"))
                {
                    Application.Current.Properties["id"] = EnumUsuarios.Usuarios.Alejandro;
                    Application.Current.Properties["name"] = "Alejandro Niño";
                }

                if (usuario.Correo.Equals("chcindyl3@gmail.com"))
                {
                    Application.Current.Properties["id"] = EnumUsuarios.Usuarios.Lorena;
                    Application.Current.Properties["name"] = "Lorena Hernández";
                }

                if (usuario.Correo.Equals("yuancamo@gmail.com"))
                {
                    Application.Current.Properties["id"] = EnumUsuarios.Usuarios.Yuri;
                    Application.Current.Properties["name"] = "Yuri Carrillo";
                }

                if (usuario.Correo.Equals("diego.gomez@tuproyecto.com"))
                {
                    Application.Current.Properties["id"] = EnumUsuarios.Usuarios.Diego;
                    Application.Current.Properties["name"] = "Diego Gómez";
                }

                await Navigation.PushModalAsync(new NavigationPage(new WelcomePage()));
            }
            catch (Exception ex)
            {
                var mensaje = "Error message: " + ex.Message;
                //Log(mensaje);
            }

        }
    }
}