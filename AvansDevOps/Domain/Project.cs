using AvansDevOps.Domain.Adapters;
using AvansDevOps.Domain.Composites.ForumComposite;
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

        public Project(string name, IVersionControlAdapter versionControl)
        {
            Name = name;
            BacklogItems = new List<BacklogItem>();
            Forum = new Forum();
            VersionControlService = new VersionControlService();
            VersionControl = versionControl;
        }

        public void AddBacklogItem(BacklogItem item)
        {
            BacklogItems.Add(item);
        }
    }
}
