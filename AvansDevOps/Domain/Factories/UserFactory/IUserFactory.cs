using AvansDevOps.Domain.Sprints;
using AvansDevOps.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Domain.Factories.UserFactory
{
    public interface IUserFactory
    {
        public User CreateUser(string name, string emailAddress, string slackUsername);
    }
}
