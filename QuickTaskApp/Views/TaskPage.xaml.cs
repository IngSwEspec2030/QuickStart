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
    public partial class TaskPage : ContentPage
    {
        Item item = new Item();

        public TaskPage()
        {
            InitializeComponent();
            BindingContext = item;
        }

        async private void Save_Clicked(object sender, EventArgs e)
        {
            JavaService javaService = new JavaService();
            item = BindingContext as Item;
            item.Saldo = item.Quantity;
            item.IdUsuario = (int)Application.Current.Properties["id"];
            item.Text = Application.Current.Properties["name"].ToString();
            var result = await javaService.CreateItem(item);
            await Navigation.PushAsync(new NavigationPage(new TaskDetailPage(item)) { BarBackgroundColor = Color.FromHex("#D2D2D2"), BarTextColor = Color.White, Title = "Detalle Tarea" });
        }
    }
}