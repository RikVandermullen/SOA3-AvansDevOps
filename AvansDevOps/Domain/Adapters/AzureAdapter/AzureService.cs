using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Domain.Adapters.AzureAdapter
{
    public class AzureService
    {
        private string AzureProjectName { get; set; } = null!;
        private string AzureBacklogItemName { get; set; } = null!;
        private string AzureDeveloperName { get; set; } = null!;

        public void SetProjectName(string name)
        {
            AzureProjectName = name;
        }

        public void SetBacklogItemName(string name)
        {
            AzureBacklogItemName = name;
        }

        public void SetDeveloperName(string name)
        {
            AzureDeveloperName = name;
        }

        public void Commit()
        {
            Console.WriteLine($"[Project: {AzureProjectName}]: {AzureDeveloperName} committed {AzureBacklogItemName} to Azure repository");
        }

        public void Push()
        {
            Console.WriteLine($"[Project: {AzureProjectName}]: {AzureDeveloperName} pushed {AzureBacklogItemName} to Azure repository");
        }

        public void Pull()
        {
            Console.WriteLine($"[Project: {AzureProjectName}]: pulled from Azure repository");
        }
    }
}
