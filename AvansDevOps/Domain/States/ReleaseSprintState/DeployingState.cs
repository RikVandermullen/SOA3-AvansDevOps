using AvansDevOps.Domain.Sprints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Domain.States.ReleaseSprintState
{
    public class DeployingState : IReleaseSprintState
    {
        private ReleaseSprint ReleaseSprint { get; set; }

        public DeployingState(ReleaseSprint releaseSprint)
        {
            ReleaseSprint = releaseSprint;
        }

        public void Start()
        {
            throw new InvalidOperationException();
        }

        public void Finish()
        {
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
            ReleaseSprint.SetState(new ClosedState(ReleaseSprint));
        }
    }
}
