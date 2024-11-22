using Volo.Abp.Modularity;

namespace Reminder;

public abstract class ReminderApplicationTestBase<TStartupModule> : ReminderTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
