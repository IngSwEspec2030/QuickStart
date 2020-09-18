using QuickTaskApp.Models;
using QuickTaskApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QuickTaskApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignupPage : ContentPage
    {
        Usuario usuario = new Usuario();
        public SignupPage()
        {
            BindingContext = usuario;
            InitializeComponent();
        }

        private async void Signup_Clicked(object sender, EventArgs e)
        {
            JavaService javaService = new JavaService();
            usuario = BindingContext as Usuario;
            Usuario result = await javaService.CreateUser(usuario);

            if(result == null)
            {
                await DisplayAlert("Error", "Usuario o contraseña errada", "OK");
            }
            else if (result.isusuariovalido == true)
            {
                await Navigation.PushModalAsync(new NavigationPage(new WelcomePage(result)));
            }
            else
            {
                await DisplayAlert("Error", "Usuario o contraseña errada", "OK");
            }
        }
        private async void Login_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}