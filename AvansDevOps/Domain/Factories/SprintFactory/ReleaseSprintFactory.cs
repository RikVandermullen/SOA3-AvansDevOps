using AvansDevOps.Domain.Sprints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Domain.Factories.SprintFactory
{
    public class ReleaseSprintFactory : SprintFactory
    {
        public override Sprint CreateSprint(string name, DateTime startDate, DateTime endDate)
        {
            return new ReleaseSprint(name, startDate, endDate);
        }
    }
}
