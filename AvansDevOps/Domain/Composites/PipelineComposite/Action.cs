using AvansDevOps.Domain.Visitors.PipelineVisitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Domain.Composites.PipelineComposite
{
    public class Action : PipelineComponent
    {
        public string Command { get; set; }
        
        public Action (string command)
        {
            Command = command;
        }

        public override void AcceptVisitor(PipelineVisitor visitor)
        {
            visitor.VisitAction(this);
        }

    }
}
