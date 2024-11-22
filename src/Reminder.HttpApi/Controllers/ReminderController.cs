using Reminder.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Reminder.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class ReminderController : AbpControllerBase
{
    protected ReminderController()
    {
        LocalizationResource = typeof(ReminderResource);
    }
}
