using QuickTaskApp.Models;
using QuickTaskApp.Views._views;
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
    public partial class ProfilePage : ContentPage
    {
        private Usuario user;
        public ProfilePage(Usuario usuario)
        {
            user = usuario;
            InitializeComponent();
            
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)
            {
                ((ListView)sender).SelectedItem = null;
                if (e.Item == "Medios de pago")
                    await Navigation.PushModalAsync(new NavigationPage(new MyCardsPage()));
                if (e.Item == "Tareas creadas")
                   await Navigation.PushModalAsync(new NavigationPage(new TaskListPage(user, EnumUsuarios.estadosTarea.MisTareas)));
                if (e.Item == "Tareas tomadas")
                    await Navigation.PushModalAsync(new NavigationPage(new TaskListPage(user, EnumUsuarios.estadosTarea.Realizadas)));
                if (e.Item == "Salir")
                    await Navigation.PopModalAsync();
            }
        }
    }
}