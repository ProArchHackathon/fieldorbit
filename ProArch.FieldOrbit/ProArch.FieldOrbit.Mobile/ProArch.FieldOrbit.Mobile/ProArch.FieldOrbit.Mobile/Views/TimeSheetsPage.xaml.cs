<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
﻿using Xamarin.Forms;
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
>>>>>>> Initial commit
=======
﻿using Xamarin.Forms;
>>>>>>> Complete solution with UWP
=======
﻿using Xamarin.Forms;
>>>>>>> 85fc0fd05e49a90d4978b9ec91d2dbfe7c42887d
using Xamarin.Forms.Xaml;

namespace ProArch.FieldOrbit.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TimeSheetsPage : ContentPage
    {
        public TimeSheetsPage()
        {
            InitializeComponent();


            for (int i = 1; i < 23; i++)
            {
                cboHours.Items.Add(i.ToString());
            }


            for (int i = 1; i < 59; i++)
            {
                cboMinutes.Items.Add(i.ToString());
            }

        }
    }
}
