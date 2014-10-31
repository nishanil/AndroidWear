using System;
using Xamarin.Forms;
using ServiceReminder.Models;

namespace ServiceReminder
{
	public class App
	{
		public static Page GetMainPage ()
		{	
			return new NavigationPage (new HomePage ());
		}

		public static ReminderItem SelectedModel { get; set; }

		public static SQLite.Net.SQLiteConnection Connection {
			get;
			set;
		}
	}
}

