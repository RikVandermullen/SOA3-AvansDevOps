using AvansDevOps.Domain.States;
using AvansDevOps.Domain.States.ReleaseSprintState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Domain.Sprints
{
    public class ReleaseSprint : Sprint
    {
        private IReleaseSprintState ReleaseSprintState { get; set; }

        public ReleaseSprint(string name, DateTime startDate, DateTime endDate) : base(name, startDate, endDate)
        {
            ReleaseSprintState = new CreatedState(this);
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
        }

        public override void SetState(ISprintState releaseSprintState)
        {
            ReleaseSprintState = (IReleaseSprintState) releaseSprintState;
        }

        public override void Start()
        {
            ReleaseSprintState.Start();
        }

        public override void Finish()
        {
           ReleaseSprintState.Finish();
        }

        public override void Deploy()
        {
            ReleaseSprintState.Deploy();
        }

        public override void Cancel()
        {
            ReleaseSprintState.Cancel();
        }

        public override void Close()
        {
            ReleaseSprintState.Close();
        }

        public override void StartReview()
        {
            throw new NotImplementedException();
        }
    }
}
