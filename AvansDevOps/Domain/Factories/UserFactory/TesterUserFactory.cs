using AvansDevOps.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Domain.Factories.UserFactory
{
    public class TesterUserFactory: UserFactory
    {
        public override User CreateUser(string name, string emailAddress, string slackUsername)
        {
            return new Tester(name, emailAddress, slackUsername);
        }
    }
}
