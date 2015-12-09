using Android.App;
using Android.OS;
using Cirrious.MvvmCross.Droid.Views;
using Android.Content;
using Cirrious.MvvmCross.ViewModels;
using System.Collections.Generic;
using Cirrious.CrossCore;
using System;

namespace backstack.Droid.Views
{
    [Activity(Label = "View for FirstViewModel")]
    public class FirstView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.FirstView);

			var intentDeep = new Intent (this, typeof(DeepView));
			SetMvxParams (intentDeep, typeof(DeepViewModel), "message", "FROM INTENT");

			var intentDeeper = new Intent (this, typeof(DeeperView));
			SetMvxParams (intentDeeper, typeof(DeeperViewModel), "answer", "42");

			var taskStackBuilder = TaskStackBuilder.Create (this)
				.AddNextIntent (intentDeeper)
				.AddNextIntent (intentDeep);
					
			var pendingIntent = taskStackBuilder.GetPendingIntent (0, PendingIntentFlags.UpdateCurrent);

			var builder = new Notification.Builder (this)
				.SetSmallIcon (Resource.Drawable.ic_action_android)
				.SetContentTitle ("Go Deeper")
				.SetContentText ("We need to go deeper")
				.SetContentIntent (pendingIntent);

			var notificationManager = (NotificationManager)GetSystemService (NotificationService);
			notificationManager.Notify (0, builder.Build());
        }

		static void SetMvxParams (Intent intent, Type viewModelType, string key, string value)
		{
			var request = MvxViewModelRequest.GetDefaultRequest (viewModelType);
			request.ParameterValues = new Dictionary<string, string> ();
			request.ParameterValues.Add (key, value);

			var extrasKey = "MvxLaunchData";
			var converter = Mvx.Resolve<IMvxNavigationSerializer> ();
			var requestText = converter.Serializer.SerializeObject (request);

			intent.SetAction (string.Empty);
			intent.PutExtra (extrasKey, requestText);
		}
    }
}