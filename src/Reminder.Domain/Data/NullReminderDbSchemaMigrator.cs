using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Reminder.Data;

/* This is used if database provider does't define
 * IReminderDbSchemaMigrator implementation.
 */
public class NullReminderDbSchemaMigrator : IReminderDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
