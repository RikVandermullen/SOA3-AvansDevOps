using AvansDevOps.Domain.Adapters;
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
        public void Send(User user, string message)
        {
            foreach(INotificationAdapter platform in user.NotificationPlatforms)
            {
                platform.Send(user, message);
            }
        }
    }
}
