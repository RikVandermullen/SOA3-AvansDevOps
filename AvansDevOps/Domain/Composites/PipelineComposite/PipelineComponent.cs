using AvansDevOps.Domain.Visitors.PipelineVisitor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Domain.Composites.PipelineComposite
{
    public abstract class PipelineComponent
    {
        public abstract void AcceptVisitor(PipelineVisitor visitor);
    }
}
