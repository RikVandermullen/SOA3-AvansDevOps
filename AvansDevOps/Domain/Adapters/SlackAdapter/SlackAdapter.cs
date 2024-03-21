using AvansDevOps.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Domain.Adapters.SlackAdapter
{ 
    public class SlackAdapter : INotificationAdapter
    {
        private readonly SlackService _slackService = new SlackService();

        public void Send(User user, string message)
        {
            _slackService.SetUsername(user.SlackUsername);
            _slackService.SetName(user.Name);
            _slackService.SetMessage(message);
            _slackService.SendSlack();
        }
    }
}
