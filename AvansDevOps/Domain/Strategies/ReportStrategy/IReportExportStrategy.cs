using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Domain.Strategy.ReportStrategy
{
    public interface IReportExportStrategy
    {
        public void Export(Report report);
    }
}
