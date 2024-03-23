using AvansDevOps.Domain.Adapters;
using AvansDevOps.Domain.Factories.UserFactory;
using AvansDevOps.Domain.Users;
using AvansDevOps.Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansDevOps.Domain.Factories.SprintFactory;
using AvansDevOps.Domain.Sprints;
using AvansDevOps.Domain.States.ReleaseSprintState;
using AvansDevOps.Domain.Composites.PipelineComposite;
using AvansDevOps.Domain.Visitors.PipelineVisitor;

namespace AvansDevOps.Tests
{
    public class F04_Tests
    {
        [Fact]
        public void F04_1_Should_AddReleaseSprintInProject()
        {
            // Arrange
            UserFactory factory = new ProductOwnerUserFactory();
            User po = factory.CreateUser("po", "po@mail.com", "po-slack");
            string name = "Test Project";

            var project = new Project(name, Mock.Of<IVersionControlAdapter>(), (ProductOwner)po);

            SprintFactory sprintFactory = new ReleaseSprintFactory();
            Sprint sprint = sprintFactory.CreateSprint("test sprint", new DateTime(2024, 3, 23), new DateTime(2024, 3, 31));

            // Act
            project.Sprints.Add(sprint);

            // Assert
            Assert.Single(project.Sprints);
        }

        [Fact]
        public void F04_2_Should_BeCreated()
        {
            // Arrange
            SprintFactory sprintFactory = new ReleaseSprintFactory();

            // Act
            ReleaseSprint sprint = (ReleaseSprint)sprintFactory.CreateSprint("test sprint", new DateTime(2024, 3, 23), new DateTime(2024, 3, 31));

            // Assert
            Assert.IsType<CreatedState>(sprint.ReleaseSprintState);
        }

        [Fact]
        public void F04_2_Should_BeDoing()
        {
            // Arrange
            SprintFactory sprintFactory = new ReleaseSprintFactory();
            ReleaseSprint sprint = (ReleaseSprint)sprintFactory.CreateSprint("test sprint", new DateTime(2024, 3, 23), new DateTime(2024, 3, 31));

            // Act
            sprint.Start();

            // Assert
            Assert.IsType<DoingState>(sprint.ReleaseSprintState);
        }

        [Fact]
        public void F04_2_Should_BeFinished()
        {
            // Arrange
            SprintFactory sprintFactory = new ReleaseSprintFactory();
            ReleaseSprint sprint = (ReleaseSprint)sprintFactory.CreateSprint("test sprint", new DateTime(2024, 3, 23), new DateTime(2024, 3, 23));

            // Act
            sprint.Start();
            sprint.Finish();

            // Assert
            Assert.IsType<FinishedState>(sprint.ReleaseSprintState);
        }

        [Fact]
        public void F04_2_Should_BeDeploying()
        {
            // Arrange
            SprintFactory sprintFactory = new ReleaseSprintFactory();
            ReleaseSprint sprint = (ReleaseSprint)sprintFactory.CreateSprint("test sprint", new DateTime(2024, 2, 23), new DateTime(2024, 2, 25));

            // Act
            sprint.Start();
            sprint.Finish();
            sprint.Deploy();

            // Assert
            Assert.IsType<DeployingState>(sprint.ReleaseSprintState);
        }

        [Fact]
        public void F04_2_Should_BeClosed()
        {
            // Arrange
            SprintFactory sprintFactory = new ReleaseSprintFactory();
            ReleaseSprint sprint = (ReleaseSprint)sprintFactory.CreateSprint("test sprint", new DateTime(2024, 2, 23), new DateTime(2024, 2, 25));

            // Act
            sprint.Start();
            sprint.Finish();
            sprint.Deploy();
            sprint.Close();

            // Assert
            Assert.IsType<ClosedState>(sprint.ReleaseSprintState);
        }

        [Fact]
        public void F04_2_Should_BeCancelled()
        {
            // Arrange
            SprintFactory sprintFactory = new ReleaseSprintFactory();
            ReleaseSprint sprint = (ReleaseSprint)sprintFactory.CreateSprint("test sprint", new DateTime(2024, 2, 23), new DateTime(2024, 2, 25));

            // Act
            sprint.Start();
            sprint.Finish();
            sprint.Cancel();

            // Assert
            Assert.IsType<CancelledState>(sprint.ReleaseSprintState);
        }

        [Fact]
        public void F04_2_Should_ThrowWhenFinishingWithoutValidEndDate()
        {
            // Arrange
            SprintFactory sprintFactory = new ReleaseSprintFactory();
            ReleaseSprint sprint = (ReleaseSprint)sprintFactory.CreateSprint("test sprint", new DateTime(2024, 3, 10), new DateTime(2024, 4, 20));

            // Act & Assert
            sprint.Start();
            Assert.Throws<InvalidOperationException>(() => sprint.Finish());
        }
    }
}
