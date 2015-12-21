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
	[Activity (Label = "View for FirstViewModel")]
	public class FirstView : MvxActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.FirstView);

			var intentDeep = this.CreateIntentFor<DeepViewModel> (new Dictionary<string, string> { { "message", "FROM INTENT" } });
			var intentDeeper = this.CreateIntentFor<DeeperViewModel> (new Dictionary<string, string> { { "answer", "42" } });

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
			notificationManager.Notify (0, builder.Build ());
		}
	}
}