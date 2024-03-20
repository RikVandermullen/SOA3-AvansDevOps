using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansDevOps.Domain.Composites.PipelineComposite;
using Action = AvansDevOps.Domain.Composites.PipelineComposite.Action;

namespace AvansDevOps.Domain.Visitors.PipelineVisitor
{
    public abstract class PipelineVisitor
    {
        public abstract void VisitPipeline(Pipeline pipeline);
        public abstract void VisitCategory(Category category);
        public abstract void VisitAction(Action action);
    }
}
