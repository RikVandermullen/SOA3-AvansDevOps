using AvansDevOps.Domain.Adapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Domain
{
    public class VersionControlService
    {
        public void Commit(string projectName, BacklogItem item, IVersionControlAdapter versionControl)
        {
            versionControl.Commit(projectName, item);
        }

        public void Push(string projectName, BacklogItem item, IVersionControlAdapter versionControl)
        {
            versionControl.Push(projectName, item);
        }

        public void Pull(string projectName, IVersionControlAdapter versionControl)
        {
            versionControl.Pull(projectName);
        }
    }
}
