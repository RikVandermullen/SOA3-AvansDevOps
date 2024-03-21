using AvansDevOps.Domain.Adapters;
using AvansDevOps.Domain.Composites.ForumComposite;
using AvansDevOps.Domain.Composites.PipelineComposite;
using AvansDevOps.Domain.Sprints;
using AvansDevOps.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
