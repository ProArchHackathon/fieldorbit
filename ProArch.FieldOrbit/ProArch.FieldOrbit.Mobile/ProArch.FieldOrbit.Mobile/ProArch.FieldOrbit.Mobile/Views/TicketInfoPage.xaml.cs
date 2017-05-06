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
    public partial class TicketInfoPage : ContentPage
    {
        public TicketInfoPage()
        {
            InitializeComponent();
        }

        private void btnLogTime_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TimeSheetsPage());
        }

        private void btnCreateJob_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreateJobPage());
        }

        private void btnUpdate_Clicked(object sender, EventArgs e)
        {

        }
    }
}
