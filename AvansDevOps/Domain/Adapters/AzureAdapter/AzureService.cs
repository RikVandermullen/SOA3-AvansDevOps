using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Domain.Adapters.AzureAdapter
{
    public class AzureService
    {
        private string ProjectName { get; set; } = null!;
        private string BacklogItemName { get; set; } = null!;
        private string DeveloperName { get; set; } = null!;

        public void SetProjectName(string name)
        {
            ProjectName = name;
        }

        public void SetBacklogItemName(string name)
        {
            BacklogItemName = name;
        }

        public void SetDeveloperName(string name)
        {
            DeveloperName = name;
        }

        public void Commit()
        {
            Console.WriteLine($"[Project: {ProjectName}]: {DeveloperName} committed {BacklogItemName} to Azure repository");
        }

        public void Push()
        {
            Console.WriteLine($"[Project: {ProjectName}]: {DeveloperName} pushed {BacklogItemName} to Azure repository");
        }

        public void Pull()
        {
            Console.WriteLine($"[Project: {ProjectName}]: pulled from Azure repository");
        }
    }
}
