using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Domain.States.ReviewSprintState
{
    public interface IReviewSprintState
    {
        public void Start();
        public void Finish();
        public void StartReview();
        public void Close();
    }
}
