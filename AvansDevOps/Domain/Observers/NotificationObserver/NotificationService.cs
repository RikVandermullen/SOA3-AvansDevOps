using AvansDevOps.Domain.Adapters.EmailAdapter;
using AvansDevOps.Domain.Adapters.SlackAdapter;
using AvansDevOps.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Domain.Observers.NotificationObserver
{
    public class NotificationService
    {
        private EmailAdapter EmailAdapter = new EmailAdapter();
        private SlackAdapter SlackAdapter = new SlackAdapter();

        public void SendEmail(User user, String message)
        {
            EmailAdapter.Send(user, message);
        }

        public void SendSlack(User user, String message)
        {
            SlackAdapter.Send(user, message);
        }
    }
}
