using AvansDevOps.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Domain.Adapters.EmailAdapter
{
    public class EmailAdapter : INotificationAdapter
    {
        private readonly EmailService _emailService = new EmailService();

        public void Send(User user, string message)
        {
            _emailService.SetEmailAddress(user.EmailAddress);
            _emailService.SetName(user.Name);
            _emailService.SetMessage(message);
            _emailService.SendEmail();
        }
    }
}
