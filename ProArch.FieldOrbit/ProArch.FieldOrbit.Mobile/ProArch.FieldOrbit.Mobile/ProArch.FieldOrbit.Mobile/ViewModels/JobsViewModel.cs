using System;
using System.Diagnostics;
using System.Threading.Tasks;

using ProArch.FieldOrbit.Mobile.Helpers;
using ProArch.FieldOrbit.Mobile.Models;
using ProArch.FieldOrbit.Mobile.Views;

using Xamarin.Forms;
using ProArch.FieldOrbit.Mobile.Services;
using System.Collections.Generic;

namespace ProArch.FieldOrbit.Mobile.ViewModels
{
    public class JobsViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Ticket> Jobs { get; set; }
        public Command LoadJobsCommand { get; set; }

        public JobsViewModel()
        {
            Title = "Jobs";
            Jobs = new ObservableRangeCollection<Ticket>();
            LoadJobsCommand = new Command(async () => await ExecuteLoadTicketsCommand());
        }

        async Task ExecuteLoadTicketsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Jobs.Clear();
                var tickets = await ServiceAdapter.Instance.Get<List<Ticket>>("GetTickets");
                Jobs.ReplaceRange(tickets);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessagingCenter.Send(new MessagingCenterAlert
                {
                    Title = "Error",
                    Message = "Unable to load items.",
                    Cancel = "OK"
                }, "message");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}