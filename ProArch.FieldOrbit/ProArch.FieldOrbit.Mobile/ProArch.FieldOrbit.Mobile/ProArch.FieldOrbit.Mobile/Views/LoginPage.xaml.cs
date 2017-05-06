using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProArch.FieldOrbit.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        async void btnLogin_Clicked(object sender, EventArgs e)
        {

            try
            {
                var isValid = true;


                if (isValid)
                {
                    App.IsUserLoggedIn = true;
                    Navigation.InsertPageBefore(new JobsPage(), this);
                    await Navigation.PopAsync();
                }
                else
                {
                    //messageLabel.Text = "Login failed";
                }
            }
            catch (Exception Exception)
            {


            }
        }


        private void btnCancel_Clicked(object sender, EventArgs e)
        {

        }
    }
}
