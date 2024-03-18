using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansDevOps.Domain.Sprints;

namespace AvansDevOps.Domain.States.ReviewSprintState
{
    public class CreatedState : IReviewSprintState
    {
        private ReviewSprint ReviewSprint { get; set; }

        public CreatedState(ReviewSprint reviewSprint)
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
            ReviewSprint.SetState(new DoingState(ReviewSprint));
        }

        public void StartReview()
        {
            throw new InvalidOperationException();
        }
    }
}
