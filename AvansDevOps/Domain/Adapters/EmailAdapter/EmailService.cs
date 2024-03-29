﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Domain.Adapters.EmailAdapter
{
    public class EmailService
    {
        private string EmailAddress { get; set; } = null!;
        private string Name { get; set; } = null!;
        private string Message { get; set; } = null!;

        public void SetEmailAddress(string emailAddress)
        {
            EmailAddress = emailAddress;
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public void SetMessage(string message)
        {
            Message = message;
        }

        public void SendEmail()
        {
            Console.WriteLine($"Sent a notification over Email to {Name}, at {EmailAddress}: '{Message}'.");
        }
    }
}
