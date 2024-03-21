using AvansDevOps.Domain.Visitors.PipelineVisitor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Domain.Composites.PipelineComposite
{
    public class Pipeline : PipelineComposite
    {
        public string Name { get; set; }
        
        public Pipeline(string name)
        {
            Name = name;
        }

        public override void AcceptVisitor(PipelineVisitor visitor)
        {
            visitor.VisitPipeline(this);
            base.AcceptVisitor(visitor);
        }
    }
}
