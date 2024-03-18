using AvansDevOps.Domain.Sprints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Domain.States.ReviewSprintState
{
    public class ReviewingState : IReviewSprintState
    {
        private ReviewSprint ReviewSprint { get; set; }

        public ReviewingState(ReviewSprint reviewSprint)
        {
            ReviewSprint = reviewSprint;
        }

        public void Close()
        {
            if (!ReviewSprint.ReviewSummaryUploaded)
            {
                throw new InvalidOperationException("Cant set to closed as no review summary has been uploaded");
            }

            ReviewSprint.SetState(new ClosedState(ReviewSprint));
        }

        public void Finish()
        {
            throw new InvalidOperationException();
        }

        public void Start()
        {
            throw new InvalidOperationException();
        }

        public void StartReview()
        {
            throw new InvalidOperationException();
        }
    }
}
