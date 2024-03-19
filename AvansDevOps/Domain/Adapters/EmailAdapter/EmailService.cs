using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Domain.Adapters.EmailAdapter
{
    public class EmailService
    {
        private string EmailAddress { get; set; }
        private string Name { get; set; }
        private string Message { get; set; }

        public void SetEmailAddress(String emailAddress)
        {
            EmailAddress = emailAddress;
        }

        public void SetName(String name)
        {
            Name = name;
        }

        public void SetMessage(String message)
        {
            Message = message;
        }

        public void SendEmail()
        {
            Console.WriteLine($"Sent a notification over Email to {Name}, at {EmailAddress}: '{Message}'.");
        }
    }
}
