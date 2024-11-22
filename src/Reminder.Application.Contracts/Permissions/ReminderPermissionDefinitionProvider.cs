using Reminder.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Reminder.Permissions;

public class ReminderPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(ReminderPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(ReminderPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ReminderResource>(name);
    }
}
