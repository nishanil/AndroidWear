using System;
using System.Collections.Generic;
using System.Text;
using ServiceReminder.Models;

namespace ServiceReminder
{
    public interface IReminderService
    {
        void Remind(DateTime dateTime, string title, string message);
    }
}
