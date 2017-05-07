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
    public class TimesheetViewModel : BaseViewModel
    {
        public Timesheet Timesheet { get; set; }

        public int JobID { get; set; }

        public int CrewID { get; set; }

        public Command LogTimeCommand { get; set; }

        public Command ResetCommand { get; set; }

        public TimesheetViewModel()
        {
            Title = "Log time";

            IniTimesheet();

            LogTimeCommand = new Command(async () => await ExecLogTimeCommand());
            ResetCommand = new Command(async () => await ExecResetCommand());
        }

        private void IniTimesheet()
        {
            this.Timesheet = new Timesheet();
            this.Timesheet.WorkDate = DateTime.Now.AddDays(10);
            this.Timesheet.Hours = 0;
            this.CrewID = Globals.CurrentWorkman.EmployeeId;
            this.JobID = Globals.CurrentJob.JobId;
        }

        async Task ExecLogTimeCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                await ServiceAdapter.Instance.Post<Timesheet>("Job/EnterTimeSheet/"+Globals.CurrentJob.JobId, this.Timesheet);
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
            IniTimesheet(); 
        }

    }
}