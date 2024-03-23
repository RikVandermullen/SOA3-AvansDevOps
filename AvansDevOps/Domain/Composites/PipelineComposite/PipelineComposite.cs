using AvansDevOps.Domain.Visitors.PipelineVisitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Domain.Composites.PipelineComposite
{
    public class PipelineComposite : PipelineComponent
    {
        private List<PipelineComponent> PipelineComponents;

        public PipelineComposite()
        {
            PipelineComponents = new List<PipelineComponent>();
        }

        public List<PipelineComponent> GetPipelineComponents()
        {
            return PipelineComponents;
        }

        public void AddPipelineComponent(PipelineComponent pipelineComponent)
        {
            PipelineComponents.Add(pipelineComponent);
        }

        public override void AcceptVisitor(PipelineVisitor visitor)
        {
            foreach (PipelineComponent pipelineComponent in PipelineComponents)
            {
                pipelineComponent.AcceptVisitor(visitor);
            }
        }
    }
}
