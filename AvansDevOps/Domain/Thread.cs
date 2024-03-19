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
    public class Thread : Publisher
    {
        public List<User> Users = new List<User>();
        public List<Listener> Listeners = new List<Listener>();
        public NotificationService NotificationService = new NotificationService();

        public void NotifyListeners()
        {
            foreach(Listener listener in Listeners)
            {
                listener.Notify(this);
            }
        }

        public void Subscribe(Listener listener)
        {
            Listeners.Add(listener);
        }

        public void Unsubscribe(Listener listener)
        {
            Listeners.Remove(listener);
        }

        public void AddUser(User user)
        {
            Users.Add(user);
        }
    }
}
