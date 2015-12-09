using Android.App;
using Android.OS;
using Cirrious.MvvmCross.Droid.Views;

namespace backstack.Droid.Views
{
    [Activity(Label = "Deep View")]
    public class DeepView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
			SetContentView(Resource.Layout.DeepView);
        }
    }
}