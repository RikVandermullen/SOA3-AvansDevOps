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
using AvansDevOps.Domain.States.BacklogItemState;

namespace AvansDevOps.Tests
{
    public class F05_Tests
    {
        [Fact]
        public void F05_1_Should_AddBacklogItemToSprint()
        {
            // Arrange
            UserFactory factory = new ProductOwnerUserFactory();
            User po = factory.CreateUser("po", "po@mail.com", "po-slack");
            string name = "Test Project";

            UserFactory userFactory = new DeveloperUserFactory();
            User dev1 = userFactory.CreateUser("dev1", "dev1@mail", "dev1slack");

            SprintFactory sprintFactory = new ReleaseSprintFactory();
            Sprint sprint = sprintFactory.CreateSprint("test sprint", new DateTime(2024, 3, 23), new DateTime(2024, 3, 31));

            BacklogItem backlogItem = new BacklogItem((Developer)dev1, sprint, "UserAuthorizationFunctionality");

            var project = new Project(name, Mock.Of<IVersionControlAdapter>(), (ProductOwner)po);
            project.Sprints.Add(sprint);

            // Act
            sprint.AddBacklogItems(new List<BacklogItem> { backlogItem});

            // Assert
            Assert.Single(sprint.BacklogItems);
        }

        [Fact]
        public void F05_2_Should_BeToDo()
        {
            // Arrange
            UserFactory userFactory = new DeveloperUserFactory();
            User dev1 = userFactory.CreateUser("dev1", "dev1@mail", "dev1slack");

            SprintFactory sprintFactory = new ReleaseSprintFactory();
            Sprint sprint = sprintFactory.CreateSprint("test sprint", new DateTime(2024, 3, 23), new DateTime(2024, 3, 31));

            // Act
            BacklogItem backlogItem = new BacklogItem((Developer)dev1, sprint, "UserAuthorizationFunctionality");
           
            // Assert
            Assert.IsType<TodoState>(backlogItem.BacklogItemState);
        }

        [Fact]
        public void F05_2_Should_BeDoing()
        {
            // Arrange
            UserFactory userFactory = new DeveloperUserFactory();
            User dev1 = userFactory.CreateUser("dev1", "dev1@mail", "dev1slack");

            SprintFactory sprintFactory = new ReleaseSprintFactory();
            Sprint sprint = sprintFactory.CreateSprint("test sprint", new DateTime(2024, 3, 23), new DateTime(2024, 3, 31));

            BacklogItem backlogItem = new BacklogItem((Developer)dev1, sprint, "UserAuthorizationFunctionality");

            // Act
            backlogItem.SetToDoing();

            // Assert
            Assert.IsType<DoingState>(backlogItem.BacklogItemState);
        }

        [Fact]
        public void F05_2_Should_BeReadyForTesting()
        {
            // Arrange
            UserFactory userFactory = new DeveloperUserFactory();
            User dev1 = userFactory.CreateUser("dev1", "dev1@mail", "dev1slack");

            SprintFactory sprintFactory = new ReleaseSprintFactory();
            Sprint sprint = sprintFactory.CreateSprint("test sprint", new DateTime(2024, 3, 23), new DateTime(2024, 3, 31));

            BacklogItem backlogItem = new BacklogItem((Developer)dev1, sprint, "UserAuthorizationFunctionality");

            // Act
            backlogItem.SetToDoing();
            backlogItem.SetToReadyForTesting();

            // Assert
            Assert.IsType<ReadyForTestingState>(backlogItem.BacklogItemState);
        }

        [Fact]
        public void F05_2_Should_BeTesting()
        {
            // Arrange
            UserFactory userFactory = new DeveloperUserFactory();
            User dev1 = userFactory.CreateUser("dev1", "dev1@mail", "dev1slack");

            SprintFactory sprintFactory = new ReleaseSprintFactory();
            Sprint sprint = sprintFactory.CreateSprint("test sprint", new DateTime(2024, 3, 23), new DateTime(2024, 3, 31));

            BacklogItem backlogItem = new BacklogItem((Developer)dev1, sprint, "UserAuthorizationFunctionality");

            // Act
            backlogItem.SetToDoing();
            backlogItem.SetToReadyForTesting();
            backlogItem.SetToTesting();

            // Assert
            Assert.IsType<TestingState>(backlogItem.BacklogItemState);
        }

        [Fact]
        public void F05_2_Should_BeTested()
        {
            // Arrange
            UserFactory userFactory = new DeveloperUserFactory();
            User dev1 = userFactory.CreateUser("dev1", "dev1@mail", "dev1slack");

            SprintFactory sprintFactory = new ReleaseSprintFactory();
            Sprint sprint = sprintFactory.CreateSprint("test sprint", new DateTime(2024, 3, 23), new DateTime(2024, 3, 31));

            BacklogItem backlogItem = new BacklogItem((Developer)dev1, sprint, "UserAuthorizationFunctionality");

            // Act
            backlogItem.SetToDoing();
            backlogItem.SetToReadyForTesting();
            backlogItem.SetToTesting();
            backlogItem.SetToTested();

            // Assert
            Assert.IsType<TestedState>(backlogItem.BacklogItemState);
        }

        [Fact]
        public void F05_2_Should_BeDone()
        {
            // Arrange
            UserFactory userFactory = new DeveloperUserFactory();
            User dev1 = userFactory.CreateUser("dev1", "dev1@mail", "dev1slack");

            SprintFactory sprintFactory = new ReleaseSprintFactory();
            Sprint sprint = sprintFactory.CreateSprint("test sprint", new DateTime(2024, 3, 23), new DateTime(2024, 3, 31));

            BacklogItem backlogItem = new BacklogItem((Developer)dev1, sprint, "UserAuthorizationFunctionality");

            // Act
            backlogItem.SetToDoing();
            backlogItem.SetToReadyForTesting();
            backlogItem.SetToTesting();
            backlogItem.SetToTested();
            backlogItem.SetToDone();

            // Assert
            Assert.IsType<DoneState>(backlogItem.BacklogItemState);
        }

        [Fact]
        public void F05_2_Should_BeClosed()
        {
            // Arrange
            UserFactory userFactory = new DeveloperUserFactory();
            User dev1 = userFactory.CreateUser("dev1", "dev1@mail", "dev1slack");

            SprintFactory sprintFactory = new ReleaseSprintFactory();
            Sprint sprint = sprintFactory.CreateSprint("test sprint", new DateTime(2024, 3, 23), new DateTime(2024, 3, 31));

            BacklogItem backlogItem = new BacklogItem((Developer)dev1, sprint, "UserAuthorizationFunctionality");

            // Act
            backlogItem.SetToDoing();
            backlogItem.SetToReadyForTesting();
            backlogItem.SetToTesting();
            backlogItem.SetToTested();
            backlogItem.SetToDone();
            backlogItem.SetToClosed();

            // Assert
            Assert.IsType<ClosedState>(backlogItem.BacklogItemState);
        }

        [Fact]
        public void F05_2_Should_ThrowWhenActivityNotDone()
        {
            // Arrange
            UserFactory userFactory = new DeveloperUserFactory();
            User dev1 = userFactory.CreateUser("dev1", "dev1@mail", "dev1slack");

            SprintFactory sprintFactory = new ReleaseSprintFactory();
            Sprint sprint = sprintFactory.CreateSprint("test sprint", new DateTime(2024, 3, 23), new DateTime(2024, 3, 31));

            BacklogItem backlogItem = new BacklogItem((Developer)dev1, sprint, "UserAuthorizationFunctionality");
            backlogItem.AddActivity(new Activity("Part 1", (Developer)dev1));

            // Act
            backlogItem.SetToDoing();
            backlogItem.SetToReadyForTesting();
            backlogItem.SetToTesting();
            backlogItem.SetToTested();
            
            // Assert
            Assert.Throws<InvalidOperationException>(() => backlogItem.SetToDone());
        }
    }
}
