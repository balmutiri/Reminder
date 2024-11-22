using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;
using Volo.Abp.Emailing;

namespace Reminder.Notifications
{
    public class NotificationSender : DomainService, INotificationSender
    {
        private readonly IEmailSender _emailSender;

        public NotificationSender(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }
        public async Task SendEmailAsync(string to, string subject, string body)
        {
            await _emailSender.SendAsync(to, subject, body);
        }
    }

}
