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
using AvansDevOps.Domain.States.ReviewSprintState;
using AvansDevOps.Domain.Composites.PipelineComposite;
using AvansDevOps.Domain.Visitors.PipelineVisitor;

namespace AvansDevOps.Tests
{
    public class F03_Tests
    {
        [Fact]
        public void F03_1_Should_CreateReviewSprintInProject()
        {
            // Arrange
            UserFactory factory = new ProductOwnerUserFactory();
            User po = factory.CreateUser("po", "po@mail.com", "po-slack");
            string name = "Test Project";
            var project = new Project(name, Mock.Of<IVersionControlAdapter>(), (ProductOwner)po);

            SprintFactory sprintFactory = new ReviewSprintFactory();
            Sprint sprint = sprintFactory.CreateSprint("test-sprint", new DateTime(2024, 3, 20), new DateTime(2024, 4, 10));

            // Act
            project.Sprints.Add(sprint);

            // Assert
            Assert.Single(project.Sprints);
        }

        [Fact]
        public void F03_2_Should_BeCreated()
        {
            // Arrange
            SprintFactory sprintFactory = new ReviewSprintFactory();

            // Act
            ReviewSprint sprint = (ReviewSprint)sprintFactory.CreateSprint("test-sprint", new DateTime(2024, 3, 20), new DateTime(2024, 4, 10));

            // Assert
            Assert.IsType<CreatedState>(sprint.ReviewSprintState);
        }

        [Fact]
        public void F03_2_Should_BeDoing()
        {
            // Arrange
            SprintFactory sprintFactory = new ReviewSprintFactory();
            ReviewSprint sprint = (ReviewSprint)sprintFactory.CreateSprint("test-sprint", new DateTime(2024, 3, 20), new DateTime(2024, 4, 10));

            // Act
            sprint.Start();

            // Assert
            Assert.IsType<DoingState>(sprint.ReviewSprintState);
        }

        [Fact]
        public void F03_2_Should_BeFinished()
        {
            // Arrange
            SprintFactory sprintFactory = new ReviewSprintFactory();
            ReviewSprint sprint = (ReviewSprint)sprintFactory.CreateSprint("test-sprint", new DateTime(2024, 3, 20), new DateTime(2024, 2, 10));

            // Act
            sprint.Start();
            sprint.Finish();

            // Assert
            Assert.IsType<FinishedState>(sprint.ReviewSprintState);
        }

        [Fact]
        public void F03_2_Should_BeReviewing()
        {
            // Arrange
            SprintFactory sprintFactory = new ReviewSprintFactory();
            ReviewSprint sprint = (ReviewSprint)sprintFactory.CreateSprint("test-sprint", new DateTime(2024, 3, 20), new DateTime(2024, 2, 10));

            // Act
            sprint.Start();
            sprint.Finish();
            sprint.StartReview();

            // Assert
            Assert.IsType<ReviewingState>(sprint.ReviewSprintState);
        }

        [Fact]
        public void F03_2_Should_BeClosed()
        {
            // Arrange
            SprintFactory sprintFactory = new ReviewSprintFactory();
            ReviewSprint sprint = (ReviewSprint)sprintFactory.CreateSprint("test-sprint", new DateTime(2024, 3, 20), new DateTime(2024, 2, 10));

            // Act
            sprint.Start();
            sprint.Finish();
            sprint.StartReview();
            sprint.ReviewSummaryUploaded = true;
            sprint.Close();

            // Assert
            Assert.IsType<ClosedState>(sprint.ReviewSprintState);
        }

        [Fact]
        public void F03_3_Should_ThrowWhenFinishingWithoutValidEnddate()
        {
            // Arrange
            SprintFactory sprintFactory = new ReviewSprintFactory();
            ReviewSprint sprint = (ReviewSprint)sprintFactory.CreateSprint("test-sprint", new DateTime(2024, 3, 20), new DateTime(2024, 4, 20));

            // Act & Assert
            sprint.Start();
            Assert.Throws<InvalidOperationException>(() => sprint.Finish());
        }

        [Fact]
        public void F03_4_Should_ThrowWhenClosedWithoutUploadingReview()
        {
            // Arrange
            SprintFactory sprintFactory = new ReviewSprintFactory();
            ReviewSprint sprint = (ReviewSprint)sprintFactory.CreateSprint("test-sprint", new DateTime(2024, 3, 20), new DateTime(2024, 2, 20));

            // Act & Assert
            sprint.Start();
            sprint.Finish();
            sprint.StartReview();
            Assert.Throws<InvalidOperationException>(() => sprint.Close());
        }

        [Fact]
        public void Should_ThrowCreatedToInvalidState()
        {
            // Arrange
            SprintFactory sprintFactory = new ReviewSprintFactory();
            ReviewSprint sprint = (ReviewSprint)sprintFactory.CreateSprint("test-sprint", new DateTime(2024, 3, 20), new DateTime(2024, 2, 20));

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => sprint.Finish());
            Assert.Throws<InvalidOperationException>(() => sprint.StartReview());
            Assert.Throws<InvalidOperationException>(() => sprint.Close());
        }

        [Fact]
        public void Should_ThrowDoingToInvalidState()
        {
            // Arrange
            SprintFactory sprintFactory = new ReviewSprintFactory();
            ReviewSprint sprint = (ReviewSprint)sprintFactory.CreateSprint("test-sprint", new DateTime(2024, 3, 20), new DateTime(2024, 2, 20));

            // Act
            sprint.Start();

            // Assert
            Assert.Throws<InvalidOperationException>(() => sprint.StartReview());
            Assert.Throws<InvalidOperationException>(() => sprint.Close());
        }

        [Fact]
        public void Should_ThrowFinishedToInvalidState()
        {
            // Arrange
            SprintFactory sprintFactory = new ReviewSprintFactory();
            ReviewSprint sprint = (ReviewSprint)sprintFactory.CreateSprint("test-sprint", new DateTime(2024, 3, 20), new DateTime(2024, 2, 20));

            // Act
            sprint.Start();
            sprint.Finish();

            // Assert
            Assert.Throws<InvalidOperationException>(() => sprint.Start());
            Assert.Throws<InvalidOperationException>(() => sprint.Close());
        }

        [Fact]
        public void Should_ThrowReviewingToInvalidState()
        {
            // Arrange
            SprintFactory sprintFactory = new ReviewSprintFactory();
            ReviewSprint sprint = (ReviewSprint)sprintFactory.CreateSprint("test-sprint", new DateTime(2024, 3, 20), new DateTime(2024, 2, 20));

            // Act
            sprint.Start();
            sprint.Finish();
            sprint.StartReview();

            // Assert
            Assert.Throws<InvalidOperationException>(() => sprint.Start());
            Assert.Throws<InvalidOperationException>(() => sprint.Finish());
        }

        [Fact]
        public void Should_ThrowClosedToInvalidState()
        {
            // Arrange
            SprintFactory sprintFactory = new ReviewSprintFactory();
            ReviewSprint sprint = (ReviewSprint)sprintFactory.CreateSprint("test-sprint", new DateTime(2024, 3, 20), new DateTime(2024, 2, 20));
            sprint.ReviewSummaryUploaded = true;

            // Act
            sprint.Start();
            sprint.Finish();
            sprint.StartReview();
            sprint.Close();

            // Assert
            Assert.Throws<InvalidOperationException>(() => sprint.Start());
            Assert.Throws<InvalidOperationException>(() => sprint.Finish());
            Assert.Throws<InvalidOperationException>(() => sprint.StartReview());
        }

    }
}
