using Volo.Abp.Settings;

namespace Reminder.Settings;

public class ReminderSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(ReminderSettings.MySetting1));
    }
}
