using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Domain.Adapters.SlackAdapter
{
    public class SlackService
    {
        private string Username { get; set; } = null!;
        private string Name { get; set; } = null!;
        private string Message { get; set; } = null!;

        public void SetUsername(string username)
        {
            Username = username;
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public void SetMessage(string message)
        {
            Message = message;
        }

        public void SendSlack()
        {
            Console.WriteLine($"Sent a notification over Slack to {Name}, at {Username}: '{Message}'.");
        }
    }
}
