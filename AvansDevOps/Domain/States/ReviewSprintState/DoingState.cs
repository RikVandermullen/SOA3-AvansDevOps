using AvansDevOps.Domain.Sprints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Domain.States.ReviewSprintState
{
    public class DoingState : IReviewSprintState
    {
        private ReviewSprint ReviewSprint { get; set; }

        public DoingState(ReviewSprint reviewSprint)
        {
            ReviewSprint = reviewSprint;
        }

        public void Close()
        {
            throw new InvalidOperationException();
        }

        public void Finish()
        {
            if (!ReviewSprint.EndDateReached())
            {
                throw new InvalidOperationException("Sprint end date has not yet been reached.");
            }

            ReviewSprint.SetState(new FinishedState(ReviewSprint));
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
