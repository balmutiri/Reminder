using Reminder.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Reminder.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(ReminderEntityFrameworkCoreModule),
    typeof(ReminderApplicationContractsModule)
    )]
public class ReminderDbMigratorModule : AbpModule
{
}
