using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ProArch.FieldOrbit.Mobile.ViewModels;
using Plugin.Media;
using Plugin.Media.Abstractions;

namespace ProArch.FieldOrbit.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateJobPage : ContentPage
    {
        private CreateJobViewModel createJobViewModel;

        public CreateJobPage()
        {
            try
            {
                InitializeComponent();
                FillStatusCombo();

                BindingContext = createJobViewModel = new CreateJobViewModel();
            }
            catch (Exception e)
            {
            }
        }

        private void FillStatusCombo()
        {
            cboStatus.Items.Add("Started");
            cboStatus.Items.Add("InProgress");
            cboStatus.Items.Add("Completed");
        }

        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboPriority_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
