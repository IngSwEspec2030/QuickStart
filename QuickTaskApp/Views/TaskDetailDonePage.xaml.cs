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
    public partial class TaskDetailDonePage : ContentPage
    {
        public TaskDetailDonePage(IEnumerable<TaskSend> lista)
        {
            InitializeComponent();
            MyListView.ItemsSource = lista;
        }
    }
}