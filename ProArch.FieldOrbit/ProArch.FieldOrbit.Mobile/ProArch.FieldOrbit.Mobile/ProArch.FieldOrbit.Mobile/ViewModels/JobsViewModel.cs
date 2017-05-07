﻿using System;
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
    public class JobsViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Job> Jobs { get; set; }
        public Command LoadJobsCommand { get; set; }

        public JobsViewModel()
        {
            Title = "Jobs";
            Jobs = new ObservableRangeCollection<Job>();
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
                var jobs = await ServiceAdapter.Instance.Get<List<Job>>("Job/GetUserJob?employeeID=" + Globals.CurrentWorkman.EmployeeId);
                Jobs.ReplaceRange(jobs);
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