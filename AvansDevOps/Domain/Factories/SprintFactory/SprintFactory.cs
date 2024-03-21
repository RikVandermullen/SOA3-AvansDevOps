using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansDevOps.Domain.Sprints;

namespace AvansDevOps.Domain.Factories.SprintFactory
{
    public abstract class SprintFactory
    {
        public abstract Sprint CreateSprint(string name, DateTime startDate, DateTime endDate);
    }
}
