using System;
using Android.Content;
using Android.App;
using Android.Support.V4.App;
using Android.Graphics;

namespace ServiceReminder.Android
{
	[BroadcastReceiver]
	public class AlarmReceiver : BroadcastReceiver 
	{
		public override void OnReceive (Context context, Intent intent)
		{

			var message = intent.GetStringExtra ("message");
			var title = intent.GetStringExtra ("title");

			var notIntent = new Intent (context, typeof(MainActivity));
			var contentIntent = PendingIntent.GetActivity (context, 0, notIntent, PendingIntentFlags.CancelCurrent);
			var manager = NotificationManagerCompat.From (context);
			
						var style = new NotificationCompat.BigTextStyle();
						style.BigText(message);
			
						int resourceId;
						if (App.SelectedModel.VehicleType == "Car")
							resourceId = Resource.Drawable.Car;
						else if (App.SelectedModel.VehicleType == "Bike")
							resourceId = Resource.Drawable.Bike;
						else
							resourceId = Resource.Drawable.Other;
			
						var wearableExtender = new NotificationCompat.WearableExtender()
				.SetBackground(BitmapFactory.DecodeResource(context.Resources, resourceId))
							;
			
						//Generate a notification with just short text and small icon
			var builder = new NotificationCompat.Builder (context)
							.SetContentIntent (contentIntent)
							.SetSmallIcon (Resource.Drawable.ic_launcher)
							.SetContentTitle(title)
							.SetContentText(message)
							.SetStyle(style)
							.SetWhen(Java.Lang.JavaSystem.CurrentTimeMillis())
							.SetAutoCancel(true)
							.Extend(wearableExtender);
			
			
						var notification = builder.Build();
						manager.Notify(0, notification);
		}
	}
}

