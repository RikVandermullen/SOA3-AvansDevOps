using AvansDevOps.Domain.Sprints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Domain.States.ReleaseSprintState
{
    public class ClosedState : IReleaseSprintState
    {
        private ReleaseSprint ReleaseSprint { get; set; }

        public ClosedState(ReleaseSprint releaseSprint)
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
