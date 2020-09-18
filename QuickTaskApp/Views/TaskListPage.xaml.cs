using QuickTaskApp.Models;
using QuickTaskApp.Services;
using System;
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
        public ObservableCollection<Item> Items { get; set; }
        private Usuario usuario;
        public TaskListPage(Usuario user)
        {
            usuario = user;
            InitializeComponent();

            //Items = new ObservableCollection<Item>();
            //Items.Add(new Item { Id = 1, Description = "Lorem ipsum dolor sit amet consectetur adipiscing, elit sapien primis mi inceptos porta massa, accumsan risus leo conubia curae. Ac porta velit vitae porttitor pharetra scelerisque hac, curae nisi felis cras ridiculus facilisis tempus, nec etiam laoreet vivamus rutrum elementum. ", Price = "$ 2.500", Quantity = "requiere: 3", Text = "Diego Goméz" });
            //Items.Add(new Item { Id = 2, Description = "Lorem ipsum dolor sit amet consectetur adipiscing, elit sapien primis mi inceptos porta massa, accumsan risus leo conubia curae. Ac porta velit vitae porttitor pharetra scelerisque hac, curae nisi felis cras ridiculus facilisis tempus, nec etiam laoreet vivamus rutrum elementum. ", Price = "$ 5.000", Quantity = "requiere: 3", Text = "Lorena Hernández" });


            //MyListView.ItemsSource = Items;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            JavaService javaService = new JavaService();
            var result = await javaService.GetTaskAsync(true);
            MyListView.ItemsSource = result;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)
            {
                ((ListView)sender).SelectedItem = null;
                Item item = (Item)e.Item;
                await Navigation.PushAsync(new NavigationPage(new TaskDetailPage(item)) { BarBackgroundColor = Color.FromHex("#D2D2D2"), BarTextColor = Color.White, Title = "Detalle Tarea" });
            }
        }

        async private void CreateButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new TaskPage(usuario)));
        }
    }
}
