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
        public TaskPage()
        {
            InitializeComponent();
        }

        async private void Save_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NavigationPage(new TaskDetailPage()) { BarBackgroundColor = Color.FromHex("#D2D2D2"), BarTextColor = Color.White, Title = "Detalle Tarea"});
        }
    }
}