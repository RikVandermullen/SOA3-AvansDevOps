using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Domain.Adapters.AzureAdapter
{
    public class AzureAdapter: IVersionControlAdapter
    {
        private readonly AzureService _azureService = new AzureService();

        public void Commit(string projectName, BacklogItem item)
        {
            SetRequiredData(projectName, item.Name, item.Developer.Name);
            _azureService.Commit();
        }

        public void Pull(string projectName)
        {
            _azureService.SetProjectName(projectName);
            _azureService.Pull();
        }

        public void Push(string ProjectName, BacklogItem item)
        {
            SetRequiredData(ProjectName, item.Name, item.Developer.Name);
            _azureService.Push();
        }

        public void SetRequiredData(string projectName, string backlogItemName, string developerName)
        {
            _azureService.SetProjectName(projectName);
            _azureService.SetBacklogItemName(backlogItemName);
            _azureService.SetDeveloperName(developerName);
        }
    }
}
