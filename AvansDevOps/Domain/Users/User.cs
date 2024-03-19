using AvansDevOps.Domain.Adapters.EmailAdapter;
using AvansDevOps.Domain.Adapters;
using AvansDevOps.Domain.Observers;
using AvansDevOps.Domain.Observers.NotificationObserver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Domain.Users
{
    public abstract class User
    {
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string SlackUsername { get; set; }
        public List<INotificationAdapter> NotificationPlatforms { get; set; }

        public User(string name, string emailAddress, string slackUsername)
        {
            Name = name;
            EmailAddress = emailAddress;
            SlackUsername = slackUsername;
            NotificationPlatforms = new List<INotificationAdapter> { new EmailAdapter() };
        }

        public void AddPlatform(INotificationAdapter adapter)
        {
            NotificationPlatforms.Add(adapter);
        }
    }
}
