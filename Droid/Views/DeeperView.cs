using Android.App;
using Android.OS;
using Cirrious.MvvmCross.Droid.Views;

namespace backstack.Droid.Views
{
    [Activity(Label = "Deeper View")]
    public class DeeperView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
			SetContentView(Resource.Layout.DeeperView);


        }
    }
}