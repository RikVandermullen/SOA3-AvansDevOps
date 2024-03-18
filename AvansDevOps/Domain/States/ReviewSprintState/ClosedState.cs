using AvansDevOps.Domain.Sprints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Domain.States.ReviewSprintState
{
    public class ClosedState : IReviewSprintState
    {
        private ReviewSprint ReviewSprint { get; set; }

        public ClosedState(ReviewSprint reviewSprint)
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
            throw new InvalidOperationException();
        }
    }
}
