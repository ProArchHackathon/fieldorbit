using ProArch.FieldOrbit.Mobile.Models;
using ProArch.FieldOrbit.Mobile.ViewModels;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ProArch.FieldOrbit.Mobile.ViewModels;
using Plugin.Media;
using Plugin.Media.Abstractions;

namespace ProArch.FieldOrbit.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JobDetailsPage : ContentPage
    {
        JobDetailsViewModel jobDetailsViewModel;

        public JobDetailsPage()
        {
            InitializeComponent();
            cboStatus.Items.Add("Started");
            cboStatus.Items.Add("InProgress");
            cboStatus.Items.Add("Completed");

            BindingContext = jobDetailsViewModel= new JobDetailsViewModel ();
        }

        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCreateJob_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreateJobPage());
        }

        private void btnLogTime_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TimeSheetsPage());
        }

        private void btnShowCustomer_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushModalAsync(new CustomerDetailsPage());
            Navigation.PushAsync(new CustomerDetailsPage());
        }

        private void btnShowDeviceInfo_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DeviceInfoPage());
        }

        private async void btnCamera_Clicked(object sender, EventArgs e)
        {
            try
            {
                await CrossMedia.Current.Initialize();
                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await DisplayAlert("No Camera", "No Camera available.", "OK");
                    return;
                }
                var imageFile = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                {
                    SaveToAlbum = true,
                    Name = "test.jpg"
                });

                if (imageFile == null) return;
                imgView.Source = ImageSource.FromStream(() => imageFile.GetStream());
            }
            catch
            {
                await DisplayAlert("No Camera", "No Camera available.", "OK");
                return;
            }
        }

        private async void btnGallery_Clicked(object sender, EventArgs e)
        {
            try
            {
                await CrossMedia.Current.Initialize();
                if (!CrossMedia.Current.IsPickPhotoSupported)
                {
                    await DisplayAlert("No upload", "Picking a photo is not supported.", "OK");
                    return;
                }
                var imageFile = await CrossMedia.Current.PickPhotoAsync();


                if (imageFile == null) return;
                imgView.Source = ImageSource.FromStream(() => imageFile.GetStream());
            }
            catch
            {
                await DisplayAlert("No upload", "Picking a photo is not supported.", "OK");
                return;
            }
        }
    }
}
