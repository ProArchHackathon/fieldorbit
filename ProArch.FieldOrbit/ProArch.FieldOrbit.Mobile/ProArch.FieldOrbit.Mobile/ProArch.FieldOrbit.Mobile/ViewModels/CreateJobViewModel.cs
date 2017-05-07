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
    public class CreateJobViewModel : BaseViewModel
    {
        public Job Job { get; set; }

        public Command CreateJobCommand { get; set; }

        public Command ResetCommand { get; set; }

        public CreateJobViewModel()
        {
            Title = "Create Job";

            this.Job = new Job();
            this.Job.Employee = Globals.CurrentJob.Employee;
            this.Job.WorkRequest = Globals.CurrentJob.WorkRequest;
            this.Job.EndTime = new DateTime();
            this.Job.StartTime = new DateTime();

            CreateJobCommand = new Command(async () => await ExecCreateJobCommand());
            ResetCommand = new Command(async () => await ExecResetCommand());
        }

        async Task ExecCreateJobCommand()
        {
            if (IsBusy) return;

            IsBusy = true;

            try
            {
                await ServiceAdapter.Instance.Post<Job>("Job/CreateJob", this.Job);
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