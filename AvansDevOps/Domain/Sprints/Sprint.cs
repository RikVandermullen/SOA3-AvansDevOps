using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Domain.Sprints
{
    public abstract class Sprint
    {
        protected string Name { get; set; }
        protected DateTime StartDate { get; set; }
        protected DateTime EndDate { get; set; }

        protected Sprint(string name, DateTime startDate, DateTime endDate) 
        {
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
        }

        public bool EndDateReached()
        {
            DateTime currentDate = DateTime.Now;
            return currentDate > EndDate;
        }
    }
}
