using Xunit;

namespace Reminder.EntityFrameworkCore;

[CollectionDefinition(ReminderTestConsts.CollectionDefinitionName)]
public class ReminderEntityFrameworkCoreCollection : ICollectionFixture<ReminderEntityFrameworkCoreFixture>
{

}
