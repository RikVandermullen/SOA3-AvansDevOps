using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansDevOps.Domain.States.BacklogItemState;
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

        public void SetState(IReviewSprintState reviewSprintState)
        {
            ReviewSprintState = reviewSprintState;
        }

        public void Close()
        {
            ReviewSprintState.Close();
        }

        public void Finish()
        {
            ReviewSprintState.Finish();
        }

        public override void Start()
        {
            ReviewSprintState.Start();
        }

        public void StartReview()
        {
            ReviewSprintState.StartReview();
        }
    }
}
