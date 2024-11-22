using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Reminder.Messages
{
    public class Message : FullAuditedEntity<Guid>
    {
        public string Email { get; private set; }
        public string Text { get; private set; }
        public DateTime SendDate { get; private set; }

        public Message(Guid id, string email, string text, DateTime sendDate)
        {
            Id = id;
            Email = email;
            Text = text;
            SendDate = sendDate;
        }
        public Message() { }
    }
}
