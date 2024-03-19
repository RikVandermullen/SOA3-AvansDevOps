using AvansDevOps.Domain.Observers.NotificationObserver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Domain.States.BacklogItemState
{
    public class DoingState : IBacklogItemState
    {
        private BacklogItem BacklogItem { get; set; }

        public DoingState(BacklogItem backlogItem)
        {
            BacklogItem = backlogItem;
        }

        public void SetToToDo()
        {
            throw new InvalidOperationException();
        }

        public void SetToDoing()
        {
            throw new InvalidOperationException();
        }

        public void SetToReadyForTesting()
        {
            BacklogItem.SetState(new ReadyForTestingState(BacklogItem));
        }

        public void SetToTesting()
        {
            throw new InvalidOperationException();
        }

        public void SetToTested()
        {
            throw new InvalidOperationException();
        }

        public void SetToDone()
        {
            throw new InvalidOperationException();
        }
    }
}
