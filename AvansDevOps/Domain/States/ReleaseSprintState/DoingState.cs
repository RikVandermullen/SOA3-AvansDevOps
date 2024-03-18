using AvansDevOps.Domain.Sprints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Domain.States.ReleaseSprintState
{
    public class DoingState: IReleaseSprintState
    {
        private ReleaseSprint ReleaseSprint { get; set; }

        public DoingState(ReleaseSprint releaseSprint)
        {
            ReleaseSprint = releaseSprint;
        }

        public void Start()
        {
            throw new InvalidOperationException();
        }

        public void Finish()
        {
            if (!ReleaseSprint.EndDateReached())
            {
                throw new InvalidOperationException("Sprint end date has not yet been reached.");
            }
            ReleaseSprint.SetState(new FinishedState(ReleaseSprint));
        }

        public void Deploy()
        {
            throw new InvalidOperationException();
        }

        public void Cancel()
        {
            throw new InvalidOperationException();
        }

        public void Close()
        {
            throw new InvalidOperationException();
        }
    }
}
