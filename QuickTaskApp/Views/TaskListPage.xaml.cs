using QuickTaskApp.Models;
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

        public TaskListPage()
        {
            InitializeComponent();

            Items = new ObservableCollection<Item>();
            Items.Add(new Item { Id = 1, Description = "Lorem ipsum dolor sit amet consectetur adipiscing, elit sapien primis mi inceptos porta massa, accumsan risus leo conubia curae. Ac porta velit vitae porttitor pharetra scelerisque hac, curae nisi felis cras ridiculus facilisis tempus, nec etiam laoreet vivamus rutrum elementum. ", Price = "$ 2.500", Quantity = "requiere: 3", Text = "Diego Goméz" });
            Items.Add(new Item { Id = 2, Description = "Lorem ipsum dolor sit amet consectetur adipiscing, elit sapien primis mi inceptos porta massa, accumsan risus leo conubia curae. Ac porta velit vitae porttitor pharetra scelerisque hac, curae nisi felis cras ridiculus facilisis tempus, nec etiam laoreet vivamus rutrum elementum. ", Price = "$ 5.000", Quantity = "requiere: 3", Text = "Lorena Hernández" });


            MyListView.ItemsSource = Items;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        async private void CreateButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new TaskPage()));
        }
    }
}
