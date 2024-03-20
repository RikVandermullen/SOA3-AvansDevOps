using AvansDevOps.Domain.Visitors.PipelineVisitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Domain.Composites.PipelineComposite
{
    public class Category : PipelineComposite
    {
        public string Name { get; set; }

        public Category(string name)
        {
            Name = name;
        }

        public override void AcceptVisitor(PipelineVisitor visitor)
        {
            visitor.VisitCategory(this);
            base.AcceptVisitor(visitor);
        }
    }
}
