using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AvansDevOps.Domain;
using AvansDevOps.Domain.Users;

namespace AvansDevOps.Domain.Observers.NotificationObserver
{
    public class ThreadUpdateListener : IListener
    {
        public void Notify(IPublisher publisher)
        {
            if (publisher is Thread)
            {
                Thread thread = (Thread)publisher;
                foreach(User user in thread.Users)
                {
                    thread.NotificationService.Send(user, "There has been an update in a thread you commented on.");
                }
            }
        }
    }
}
