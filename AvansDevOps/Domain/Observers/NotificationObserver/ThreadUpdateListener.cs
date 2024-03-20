﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AvansDevOps.Domain;
using AvansDevOps.Domain.Users;

namespace AvansDevOps.Domain.Observers.NotificationObserver
{
    public class ThreadUpdateListener : IListener
    {
        public NotificationService NotificationService = new NotificationService();

        public void Notify(IPublisher publisher)
        {
            if (publisher is Thread)
            {
                Thread thread = (Thread)publisher;
                foreach(User user in thread.Users)
                {
                    NotificationService.Send(user, $"Thread Update: There has been an update in the thread for backlog item {thread.BacklogItem.Name} you commented on.");
                }
            }
        }
    }
}
