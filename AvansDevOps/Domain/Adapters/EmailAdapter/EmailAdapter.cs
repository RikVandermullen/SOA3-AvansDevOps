using AvansDevOps.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Domain.Adapters.EmailAdapter
{
    public class EmailAdapter : INotificationService
    {
        private EmailService EmailService = new EmailService();

        public void Send(User user, string message)
        {
            EmailService.SetEmailAddress(user.EmailAddress);
            EmailService.SetName(user.Name);
            EmailService.SetMessage(message);
            EmailService.SendEmail();
        }
    }
}
