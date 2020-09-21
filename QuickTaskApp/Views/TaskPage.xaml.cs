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
        Models.Task task = new Models.Task();
        Usuario usuario;
        public TaskPage(Usuario user)
        {
            usuario = user;
            InitializeComponent();
            BindingContext = task;
        }

        async private void Save_Clicked(object sender, EventArgs e)
        {
            JavaService javaService = new JavaService();
            task = BindingContext as Models.Task;
            task.Saldo = task.Quantity;
            task.IdUsuario = usuario.idUsuario;
            task.Text = usuario.nombreusuario;
            task.fechavencimiento = FechaVencimiento.Date;
            var result = await javaService.CreateTask(task);
            await Navigation.PushAsync(new NavigationPage(new TaskDetailPage(task, usuario)) { BarBackgroundColor = Color.FromHex("#D2D2D2"), BarTextColor = Color.White, Title = "Detalle Tarea" });
        }
    }
}