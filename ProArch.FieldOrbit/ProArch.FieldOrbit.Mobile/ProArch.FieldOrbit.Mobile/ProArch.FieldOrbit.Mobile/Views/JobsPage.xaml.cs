using System;

using ProArch.FieldOrbit.Models;
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
            var job = args.SelectedItem as Job;
            if (job == null)
                return;

            Globals.CurrentJob = job;
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

        private void test_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new JobDetailsPage());
        }
    }
}
