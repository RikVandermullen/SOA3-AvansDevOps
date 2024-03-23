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

namespace AvansDevOps.Tests
{
    public class F02_Tests
    {
        [Fact]
        public void F02_1_Should_AddBacklogItemsToProject()
        {
            // Arrange
            UserFactory factory = new ProductOwnerUserFactory();
            User po = factory.CreateUser("po", "po@mail.com", "po-slack");

            UserFactory userFactory = new DeveloperUserFactory();
            User dev1 = userFactory.CreateUser("dev1", "dev1@mail", "dev1slack");

            SprintFactory sprintFactory = new ReleaseSprintFactory();
            Sprint sprint = sprintFactory.CreateSprint("test sprint", new DateTime(2024,3,23), new DateTime(2024, 3, 31));

            BacklogItem backlogItem = new BacklogItem((Developer)dev1, sprint, "UserAuthorizationFunctionality");

            var project = new Project("Test Project", Mock.Of<IVersionControlAdapter>(), (ProductOwner)po);

            // Act
            project.AddBacklogItem(backlogItem);

            // Assert
            Assert.Single(project.BacklogItems);
        }

        [Fact]
        public void F02_1_Should_ContainDeveloperInBacklogItem()
        {
            // Arrange
            UserFactory userFactory = new DeveloperUserFactory();
            User dev1 = userFactory.CreateUser("dev1", "dev1@mail", "dev1slack");

            SprintFactory sprintFactory = new ReleaseSprintFactory();
            Sprint sprint = sprintFactory.CreateSprint("test sprint", new DateTime(2024, 3, 23), new DateTime(2024, 3, 31));


            // Act
            BacklogItem backlogItem = new BacklogItem((Developer)dev1, sprint, "UserAuthorizationFunctionality");

            // Assert
            Assert.NotNull(backlogItem.Developer);
        }
    }
}
