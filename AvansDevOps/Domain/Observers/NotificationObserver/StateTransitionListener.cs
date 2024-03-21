using AvansDevOps.Domain.Sprints;
using AvansDevOps.Domain.States.BacklogItemState;
using AvansDevOps.Domain.States.ReleaseSprintState;
using AvansDevOps.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SprintClosedState = AvansDevOps.Domain.States.ReleaseSprintState.ClosedState;
using BacklogItemClosedState = AvansDevOps.Domain.States.BacklogItemState.ClosedState;
using Thread = AvansDevOps.Domain.Composites.ForumComposite.Thread;
using AvansDevOps.Domain.Visitors.ForumVisitor;

namespace AvansDevOps.Domain.Observers.NotificationObserver
{
    public class StateTransitionListener : IListener
    {
        public NotificationService NotificationService = new NotificationService();

        public void Notify(IPublisher publisher)
        {
            if (publisher is BacklogItem item)
            {
                HandleReadyForTesting(item);
                HandleFailedTests(item);
                HandleBacklogClosing(item);
            }

            if (publisher is ReleaseSprint sprint)
            {
                HandleCancelledRelease(sprint);
                HandleClosedRelease(sprint);
                HandleFailedDeployment(sprint);
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
                        NotificationService.Send(user, $"The backlog item {item.Name} is ready for testing.");
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
                        NotificationService.Send(user, $"The backlog item {item.Name} failed tests and has been returned to todo.");
                    }
                }
            }
        }

        private void HandleCancelledRelease(ReleaseSprint sprint)
        {
            if (sprint.ReleaseSprintState is CancelledState)
            {
                foreach (User user in sprint.Users)
                {
                    if (user is ScrumMaster or ProductOwner)
                    {
                        NotificationService.Send(user, $"Sprint Cancelled: The sprint {sprint.Name} has been cancelled.");
                    }
                }
            }
        }

        private void HandleClosedRelease(ReleaseSprint sprint)
        {
            if (sprint.ReleaseSprintState is SprintClosedState)
            {
                foreach (User user in sprint.Users)
                {
                    if (user is ScrumMaster or ProductOwner)
                    {
                        NotificationService.Send(user, $"Sprint Closed: The sprint {sprint.Name} has been succesfully closed.");
                    }
                }
            }
        }

        private void HandleFailedDeployment(ReleaseSprint sprint)
        {
            if (sprint.ReleaseSprintState is FinishedState && sprint.PreviousState is DeployingState)
            {
                foreach (User user in sprint.Users)
                {
                    if (user is ScrumMaster)
                    {
                        NotificationService.Send(user, $"Sprint Failed: Errors occured while deploying the sprint {sprint.Name}.");
                    }
                }
            }
        }

        private void HandleBacklogClosing(BacklogItem backlogItem)
        {
            if (backlogItem.BacklogItemState is BacklogItemClosedState)
            {
                foreach (Thread thread in backlogItem.Threads)
                {
                    thread.AcceptVisitor(new LockVisitor());
                }
            }
        }

    }
}
