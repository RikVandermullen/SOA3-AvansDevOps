using AvansDevOps.Domain.Visitors.ForumVisitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Domain.Composites.ForumComposite
{
    public class Forum : ForumComposite
    {
        public Forum() { }

        public override void AcceptVisitor(ForumVisitor visitor)
        {
            visitor.VisitForum(this);
            base.AcceptVisitor(visitor);
        }
    }
}
