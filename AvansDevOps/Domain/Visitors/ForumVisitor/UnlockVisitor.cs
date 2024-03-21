using AvansDevOps.Domain.Composites.ForumComposite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Domain.Visitors.ForumVisitor
{
    public class UnlockVisitor : ForumVisitor
    {
        public override void VisitComment(Comment comment)
        {
            comment.IsActive = true;
        }

        public override void VisitForum(Forum forum) { }

        public override void VisitThread(Composites.ForumComposite.Thread thread)
        {
            Console.WriteLine($"{thread.Name} Unlocked");
            thread.IsActive = true;
        }
    }
}
