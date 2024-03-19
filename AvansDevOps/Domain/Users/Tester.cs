using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Domain.Users
{
    public class Tester : User
    {
        public Tester(string name, string emailAddress, string slackUsername) : base(name, emailAddress, slackUsername)
        {

        }
    }
}
