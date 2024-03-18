using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Domain
{
    public class Activity
    {
        public bool IsCompleted { get; private set; }

        public Activity()
        {
            IsCompleted = false;
        }
    }
}
