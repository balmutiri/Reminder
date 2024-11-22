using Reminder.Reminders.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.Reminders
{
    public interface IRemindMeAppService
    {
        Task AddAsync(SetNewReminderDto input);
    }
}
