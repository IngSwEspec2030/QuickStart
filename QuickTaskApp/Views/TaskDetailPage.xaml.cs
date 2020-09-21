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
    public partial class TaskDetailPage : ContentPage
    {
        private Usuario user;
        public TaskDetailPage(Models.Task task, Usuario usuario)
        {
            user = usuario;
            InitializeComponent();
            BindingContext = task;
        }
        //async private void CreateButton_Clicked(object sender, EventArgs e)
        //{
        //    await Navigation.PushModalAsync(new NavigationPage(new TaskPage()));
        //}

        private async void BtnTomar_Clicked(object sender, EventArgs e)
        {
            Models.Task task = BindingContext as Models.Task;
            await Navigation.PushModalAsync(new NavigationPage(new TaskTakePage(task, user)) { BarBackgroundColor = Color.FromHex("#D2D2D2"), BarTextColor = Color.White, Title = "Tarea" });
        }

        async private void BtnLiked_Clicked(object sender, EventArgs e)
        {
            JavaService javaService = new JavaService();
            Models.Task task = BindingContext as Models.Task;
            var result = await javaService.LikedTask(task.Id, user.idUsuario);
            if (result == true)
            {
                await DisplayAlert("Succes", "Tarea agregada", "OK");
                await Navigation.PushModalAsync(new NavigationPage(new TaskListPage(user, EnumUsuarios.estadosTarea.MeGusta)));

            }
            else
            {
                await DisplayAlert("Error", "Ya está la tarea guardada como favorita", "OK");
            }
        }
    }
}