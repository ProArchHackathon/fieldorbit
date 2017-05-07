using System;

using ProArch.FieldOrbit.Mobile.Models;
using ProArch.FieldOrbit.Mobile.ViewModels;

using Xamarin.Forms;

namespace ProArch.FieldOrbit.Mobile.Views
{
    public partial class JobsPage : ContentPage
    {
        JobsViewModel viewModel;

        public JobsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new JobsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Ticket;
            if (item == null)
                return;

            Navigation.PushAsync(new JobDetailsPage());

            // Manually deselect item
            JobsListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Jobs.Count == 0)
                viewModel.LoadJobsCommand.Execute(null);
        }
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> Complete solution with UWP
=======
>>>>>>> 85fc0fd05e49a90d4978b9ec91d2dbfe7c42887d

        private void test_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new JobDetailsPage());
        }
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> Initial commit
=======
>>>>>>> Complete solution with UWP
=======
>>>>>>> 85fc0fd05e49a90d4978b9ec91d2dbfe7c42887d
    }
}
