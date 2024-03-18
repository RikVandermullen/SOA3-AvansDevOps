using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansDevOps.Domain.States;
using AvansDevOps.Domain.States.ReviewSprintState;

namespace AvansDevOps.Domain.Sprints
{
    public class ReviewSprint : Sprint
    {
        private IReviewSprintState ReviewSprintState { get; set; }
        public bool ReviewSummaryUploaded { get; private set; }

        public ReviewSprint(string name, DateTime startDate, DateTime endDate) : base(name, startDate, endDate)
        {
            ReviewSprintState = new CreatedState(this);
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
        }

        public override void SetState(ISprintState reviewSprintState)
        {
            ReviewSprintState = (IReviewSprintState) reviewSprintState;
        }

        public override void Close()
        {
            ReviewSprintState.Close();
        }

        public override void Finish()
        {
            ReviewSprintState.Finish();
        }

        public override void Start()
        {
            ReviewSprintState.Start();
        }

        public override void StartReview()
        {
            ReviewSprintState.StartReview();
        }

        public override void Cancel()
        {
            throw new NotImplementedException();
        }

        public override void Deploy()
        {
            throw new NotImplementedException();
        }
    }
}
