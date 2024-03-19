using AvansDevOps.Domain.Observers;
using AvansDevOps.Domain.Observers.NotificationObserver;
using AvansDevOps.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Domain
{
    public class Thread : IPublisher
    {
        public List<User> Users = new List<User>();
        public List<IListener> Listeners = new List<IListener>();
        public NotificationService NotificationService = new NotificationService();

        public void NotifyListeners()
        {
            foreach(IListener listener in Listeners)
            {
                listener.Notify(this);
            }
        }

        public void Subscribe(IListener listener)
        {
            Listeners.Add(listener);
        }

        public void Unsubscribe(IListener listener)
        {
            Listeners.Remove(listener);
        }

        public void AddUser(User user)
        {
            Users.Add(user);
        }
    }
}
