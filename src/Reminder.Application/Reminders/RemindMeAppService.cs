using Microsoft.Extensions.Logging;
using Reminder.Helpers.Encryptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp;
using Microsoft.AspNetCore.Mvc;
using Reminder.Messages;
using Reminder.Reminders.Dtos;

namespace Reminder.Reminders
{
    public class RemindMeAppService : ReminderAppService, IRemindMeAppService
    {
        private readonly MessageCreator _messageCreator;
        private readonly EncryptionHelper _encryptionHelper;
        private readonly IRepository<Message> _messageRepository;
        private readonly ILogger<ReminderAppService> _logger;
        private readonly MessageManager _messageManager;

        public RemindMeAppService(MessageCreator messageCreator, EncryptionHelper encryptionHelper, IRepository<Message> messageRepository, ILogger<ReminderAppService> logger, MessageManager messageManager)
        {
            _messageCreator = messageCreator;
            _encryptionHelper = encryptionHelper;
            _messageRepository = messageRepository;
            _logger = logger;
            _messageManager = messageManager;
        }

        [HttpPost]
        [Route("api/app/reminder/remind-me")]
        public async Task AddAsync(SetNewReminderDto input)
        {
            try
            {
                _logger.LogInformation("[Add] called with input: {@Input}", input);

                string encryptedText = _encryptionHelper.Encrypt(input.Text);
                _logger.LogInformation("Text encrypted successfully.");

                Message message = _messageCreator.Create(input.Email, encryptedText, input.SendDate);
                _logger.LogInformation("Message created for email {Email} with send date {SendDate}", input.Email, input.SendDate);

                await _messageRepository.InsertAsync(message);
                _logger.LogInformation("Message successfully inserted into the repository.");

                await _messageManager.SendSubmitNotificationAsync(input.Email);
                _logger.LogInformation("Submit notification has been sent successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in [Add] while adding a new reminder.");
                throw new UserFriendlyException(ex.Message);
            }
        }
    }
}
