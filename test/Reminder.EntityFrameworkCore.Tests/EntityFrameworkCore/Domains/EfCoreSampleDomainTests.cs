using Reminder.Samples;
using Xunit;

namespace Reminder.EntityFrameworkCore.Domains;

[Collection(ReminderTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<ReminderEntityFrameworkCoreTestModule>
{

}
