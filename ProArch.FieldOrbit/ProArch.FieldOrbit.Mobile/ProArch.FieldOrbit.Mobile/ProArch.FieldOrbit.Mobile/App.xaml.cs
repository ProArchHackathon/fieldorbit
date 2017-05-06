using ProArch.FieldOrbit.Mobile.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ProArch.FieldOrbit.Mobile
{
    public partial class App : Application
    {
        public static bool IsUserLoggedIn { get; set; }

        public App()
        {
            InitializeComponent();

            SetMainPage();
        }

        public static void SetMainPage()
        {
            Current.MainPage = new NavigationPage(new LoginPage())
            {
                Title = "Field Orbit",
                Icon = Device.OnPlatform("tab_feed.png", null, null)
            };
        }
    }
}
