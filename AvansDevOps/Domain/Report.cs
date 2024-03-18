using AvansDevOps.Domain.Strategy.ReportStrategy;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Domain
{
    public class Report
    {
        private IReportExportStrategy ExportStrategy { get; set; }
        public string CompanyName { get; private set; }
        public string ProjectName { get; private set; }
        public string Version { get; private set; }
        public DateTime Date { get; private set; }
        

        public Report(string companyName, string projectName, string version, DateTime date)
        {
            CompanyName = companyName;
            ProjectName = projectName;
            Version = version;
            Date = date;
        }

        public void SetExportStrategy(IReportExportStrategy reportExportStrategy) 
        {
            ExportStrategy = reportExportStrategy;
        }

        public void Export()
        {
            ExportStrategy.Export(this);
        }
    }
}
