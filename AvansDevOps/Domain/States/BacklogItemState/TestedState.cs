using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Domain.States.BacklogItemState
{
    public class TestedState : IBacklogItemState
    {
        private BacklogItem BacklogItem { get; set; }

        public TestedState(BacklogItem backlogItem)
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
            if (!BacklogItem.CheckActivitiesDone())
            {
                throw new InvalidOperationException("Cant set to done as not all activities have been completed");
            }

            BacklogItem.SetState(new DoneState(BacklogItem));
        }
    }
}
