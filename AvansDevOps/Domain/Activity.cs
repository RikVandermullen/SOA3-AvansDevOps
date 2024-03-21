using AvansDevOps.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Domain
{
    public class Activity
    {
        public bool IsCompleted { get; set; }
        public string Name { get; set; }
        public Developer Developer { get; set; }

        public Activity(string name, Developer developer)
        {
            IsCompleted = false;
            Name = name;
            Developer = developer;
        }

        public void Complete()
        {
            IsCompleted = true;
        }
    }
}
