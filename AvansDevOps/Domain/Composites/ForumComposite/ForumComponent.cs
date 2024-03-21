using AvansDevOps.Domain.Visitors.ForumVisitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Domain.Composites.ForumComposite
{
    public abstract class ForumComponent
    {
        public abstract void AcceptVisitor(ForumVisitor visitor);
    }
}
