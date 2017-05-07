using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProArch.FieldOrbit.Mobile.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VideoPlayerPage : ContentPage
    {
        string videoUrl = string.Empty;
        public VideoPlayerPage( string videoUrl)
        {
            InitializeComponent();
            this.videoUrl = videoUrl;
            videoPlayer.Source = videoUrl;
        }

    }
}
