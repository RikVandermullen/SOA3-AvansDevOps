using AvansDevOps.Domain.Composites.PipelineComposite;
using AvansDevOps.Domain.Visitors.ForumVisitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Domain.Composites.ForumComposite
{
    public class ForumComposite : ForumComponent
    {
        private List<ForumComponent> ForumComponents;

        public ForumComposite()
        {
            ForumComponents = new List<ForumComponent>();
        }

        public virtual void AddForumComponent(ForumComponent forumComponent)
        {
            ForumComponents.Add(forumComponent);
        }

        public override void AcceptVisitor(ForumVisitor visitor)
        {
            foreach (ForumComponent forumComponent in ForumComponents)
            {
                forumComponent.AcceptVisitor(visitor);
            }
        }

        public ForumComponent GetLastForumComponent()
        {
            return ForumComponents[ForumComponents.Count - 1];
        }
    }
}
