using System.Threading.Tasks;

namespace Reminder.Data;

public interface IReminderDbSchemaMigrator
{
    Task MigrateAsync();
}
