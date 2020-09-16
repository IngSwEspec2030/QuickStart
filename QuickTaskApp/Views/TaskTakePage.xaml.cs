using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Plugin.Media;
using Plugin.Media.Abstractions;
using QuickTaskApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
        private static string PutAWSAccessKey = "AKIAIGDCUCVJ6JHKEYXA";
        private static string PutAWSSecretKey= "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";
        private Stream stream;

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

            await AWSUploadPic(_mediaFile.Path, System.IO.Path.GetFileName(_mediaFile.Path));
            FileImage.Source = ImageSource.FromStream(() =>
            {
                stream = _mediaFile.GetStream();
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
            //LocalPath.Text = _mediaFile.Path;

            await AWSUploadPic(_mediaFile.Path, System.IO.Path.GetFileName(_mediaFile.Path));
            FileImage.Source = ImageSource.FromStream(() =>
            {
                return _mediaFile.GetStream();
            });

        }

        public static async Task AWSUploadPic(string filePath, string requiredFileName)
        {
            try
            {

                AWSCredentials creds = new BasicAWSCredentials(PutAWSAccessKey,
                                                                   PutAWSSecretKey);

                var client = new AmazonS3Client(creds, RegionEndpoint.USEast2);    // "USWest2" replace your code(Amazon)

                var po = new PutObjectRequest();
                po.CannedACL = S3CannedACL.PublicReadWrite;
                po.FilePath = filePath;
                po.BucketName = "quicktask";
                po.Key = requiredFileName;

                var p = await client.PutObjectAsync(po);


                Console.WriteLine("Upload completed");
            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                if (amazonS3Exception.ErrorCode != null &&
                    (amazonS3Exception.ErrorCode.Equals("InvalidAccessKeyId")
                    ||
                    amazonS3Exception.ErrorCode.Equals("InvalidSecurity")))
                {
                    throw new Exception("Check the provided AWS Credentials.");
                }
                else
                {
                    throw new Exception("Error occurred: " + amazonS3Exception.Message);
                }
            }
        }
    }
}