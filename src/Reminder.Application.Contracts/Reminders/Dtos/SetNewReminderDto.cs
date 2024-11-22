using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.Reminders.Dtos
{
    public class SetNewReminderDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public DateTime SendDate { get; set; }
    }
}
