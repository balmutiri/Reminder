using JetBrains.Annotations;
using Reminder.Messages;
using System;
using System.Collections.Generic;

namespace Reminder.Factories
{
    public class MessageFactory
    {
        public static Message Create(
            [NotNull] Guid id,
            [NotNull] string email,
            [NotNull] string text,
            [NotNull] DateTime sendDate)
            => new(
                id,
                email,
                text,
                sendDate);
    }
}
