using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ProArch.FieldOrbit.Mobile.ViewModels;

namespace ProArch.FieldOrbit.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TimeSheetsPage : ContentPage
    {
        TimesheetViewModel timesheetViewModel;

        public TimeSheetsPage()
        {
            InitializeComponent();

            BindingContext = timesheetViewModel = new TimesheetViewModel();

            for (int i = 1; i < 23; i++)
            {
                //cboHours.Items.Add(i.ToString());
            }


            for (int i = 1; i < 59; i++)
            {
                //cboMinutes.Items.Add(i.ToString());
            }

        }
    }
}
