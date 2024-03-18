using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Domain.States.BacklogItemState
{
    public class TestingState : IBacklogItemState
    {
        private BacklogItem BacklogItem { get; set; }

        public TestingState(BacklogItem backlogItem)
        {
            BacklogItem = backlogItem;
        }

        public void SetToToDo()
        {
            BacklogItem.SetState(new TodoState(BacklogItem));
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
            throw new InvalidOperationException();
        }

        public void SetToTested()
        {
            BacklogItem.SetState(new TestedState(BacklogItem));
        }

        public void SetToDone()
        {
            throw new InvalidOperationException();
        }
    }
}
