using System;
using System.Diagnostics;
using System.Threading.Tasks;

using ProArch.FieldOrbit.Mobile.Helpers;
using ProArch.FieldOrbit.Mobile.Models;
using ProArch.FieldOrbit.Mobile.Views;

using Xamarin.Forms;
using ProArch.FieldOrbit.Mobile.Services;
using System.Collections.Generic;
using ProArch.FieldOrbit.Models;

namespace ProArch.FieldOrbit.Mobile.ViewModels
{
    public class JobDetailsViewModel : BaseViewModel
    {
        public Job Job { get; set; }

        public Command UpdateJobCommand { get; set; }

        public JobDetailsViewModel()
        {
            Title = "Job Details";

            this.Job = Globals.CurrentJob;

            UpdateJobCommand = new Command(async () => await ExecUpdateJobCommand());
        }

        async Task ExecUpdateJobCommand()
        {
            if (IsBusy) return;

            IsBusy = true;

            try
            {
                await ServiceAdapter.Instance.Post<Job>("Job/UpdateJob", this.Job);
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

        async Task ExecResetCommand()
        {
            this.Job = new Job();
        }
    }
}