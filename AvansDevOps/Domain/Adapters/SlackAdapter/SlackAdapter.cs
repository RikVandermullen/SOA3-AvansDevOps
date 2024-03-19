using AvansDevOps.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Domain.Adapters.SlackAdapter
{ 
    public class SlackAdapter : INotificationService
    {
        private SlackService SlackService = new SlackService();

        public void Send(User user, string message)
        {
            SlackService.SetUsername(user.SlackUsername);
            SlackService.SetName(user.Name);
            SlackService.SetMessage(message);
            SlackService.SendSlack();
        }
    }
}
