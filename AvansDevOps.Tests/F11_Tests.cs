using AvansDevOps.Domain;
using AvansDevOps.Domain.Strategy.ReportStrategy;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Tests
{
    public class F11_Tests
    {
        [Fact]
        public void F11_1_Should_ExportReport()
        {
            // Arrange
            Report report = new Report("Avans", "Avans Project 1", "V1.0", DateTime.Now);
            var mockExportStrategy = new Mock<IReportExportStrategy>();
            report.SetExportStrategy(mockExportStrategy.Object);

            // Act
            report.Export();

            // Assert
            mockExportStrategy.Verify(strategy => strategy.Export(report), Times.Once());
        }
    }
}
