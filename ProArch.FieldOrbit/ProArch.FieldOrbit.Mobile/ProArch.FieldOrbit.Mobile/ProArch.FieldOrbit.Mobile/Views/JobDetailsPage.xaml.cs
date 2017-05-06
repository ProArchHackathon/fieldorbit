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
    public partial class JobDetailsPage : ContentPage
    {
        public JobDetailsPage()
        {
            InitializeComponent();
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

        private void btnUpdate_Clicked(object sender, EventArgs e)
        {

        }
    }
}
