//using Plugin.Media;
//using Plugin.Media.Abstractions;
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
    public partial class TaskTakePage : ContentPage
    {
        //private MediaFile _mediaFile;

        public TaskTakePage(Item item)
        {
            InitializeComponent();
        }

        private void BtnSubirfoto_Clicked(object sender, EventArgs e)
        {

        }

        private void BtnTomarFoto_Clicked(object sender, EventArgs e)
        {
            //await CrossMedia.Current.Initialize();
            //if (!CrossMedia.Current.IsPickPhotoSupported)
            //{
            //    await DisplayAlert("No hay foto", "No se encontró la foto", "OK");
            //    return;
            //}

            //_mediaFile = await CrossMedia.Current.PickPhotoAsync();

            //if (_mediaFile == null)
            //    return;
            //LocalPath.Text = _mediaFile.Path;
            //FileImage.Source = ImageSource.FromStream(() =>
            //{
            //    return _mediaFile.GetStream();
            //});
        }
    }
}