using AvansDevOps.Domain.Sprints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Domain.States.ReviewSprintState
{
    public class FinishedState : IReviewSprintState
    {
        private ReviewSprint ReviewSprint { get; set; }

        public FinishedState(ReviewSprint reviewSprint)
        {
            ReviewSprint = reviewSprint;
        }

        public void Close()
        {
            throw new InvalidOperationException();
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
            ReviewSprint.SetState(new ReviewingState(ReviewSprint));
        }
    }
}
