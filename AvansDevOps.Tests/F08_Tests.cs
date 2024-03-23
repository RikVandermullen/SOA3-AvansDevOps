using AvansDevOps.Domain.Adapters;
using AvansDevOps.Domain.Factories.SprintFactory;
using AvansDevOps.Domain.Factories.UserFactory;
using AvansDevOps.Domain.Sprints;
using AvansDevOps.Domain.Users;
using AvansDevOps.Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansDevOps.Domain.Adapters.GitHubAdapter;

namespace AvansDevOps.Tests
{
    public class F08_Tests
    {
        [Fact]
        public void F08_1_Should_PushBacklogItemsInSCM()
        {
            // Arrange
            UserFactory factory = new ProductOwnerUserFactory();
            User po = factory.CreateUser("po", "po@mail.com", "po-slack");

            UserFactory userFactory = new DeveloperUserFactory();
            User dev1 = userFactory.CreateUser("dev1", "dev1@mail", "dev1slack");

            string name = "Test Project";

            var mockService = new Mock<IVersionControlAdapter>();
            var project = new Project(name, mockService.Object, (ProductOwner)po);

            SprintFactory sprintFactory = new ReleaseSprintFactory();
            Sprint sprint = sprintFactory.CreateSprint("test sprint", new DateTime(2024, 3, 23), new DateTime(2024, 3, 31));
            BacklogItem backlogItem = new BacklogItem((Developer)dev1, sprint, "UserAuthorizationFunctionality");

            // Act
            project.VersionControl.Push(name, backlogItem);

            // Assert
            mockService.Verify(service => service.Push(name, backlogItem), Times.Once());
        }

        [Fact]
        public void F08_1_Should_CommitBacklogItemsInSCM()
        {
            // Arrange
            UserFactory factory = new ProductOwnerUserFactory();
            User po = factory.CreateUser("po", "po@mail.com", "po-slack");

            UserFactory userFactory = new DeveloperUserFactory();
            User dev1 = userFactory.CreateUser("dev1", "dev1@mail", "dev1slack");

            string name = "Test Project";

            var mockService = new Mock<IVersionControlAdapter>();
            var project = new Project(name, mockService.Object, (ProductOwner)po);

            SprintFactory sprintFactory = new ReleaseSprintFactory();
            Sprint sprint = sprintFactory.CreateSprint("test sprint", new DateTime(2024, 3, 23), new DateTime(2024, 3, 31));
            BacklogItem backlogItem = new BacklogItem((Developer)dev1, sprint, "UserAuthorizationFunctionality");

            // Act
            project.VersionControl.Commit(name, backlogItem);

            // Assert
            mockService.Verify(service => service.Commit(name, backlogItem), Times.Once());
        }

        [Fact]
        public void F08_1_Should_PullBacklogItemsInSCM()
        {
            // Arrange
            UserFactory factory = new ProductOwnerUserFactory();
            User po = factory.CreateUser("po", "po@mail.com", "po-slack");

            UserFactory userFactory = new DeveloperUserFactory();
            User dev1 = userFactory.CreateUser("dev1", "dev1@mail", "dev1slack");

            string name = "Test Project";

            var mockService = new Mock<IVersionControlAdapter>();
            var project = new Project(name, mockService.Object, (ProductOwner)po);

            // Act
            project.VersionControl.Pull(name);

            // Assert
            mockService.Verify(service => service.Pull(name), Times.Once());
        }
    }
}
