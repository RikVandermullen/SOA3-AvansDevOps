using AvansDevOps.Domain.Observers;
using AvansDevOps.Domain.Observers.NotificationObserver;
using AvansDevOps.Domain.States.BacklogItemState;
using AvansDevOps.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Domain
{
    public class BacklogItem
    {
        private IBacklogItemState BacklogItemState { get; set; }
        private List<Activity> Activities { get; set; }
        public NotificationService NotificationService = new NotificationService();
        public Developer Developer;

        public BacklogItem(Developer developer)
        {
            BacklogItemState = new TodoState(this); 
            Activities = new List<Activity>();
            Developer = developer;
        }

        public bool CheckActivitiesDone()
        {
            bool done = true;
            foreach (Activity activity in Activities)
            {
                if (!activity.IsCompleted)
                {
                    done = false;
                    break;
                }
            }
            return done;
        }

        public void AddActivity(Activity activity)
        {
            Activities.Add(activity);
        }

        public void SetState(IBacklogItemState backlogItemState)
        {
            BacklogItemState = backlogItemState;
        }

        public void SetToToDo()
        {
            BacklogItemState.SetToToDo();
        }

        public void SetToDoing()
        {
            BacklogItemState.SetToDoing();
        }

        public void SetToReadyForTesting()
        {
            BacklogItemState.SetToReadyForTesting();
        }

        public void SetToTesting()
        {
            BacklogItemState.SetToTesting();
        }

        public void SetToTested()
        {
            BacklogItemState.SetToTested();
        }

        public void SetToDone()
        {
            BacklogItemState.SetToDone();
        }
    }
}
