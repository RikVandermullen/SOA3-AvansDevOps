using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansDevOps.Domain.Composites.ForumComposite;
using Thread = AvansDevOps.Domain.Composites.ForumComposite.Thread;

namespace AvansDevOps.Domain.Visitors.ForumVisitor
{
    public abstract class ForumVisitor
    {
        public abstract void VisitForum(Forum forum);
        public abstract void VisitThread(Thread thread);
        public abstract void VisitComment(Comment comment);
    }
}
