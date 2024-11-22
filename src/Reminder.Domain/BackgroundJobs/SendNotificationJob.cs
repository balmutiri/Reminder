using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using MimeKit;
using Quartz;
using Quartz.Util;
using RazorLight;
using Reminder.Helpers.Encryptions;
using Reminder.Messages;
using Reminder.Notifications;
using Scriban;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Reminder.BackgroundJobs
{
    public class SendNotificationJob : IJob, ITransientDependency
    {
        private readonly MessageManager _messageManager;

        public SendNotificationJob(MessageManager messageManager)
        {
            _messageManager = messageManager;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            try
            {
                // for now its only email notification, TODO: whatsapp reminder
                await _messageManager.SendEmailReminderAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

    public interface ISendNotificationJobManager : ITransientDependency
    {
        public Task CreateAsync();
    }

    public class SendNotificationJobManager : ISendNotificationJobManager, ITransientDependency
    {
        private readonly ISchedulerFactory _schedulerFactory;

        public SendNotificationJobManager(ISchedulerFactory schedulerFactory)
        {
            _schedulerFactory = schedulerFactory;
        }
        public async Task CreateAsync()
        {
            try
            {
                IScheduler scheduler = await _schedulerFactory.GetScheduler();

                var job = JobBuilder
                    .Create<SendNotificationJob>()
                    .WithIdentity(name: "SendNotificationJob", group: "SendNotificationJob")
                    .Build();

                var trigger = TriggerBuilder
                    .Create()
                    .WithIdentity(name: "SendNotificationJob", group: "SendNotificationJob")
                    .StartNow()
                    .WithSimpleSchedule(x => x.WithIntervalInMinutes(1) // Set the interval to 1 minute
                    .RepeatForever()) // Repeat indefinitely
                    .Build();

                await scheduler.ScheduleJob(job, trigger);
                await scheduler.Start();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to create {ex.Message}");
            }

        }
    }
}
