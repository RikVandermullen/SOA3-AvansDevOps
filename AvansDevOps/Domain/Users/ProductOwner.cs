﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Domain.Users
{
    public class ProductOwner : User
    {
        public ProductOwner(string name, string emailAddress, string slackUsername) : base(name, emailAddress, slackUsername)
        {

        }
    }
}
