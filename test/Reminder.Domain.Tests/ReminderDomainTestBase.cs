using Volo.Abp.Modularity;

namespace Reminder;

/* Inherit from this class for your domain layer tests. */
public abstract class ReminderDomainTestBase<TStartupModule> : ReminderTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
