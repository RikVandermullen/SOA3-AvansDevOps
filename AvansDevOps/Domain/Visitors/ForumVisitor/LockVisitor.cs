using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AvansDevOps.Domain.Composites.ForumComposite;
using Thread = AvansDevOps.Domain.Composites.ForumComposite.Thread;

namespace AvansDevOps.Domain.Visitors.ForumVisitor
{
    public class LockVisitor : ForumVisitor
    {
        public override void VisitComment(Comment comment)
        {
            comment.IsActive = false;
        }

        public override void VisitForum(Forum forum) { }

        public override void VisitThread(Thread thread)
        {
            Console.WriteLine($"{thread.Name} Locked");
            thread.IsActive = false;
        }
    }
}
