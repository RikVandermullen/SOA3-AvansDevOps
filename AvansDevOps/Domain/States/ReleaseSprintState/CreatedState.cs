using AvansDevOps.Domain.Sprints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Domain.States.ReleaseSprintState
{
    public class CreatedState : IReleaseSprintState
    {
        private ReleaseSprint ReleaseSprint { get; set; }

        public CreatedState(ReleaseSprint releaseSprint) 
        { 
            ReleaseSprint = releaseSprint;
        }

        public void Start()
        {
            ReleaseSprint.SetState(new DoingState(ReleaseSprint));
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
