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
        private string Name { get; set; }
        private List<BacklogItem> BacklogItems { get; set; }
        public Forum Forum { get; set; }

        public Project(string name)
        {
            Name = name;
            BacklogItems = new List<BacklogItem>();
            Forum = new Forum();
        }
    }
}
