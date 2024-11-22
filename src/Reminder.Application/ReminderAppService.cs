using System;
using System.Collections.Generic;
using System.Text;
using Reminder.Localization;
using Volo.Abp.Application.Services;

namespace Reminder;

/* Inherit your application services from this class.
 */
public abstract class ReminderAppService : ApplicationService
{
    protected ReminderAppService()
    {
        LocalizationResource = typeof(ReminderResource);
    }
}
