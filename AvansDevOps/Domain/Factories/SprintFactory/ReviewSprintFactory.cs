using AvansDevOps.Domain.Sprints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Domain.Factories.SprintFactory
{
    public class ReviewSprintFactory : SprintFactory
    {
        public override Sprint CreateSprint(string name, DateTime startDate, DateTime endDate)
        {
            return new ReviewSprint(name, startDate, endDate);
        }
    }
}
