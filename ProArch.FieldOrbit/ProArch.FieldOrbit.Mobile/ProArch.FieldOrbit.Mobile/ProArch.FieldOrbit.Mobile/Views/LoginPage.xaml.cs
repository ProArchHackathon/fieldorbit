using ProArch.FieldOrbit.Mobile.Services;
using System;

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
                string url = string.Concat("LoginOperations/Validate?username=", txtUserName.Text, "&password=", txtPassword.Text);
                App.IsUserLoggedIn = await ServiceAdapter.Instance.ValidateUser<bool>(url);
                if (App.IsUserLoggedIn)
                {
                    App.IsUserLoggedIn = true;
                    Navigation.InsertPageBefore(new JobsPage(), this);
                    await Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("Alert", "Invalid UserId/Password", "Ok");
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
