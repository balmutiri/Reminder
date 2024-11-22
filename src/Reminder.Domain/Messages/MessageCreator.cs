using JetBrains.Annotations;
using Reminder.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Reminder.Messages
{
    public class MessageCreator : DomainService
    {
        public Message Create(
            [NotNull] string email,
            [NotNull] string text,
            [NotNull] DateTime sendDate)
        {
            return MessageFactory.Create(
                id: Guid.NewGuid(),
                email: email,
                text: text,
                sendDate: sendDate);
        }
    }

}
