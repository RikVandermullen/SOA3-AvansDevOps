using AvansDevOps.Domain.Sprints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Domain.States.ReleaseSprintState
{
    public class FinishedState : IReleaseSprintState
    {
        private ReleaseSprint ReleaseSprint { get; set; }

        public FinishedState(ReleaseSprint releaseSprint)
        {
            ReleaseSprint = releaseSprint;
        }

        public void Start()
        {
            throw new InvalidOperationException();
        }

        public void Finish()
        {
            throw new InvalidOperationException();
        }

        public void Deploy()
        {
            ReleaseSprint.SetState(new DeployingState(ReleaseSprint));
        }

        public void Cancel()
        {
            ReleaseSprint.SetState(new CancelledState(ReleaseSprint));
        }

        public void Close()
        {
            throw new InvalidOperationException();
        }
    }
}
