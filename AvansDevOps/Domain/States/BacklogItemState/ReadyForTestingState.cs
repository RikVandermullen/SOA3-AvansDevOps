using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Domain.States.BacklogItemState
{
    public class ReadyForTestingState : IBacklogItemState
    {
        private BacklogItem BacklogItem { get; set; }

        public ReadyForTestingState(BacklogItem backlogItem)
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
            throw new InvalidOperationException();
        }

        public void SetToTesting()
        {
            BacklogItem.SetState(new TestingState(BacklogItem));
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
