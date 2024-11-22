using Reminder.Samples;
using Xunit;

namespace Reminder.EntityFrameworkCore.Applications;

[Collection(ReminderTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<ReminderEntityFrameworkCoreTestModule>
{

}
