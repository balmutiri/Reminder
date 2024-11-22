using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.Notifications
{
    public class ReminderTemplateModel
    {
        public string Body { get; set; }
        public string WebUrl { get; set; }
    }
}
