using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Domain.States.BacklogItemState
{
    public interface IBacklogItemState
    {
        public void SetToToDo();
        public void SetToDoing();
        public void SetToReadyForTesting();
        public void SetToTesting();
        public void SetToTested();
        public void SetToDone();
    }
}
