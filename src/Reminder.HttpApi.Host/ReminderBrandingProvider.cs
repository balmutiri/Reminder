using Microsoft.Extensions.Localization;
using Reminder.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Reminder;

[Dependency(ReplaceServices = true)]
public class ReminderBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<ReminderResource> _localizer;

    public ReminderBrandingProvider(IStringLocalizer<ReminderResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
