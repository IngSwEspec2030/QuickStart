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
    public partial class TaskDetailPage : ContentPage
    {
        public TaskDetailPage(Item item)
        {
            InitializeComponent();
            BindingContext = item;
        }
        //async private void CreateButton_Clicked(object sender, EventArgs e)
        //{
        //    await Navigation.PushModalAsync(new NavigationPage(new TaskPage()));
        //}

        private async void BtnTomar_Clicked(object sender, EventArgs e)
        {
            Item item = BindingContext as Item;
            await Navigation.PushModalAsync(new NavigationPage(new TaskTakePage(item)) { BarBackgroundColor = Color.FromHex("#D2D2D2"), BarTextColor = Color.White, Title = "Tarea" });
        }
    }
}