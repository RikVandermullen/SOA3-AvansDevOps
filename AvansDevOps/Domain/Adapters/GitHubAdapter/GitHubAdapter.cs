using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Domain.Adapters.GitHubAdapter
{
    public class GitHubAdapter : IVersionControlAdapter
    {
        private readonly GitHubService _gitHubService = new GitHubService();

        public void Commit(string projectName, BacklogItem item)
        {
            SetRequiredData(projectName, item.Name, item.Developer.Name);
            _gitHubService.Commit();
        }

        public void Pull(string projectName)
        {
            _gitHubService.SetProjectName(projectName);
            _gitHubService.Pull();
        }

        public void Push(string ProjectName, BacklogItem item)
        {
            SetRequiredData(ProjectName, item.Name, item.Developer.Name);
            _gitHubService.Push();
        }

        public void SetRequiredData(string projectName, string backlogItemName, string developerName)
        {
            _gitHubService.SetProjectName(projectName);
            _gitHubService.SetBacklogItemName(backlogItemName);
            _gitHubService.SetDeveloperName(developerName);
        }
    }
}
