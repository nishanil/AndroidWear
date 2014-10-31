using ServiceReminder.Models;
using SQLite.Net ;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

namespace ServiceReminder.Data
{
    public class ReminderItemDatabase
    {


        static object locker = new object();

		static SQLiteConnection database;

		public ReminderItemDatabase()
        {
			database = App.Connection;
            // create the tables
            database.CreateTable<ReminderItem>();
        }

        public IEnumerable<ReminderItem> GetItems()
        {
            lock (locker)
            {
                return (from i in database.Table<ReminderItem>() select i).ToList();
            }

        }

        public ReminderItem GetItem(int id)
        {
            lock (locker)
            {
              return database.Table<ReminderItem>().FirstOrDefault(x => x.Id == id);
            }
		
        }

        public int SaveItem(ReminderItem item)
        {
            lock (locker)
            {
                if (item.Id != 0)
                {
                    database.Update(item);
                    return item.Id;
                }
                else
                {
                    return database.Insert(item);
                }
            }


        }

        public int DeleteItem(int id)
        {
            lock (locker)
            {
               return database.Delete<ReminderItem>(id);
            }

        }
    }
}
