using Volo.Abp.Modularity;

namespace Reminder;

[DependsOn(
    typeof(ReminderDomainModule),
    typeof(ReminderTestBaseModule)
)]
public class ReminderDomainTestModule : AbpModule
{

}
