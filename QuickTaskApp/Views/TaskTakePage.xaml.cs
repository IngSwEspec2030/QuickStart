using Plugin.Media;
using Plugin.Media.Abstractions;
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
        private MediaFile _mediaFile;

        public TaskTakePage(Item item)
        {
            BindingContext = item;
            InitializeComponent();
        }

        private async void BtnTomarFoto_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No camera", "No camera avaiable", "OK");
                return;
            }
            _mediaFile = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Test",
                SaveToAlbum = true,
                CompressionQuality = 75,
                CustomPhotoSize = 50,
                PhotoSize = PhotoSize.MaxWidthHeight,
                MaxWidthHeight = 2000
            });

            if (_mediaFile == null)
                return;

            DisplayAlert("File Location", _mediaFile.Path, "OK");

            FileImage.Source = ImageSource.FromStream(() =>
            {
                var stream = _mediaFile.GetStream();
                _mediaFile.Dispose();
                return stream;
            });
        }

        private async void BtnSubirfoto_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("No hay foto", "No se encontró la foto", "OK");
                return;
            }

            _mediaFile = await CrossMedia.Current.PickPhotoAsync();

            if (_mediaFile == null)
                return;
            LocalPath.Text = _mediaFile.Path;
            FileImage.Source = ImageSource.FromStream(() =>
            {
                return _mediaFile.GetStream();
            });
        }
    }
}