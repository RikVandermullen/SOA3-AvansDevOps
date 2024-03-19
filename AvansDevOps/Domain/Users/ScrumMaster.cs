using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Domain.Users
{
    public class ScrumMaster : User
    {
        public ScrumMaster(string name, string emailAddress, string slackUsername) : base(name, emailAddress, slackUsername)
        {

        }
    }
}
