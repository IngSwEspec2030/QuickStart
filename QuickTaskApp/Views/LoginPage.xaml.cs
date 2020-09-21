using QuickTaskApp.Models;
using QuickTaskApp.Services;
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
                JavaService javaService = new JavaService();
                usuario = BindingContext as Usuario;
                Usuario result = await javaService.ValidateUser(usuario.correousuario, usuario.passwordusuario);
                
                if (result.isusuariovalido == true)
                {
                    await Navigation.PushModalAsync(new NavigationPage(new WelcomePage(result)));
                }
                else
                {
                    await DisplayAlert("Error", "Usuario o contraseña errada", "OK");
                }                
                
            }
            catch (Exception ex)
            {
                var mensaje = "Error message: " + ex.Message;
                //Log(mensaje);
            }

        }
    }
}