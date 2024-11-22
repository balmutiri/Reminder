using Volo.Abp.Modularity;

namespace Reminder;

[DependsOn(
    typeof(ReminderApplicationModule),
    typeof(ReminderDomainTestModule)
)]
public class ReminderApplicationTestModule : AbpModule
{

}
