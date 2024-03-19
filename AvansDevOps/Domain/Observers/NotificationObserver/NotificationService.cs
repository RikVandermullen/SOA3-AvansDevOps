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
        private List<INotificationService> Adapters = new List<INotificationService> { new EmailAdapter() };

        public void Send(User user, string message)
        {
            foreach(INotificationService adapter in Adapters)
            {
                adapter.Send(user, message);
            }
        }

        public void AddAdapter(INotificationService adapter)
        {
            Adapters.Add(adapter);
        }
    }
}
