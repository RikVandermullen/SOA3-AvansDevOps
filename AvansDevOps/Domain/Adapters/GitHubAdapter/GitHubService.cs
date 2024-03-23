using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Domain.Adapters.GitHubAdapter
{
    public class GitHubService
    {
        private string GitHubProjectName { get; set; } = null!;
        private string GitHubBacklogItemName { get; set; } = null!;
        private string GitHubDeveloperName { get; set; } = null!;

        public void SetProjectName(string name)
        {
            GitHubProjectName = name;
        }

        public void SetBacklogItemName(string name)
        {
            GitHubBacklogItemName = name;
        }

        public void SetDeveloperName(string name)
        {
            GitHubDeveloperName = name;
        }

        public void Commit()
        {
            Console.WriteLine($"[Project: {GitHubProjectName}]: {GitHubDeveloperName} committed {GitHubBacklogItemName} to GitHub repository");
        }

        public void Push()
        {
            Console.WriteLine($"[Project: {GitHubProjectName}]: {GitHubDeveloperName} pushed {GitHubBacklogItemName} to GitHub repository");
        }

        public void Pull()
        {
            Console.WriteLine($"[Project: {GitHubProjectName}]: pulled from GitHub repository");
        }
    }
}
