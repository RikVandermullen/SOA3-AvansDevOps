using AvansDevOps.Domain.States.BacklogItemState;
using AvansDevOps.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AvansDevOps.Domain.Observers.NotificationObserver
{
    public class StateTransitionListener : IListener
    {
        public void Notify(IPublisher publisher)
        {
            if (publisher is BacklogItem item)
            {
                HandleReadyForTesting(item);
                HandleFailedTests(item);
            }
        }

        private void HandleReadyForTesting(BacklogItem item)
        {
            if (item.BacklogItemState is ReadyForTestingState)
            {
                foreach(User user in item.Sprint.Users)
                {
                    if (user is Tester)
                    {
                        item.NotificationService.Send(user, "A backlog item is ready for testing.");
                    }
                }
            }
        }

        private void HandleFailedTests(BacklogItem item)
        {
            if (item.BacklogItemState is TodoState && item.PreviousState is TestingState)
            {
                foreach (User user in item.Sprint.Users)
                {
                    if (user is ScrumMaster)
                    {
                        item.NotificationService.Send(user, "A backlog item failed tests and has been returned to todo.");
                    }
                }
            }
        }
    }
}
