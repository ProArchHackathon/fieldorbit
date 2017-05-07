using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Messaging;

namespace ProArch.FieldOrbit.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeviceInfoPage : ContentPage
    {
        public DeviceInfoPage()
        {
            InitializeComponent();
            BindingContext = Globals.CurrentJob;
        }

        private void btnCallSMEonPhone_Clicked(object sender, EventArgs e)
        {
            var phoneCallTask = CrossMessaging.Current.PhoneDialer;
            if (phoneCallTask.CanMakePhoneCall)
                phoneCallTask.MakePhoneCall("+918919709779");
        }

        private void btnCallSMEonSkype_Clicked(object sender, EventArgs e)
        {
            try
            {
                Device.OpenUri(new Uri("skype://555-1111"));
            }
            catch
            {
                DisplayAlert("Skype", "No Skype is available.", "OK");
            }
        }

        private void btnRecomendationVideo_Clicked(object sender, EventArgs e)
        {
            string Source = "https://hackathonstorageac.blob.core.windows.net/hackathon/D0002_install.mp4";
            Navigation.PushAsync(new VideoPlayerPage(Source));
        }
    }
}
