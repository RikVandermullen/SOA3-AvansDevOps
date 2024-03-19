using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Domain.Users
{
    public class Developer : User
    {
        public bool IsSenior { get; set; }

        public Developer(string name, string emailAddress, string slackUsername) : base(name, emailAddress, slackUsername)
        {
            IsSenior = false;
        }

        public void SetIsSenior(bool isSenior)
        {
            IsSenior = isSenior;
        }
    }
}
