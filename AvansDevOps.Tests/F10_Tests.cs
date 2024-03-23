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

namespace AvansDevOps.Tests
{
    public class F10_Tests
    {
        [Fact]
        public void F10_1_Should_AddActivitiesToBacklogItem()
        {
            // Arrange
            UserFactory factory = new ProductOwnerUserFactory();
            User po = factory.CreateUser("po", "po@mail.com", "po-slack");

            UserFactory userFactory = new DeveloperUserFactory();
            Developer dev1 = (Developer)userFactory.CreateUser("dev1", "dev1@mail", "dev1slack");

            SprintFactory sprintFactory = new ReleaseSprintFactory();
            Sprint sprint = sprintFactory.CreateSprint("test sprint", new DateTime(2024, 3, 23), new DateTime(2024, 3, 31));

            BacklogItem backlogItem = new BacklogItem(dev1, sprint, "UserAuthorizationFunctionality");

            var project = new Project("Test Project", Mock.Of<IVersionControlAdapter>(), (ProductOwner)po);
            project.AddBacklogItem(backlogItem);

            // Act
            backlogItem.AddActivity(new Activity("AuthGuard", dev1));

            // Assert
            Assert.NotEmpty(backlogItem.Activities);
        }

        [Fact]
        public void F10_2_Should_BacklogItemHasOnlyOneDeveloper()
        {
            // Arrange
            UserFactory factory = new ProductOwnerUserFactory();
            User po = factory.CreateUser("po", "po@mail.com", "po-slack");

            UserFactory userFactory = new DeveloperUserFactory();
            Developer dev1 = (Developer)userFactory.CreateUser("dev1", "dev1@mail", "dev1slack");

            SprintFactory sprintFactory = new ReleaseSprintFactory();
            Sprint sprint = sprintFactory.CreateSprint("test sprint", new DateTime(2024, 3, 23), new DateTime(2024, 3, 31));

            // Act
            BacklogItem backlogItem = new BacklogItem(dev1, sprint, "UserAuthorizationFunctionality");

            // Assert
            Assert.NotNull(backlogItem.Developer);
        }
    }
}
