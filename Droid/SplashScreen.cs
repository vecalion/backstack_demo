using Android.App;
using Android.Content.PM;
using Cirrious.MvvmCross.Droid.Views;

namespace backstack.Droid
{
    [Activity(
		Label = "backstack.Droid"
		, MainLauncher = true
		, Icon = "@mipmap/icon"
		, Theme = "@style/Theme.Splash"
		, NoHistory = true
		, ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : MvxSplashScreenActivity
    {
        public SplashScreen()
            : base(Resource.Layout.SplashScreen)
        {
        }
    }
}