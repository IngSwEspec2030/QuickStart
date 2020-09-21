using QuickTaskApp.Models;
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
    public partial class WelcomePage : ContentPage
    {
        private Usuario usuario;
        public WelcomePage(Usuario user)
        {
            usuario = user;
            InitializeComponent();
        }

        private async void Tasklist_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new TaskListPage(usuario, EnumUsuarios.estadosTarea.Todas)));
        }
    }
}