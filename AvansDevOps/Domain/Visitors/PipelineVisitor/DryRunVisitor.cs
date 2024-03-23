using AvansDevOps.Domain.Composites.PipelineComposite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Action = AvansDevOps.Domain.Composites.PipelineComposite.Action;

namespace AvansDevOps.Domain.Visitors.PipelineVisitor
{
    public class DryRunVisitor : PipelineVisitor
    {
        public override void VisitAction(Action action)
        {
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine($"- Simulating action: {action.Command}");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~");
        }

        public override void VisitCategory(Category category)
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine($"Starting category: {category.Name}");
            Console.WriteLine("---------------------------");
        }

        public override void VisitPipeline(Pipeline pipeline)
        {
            Console.WriteLine($"~~~ Starting Dry-Run of Pipeline: {pipeline.Name} ~~~");
            Console.WriteLine("========================== \n");
        }
    }
}
