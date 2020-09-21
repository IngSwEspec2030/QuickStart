using QuickTaskApp.Models;
using QuickTaskApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QuickTaskApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TaskListPage : ContentPage
    {
        public ObservableCollection<Models.Task> Tasks { get; set; }
        private Usuario usuario;
        private EnumUsuarios.estadosTarea estadoTarea;
        public TaskListPage(Usuario user, EnumUsuarios.estadosTarea estado)
        {
            estadoTarea = estado;
            usuario = user;
            InitializeComponent();
            if (estado == EnumUsuarios.estadosTarea.MeGusta)
            {
                buscar.Source = "BuscarOff.PNG";
                realizadas.Source = "Realizadas.PNG";
                guardadas.Source = "GuardadasOn.PNG";
            }
            else if (estado == EnumUsuarios.estadosTarea.Realizadas)
            {
                buscar.Source = "BuscarOff.PNG";
                realizadas.Source = "RealizadasOn.PNG";
                guardadas.Source = "Guardadas.PNG";

            }
            else if (estado == EnumUsuarios.estadosTarea.Todas)
            {
                buscar.Source = "Buscar.PNG";
                realizadas.Source = "Realizadas.PNG";
                guardadas.Source = "Guardadas.PNG";

            }

            //Items = new ObservableCollection<Item>();
            //Items.Add(new Item { Id = 1, Description = "Lorem ipsum dolor sit amet consectetur adipiscing, elit sapien primis mi inceptos porta massa, accumsan risus leo conubia curae. Ac porta velit vitae porttitor pharetra scelerisque hac, curae nisi felis cras ridiculus facilisis tempus, nec etiam laoreet vivamus rutrum elementum. ", Price = "$ 2.500", Quantity = "requiere: 3", Text = "Diego Goméz" });
            //Items.Add(new Item { Id = 2, Description = "Lorem ipsum dolor sit amet consectetur adipiscing, elit sapien primis mi inceptos porta massa, accumsan risus leo conubia curae. Ac porta velit vitae porttitor pharetra scelerisque hac, curae nisi felis cras ridiculus facilisis tempus, nec etiam laoreet vivamus rutrum elementum. ", Price = "$ 5.000", Quantity = "requiere: 3", Text = "Lorena Hernández" });


            //MyListView.ItemsSource = Items;
        }

        protected override async void OnAppearing()
        {
            
            base.OnAppearing();
            IEnumerable<Models.Task> result = null;
            JavaService javaService = new JavaService();
            if (estadoTarea == EnumUsuarios.estadosTarea.Todas)
            {
                result = await javaService.GetTaskAsync(true);
            }
            else if (estadoTarea == EnumUsuarios.estadosTarea.Realizadas)
            {
                result = await javaService.GetDoneTaskAsync(usuario.idUsuario, "ENTREGADA");
            }
            else
            {
                result = await javaService.GetDoneTaskAsync(usuario.idUsuario, "FAVORITA");
            }
            MyListView.ItemsSource = result;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)
            {
                ((ListView)sender).SelectedItem = null;
                Models.Task task = (Models.Task)e.Item;
                await Navigation.PushModalAsync(new NavigationPage(new TaskDetailPage(task, usuario)) { BarBackgroundColor = Color.FromHex("#D2D2D2"), BarTextColor = Color.White, Title = "Detalle Tarea" });
            }
        }

        async private void CreateButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new TaskPage(usuario)));
        }

        async private void GetRealizadas_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new TaskListPage(usuario, EnumUsuarios.estadosTarea.Realizadas));
        }

        async private void LikedTask_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new TaskListPage(usuario, EnumUsuarios.estadosTarea.MeGusta));
        }

        async private void AllTasks_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new TaskListPage(usuario, EnumUsuarios.estadosTarea.Todas));
        }
    }
}
