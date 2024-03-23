using AvansDevOps.Domain.Adapters;
using AvansDevOps.Domain.Composites.ForumComposite;
using AvansDevOps.Domain.Composites.PipelineComposite;
using AvansDevOps.Domain.Factories.SprintFactory;
using AvansDevOps.Domain.Sprints;
using AvansDevOps.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Action = AvansDevOps.Domain.Composites.PipelineComposite.Action;

namespace AvansDevOps.Domain
{
    public class Project
    {
        public string Name { get; set; }
        public List<BacklogItem> BacklogItems { get; set; }
        public Forum Forum { get; set; }
        public VersionControlService VersionControlService { get; set; }
        public IVersionControlAdapter VersionControl { get; set; }
        public ProductOwner ProductOwner { get; set; }
        public Pipeline Pipeline { get; set; } = null!;
        public List<Sprint> Sprints { get; set; }

        public Project(string name, IVersionControlAdapter versionControl, ProductOwner productOwner)
        {
            Name = name;
            BacklogItems = new List<BacklogItem>();
            Forum = new Forum();
            VersionControlService = new VersionControlService();
            VersionControl = versionControl;
            ProductOwner = productOwner;
            Sprints = new List<Sprint>();
        }

        public void AddBacklogItem(BacklogItem item)
        {
            BacklogItems.Add(item);
        }

        public void CreateSprint(SprintFactory factory, string name, DateTime startDate, DateTime endDate)
        {
            if (factory == null)
            {
                throw new ArgumentNullException();
            }

            if (factory is ReleaseSprintFactory)
            {
                Sprints.Add(factory.CreateSprint(name, startDate, endDate));
            }

            if (factory is ReviewSprintFactory)
            {
                Sprints.Add(factory.CreateSprint(name, startDate, endDate));
            }
        }

        public void CreatePipeline(string name, Dictionary<Category, List<Action>> pipelineComponents)
        {
            Pipeline = new Pipeline(name);

            foreach (var component in pipelineComponents)
            {
                Category category = component.Key;
                List<Action> actions = component.Value;
                Pipeline.AddPipelineComponent(component.Key);
                
                foreach (var action in actions)
                {
                    category.AddPipelineComponent(action);
                }
            }
        }
    }
}
