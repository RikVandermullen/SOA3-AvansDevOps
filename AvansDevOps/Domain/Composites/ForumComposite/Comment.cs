using AvansDevOps.Domain.Users;
using AvansDevOps.Domain.Visitors.ForumVisitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Domain.Composites.ForumComposite
{
    public class Comment : ForumComponent
    {
        public User Author;
        public string Text;
        public bool IsActive;

        public Comment(User author, string text)
        {
            Author = author;
            Text = text;
            IsActive = true;
        }

        public void Edit(string text, User user)
        {
            if (IsActive && Author == user)
            {
                Text = text;
            } else
            {
                Console.WriteLine("Cant edit comment.");
            }
        }

        public override void AcceptVisitor(ForumVisitor visitor)
        {
            visitor.VisitComment(this);
        }
    }
}
