using Microsoft.Extensions.Configuration;
using RazorLight;
using Reminder.Helpers.Encryptions;
using Reminder.Notifications;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Reminder.Messages
{
    public class MessageManager : DomainService
    {
        private readonly IConfiguration _configuration;
        private readonly INotificationSender _notificationSender;
        private readonly IRepository<Message> _messageRepository;
        private readonly EncryptionHelper _encryptionHelper;

        public MessageManager(IConfiguration configuration, INotificationSender notificationSender, IRepository<Message> messageRepository, EncryptionHelper encryptionHelper)
        {
            _configuration = configuration;
            _notificationSender = notificationSender;
            _messageRepository = messageRepository;
            _encryptionHelper = encryptionHelper;
        }

        public async Task SendSubmitNotificationAsync(string email)
        {
            string htmlContent = File.ReadAllText("assets/SubmitTemplate.cshtml");
            string url = String.Format(_configuration["App:ClientUrl"]);

            var engine = new RazorLightEngineBuilder().Build();
            string emailBody = await engine.CompileRenderStringAsync("SubmitTemplate", htmlContent, new ReminderTemplateModel() { WebUrl = url });

            await _notificationSender.SendEmailAsync(email, "تذكير", emailBody);
        }
        
        public async Task SendEmailReminderAsync()
        {
            List<Message> messages = await _messageRepository.GetListAsync(x => x.SendDate <= DateTime.Now);

            if (!messages.Any())
                return;

            foreach (Message message in messages)
            {
                string text = _encryptionHelper.Decrypt(message.Text);
                string htmlContent = File.ReadAllText("assets/EmailTemplate.cshtml");
                string url = String.Format(_configuration["App:ClientUrl"]);

                var engine = new RazorLightEngineBuilder().Build();
                string emailBody = await engine.CompileRenderStringAsync("EmailTemplate", htmlContent, new ReminderTemplateModel() { Body = text, WebUrl = url });

                await _notificationSender.SendEmailAsync(message.Email, "تذكير", emailBody);
            }
            await _messageRepository.DeleteManyAsync(messages);
        }
    }
}
