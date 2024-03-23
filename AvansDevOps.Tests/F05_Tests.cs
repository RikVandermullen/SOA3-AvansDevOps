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
        public void F05_3_Should_ThrowWhenActivityNotDone()
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

        #region ToDoState Tests

        [Fact]
        public void Should_ThrowWhenToDoToReadyForTesting()
        {
            // Assert
            UserFactory userFactory = new DeveloperUserFactory();
            User dev1 = userFactory.CreateUser("dev1", "dev1@mail", "dev1slack");

            SprintFactory sprintFactory = new ReleaseSprintFactory();
            Sprint sprint = sprintFactory.CreateSprint("test sprint", new DateTime(2024, 3, 23), new DateTime(2024, 3, 31));

            BacklogItem backlogItem = new BacklogItem((Developer)dev1, sprint, "UserAuthorizationFunctionality");

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => backlogItem.SetToReadyForTesting());
        }

        [Fact]
        public void Should_ThrowWhenToDoToTesting()
        {
            // Assert
            UserFactory userFactory = new DeveloperUserFactory();
            User dev1 = userFactory.CreateUser("dev1", "dev1@mail", "dev1slack");

            SprintFactory sprintFactory = new ReleaseSprintFactory();
            Sprint sprint = sprintFactory.CreateSprint("test sprint", new DateTime(2024, 3, 23), new DateTime(2024, 3, 31));

            BacklogItem backlogItem = new BacklogItem((Developer)dev1, sprint, "UserAuthorizationFunctionality");

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => backlogItem.SetToTesting());
        }

        [Fact]
        public void Should_ThrowWhenToDoToTested()
        {
            // Assert
            UserFactory userFactory = new DeveloperUserFactory();
            User dev1 = userFactory.CreateUser("dev1", "dev1@mail", "dev1slack");

            SprintFactory sprintFactory = new ReleaseSprintFactory();
            Sprint sprint = sprintFactory.CreateSprint("test sprint", new DateTime(2024, 3, 23), new DateTime(2024, 3, 31));

            BacklogItem backlogItem = new BacklogItem((Developer)dev1, sprint, "UserAuthorizationFunctionality");

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => backlogItem.SetToTested());
        }

        [Fact]
        public void Should_ThrowWhenToDoToDone()
        {
            // Assert
            UserFactory userFactory = new DeveloperUserFactory();
            User dev1 = userFactory.CreateUser("dev1", "dev1@mail", "dev1slack");

            SprintFactory sprintFactory = new ReleaseSprintFactory();
            Sprint sprint = sprintFactory.CreateSprint("test sprint", new DateTime(2024, 3, 23), new DateTime(2024, 3, 31));

            BacklogItem backlogItem = new BacklogItem((Developer)dev1, sprint, "UserAuthorizationFunctionality");

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => backlogItem.SetToDone());
        }

        [Fact]
        public void Should_ThrowWhenToDoToClosed()
        {
            // Assert
            UserFactory userFactory = new DeveloperUserFactory();
            User dev1 = userFactory.CreateUser("dev1", "dev1@mail", "dev1slack");

            SprintFactory sprintFactory = new ReleaseSprintFactory();
            Sprint sprint = sprintFactory.CreateSprint("test sprint", new DateTime(2024, 3, 23), new DateTime(2024, 3, 31));

            BacklogItem backlogItem = new BacklogItem((Developer)dev1, sprint, "UserAuthorizationFunctionality");

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => backlogItem.SetToClosed());
        }

        #endregion

        #region DoingState Tests

        [Fact]
        public void Should_ThrowWhenDoingToToDo()
        {
            // Assert
            UserFactory userFactory = new DeveloperUserFactory();
            User dev1 = userFactory.CreateUser("dev1", "dev1@mail", "dev1slack");

            SprintFactory sprintFactory = new ReleaseSprintFactory();
            Sprint sprint = sprintFactory.CreateSprint("test sprint", new DateTime(2024, 3, 23), new DateTime(2024, 3, 31));

            BacklogItem backlogItem = new BacklogItem((Developer)dev1, sprint, "UserAuthorizationFunctionality");

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => backlogItem.SetToToDo());
        }

        [Fact]
        public void Should_ThrowWhenDoingToTesting()
        {
            // Assert
            UserFactory userFactory = new DeveloperUserFactory();
            User dev1 = userFactory.CreateUser("dev1", "dev1@mail", "dev1slack");

            SprintFactory sprintFactory = new ReleaseSprintFactory();
            Sprint sprint = sprintFactory.CreateSprint("test sprint", new DateTime(2024, 3, 23), new DateTime(2024, 3, 31));

            BacklogItem backlogItem = new BacklogItem((Developer)dev1, sprint, "UserAuthorizationFunctionality");
            backlogItem.SetToDoing();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => backlogItem.SetToTesting());
        }

        [Fact]
        public void Should_ThrowWhenDoingToTested()
        {
            // Assert
            UserFactory userFactory = new DeveloperUserFactory();
            User dev1 = userFactory.CreateUser("dev1", "dev1@mail", "dev1slack");

            SprintFactory sprintFactory = new ReleaseSprintFactory();
            Sprint sprint = sprintFactory.CreateSprint("test sprint", new DateTime(2024, 3, 23), new DateTime(2024, 3, 31));

            BacklogItem backlogItem = new BacklogItem((Developer)dev1, sprint, "UserAuthorizationFunctionality");
            backlogItem.SetToDoing();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => backlogItem.SetToTested());
        }

        [Fact]
        public void Should_ThrowWhenDoingToDone()
        {
            // Assert
            UserFactory userFactory = new DeveloperUserFactory();
            User dev1 = userFactory.CreateUser("dev1", "dev1@mail", "dev1slack");

            SprintFactory sprintFactory = new ReleaseSprintFactory();
            Sprint sprint = sprintFactory.CreateSprint("test sprint", new DateTime(2024, 3, 23), new DateTime(2024, 3, 31));

            BacklogItem backlogItem = new BacklogItem((Developer)dev1, sprint, "UserAuthorizationFunctionality");
            backlogItem.SetToDoing();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => backlogItem.SetToDone());
        }

        [Fact]
        public void Should_ThrowWhenDoingToClosed()
        {
            // Assert
            UserFactory userFactory = new DeveloperUserFactory();
            User dev1 = userFactory.CreateUser("dev1", "dev1@mail", "dev1slack");

            SprintFactory sprintFactory = new ReleaseSprintFactory();
            Sprint sprint = sprintFactory.CreateSprint("test sprint", new DateTime(2024, 3, 23), new DateTime(2024, 3, 31));

            BacklogItem backlogItem = new BacklogItem((Developer)dev1, sprint, "UserAuthorizationFunctionality");
            backlogItem.SetToDoing();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => backlogItem.SetToClosed());
        }

        #endregion

        #region ReadyForTesting Tests

        [Fact]
        public void Should_ThrowWhenReadyForTestingToTodo()
        {
            // Assert
            UserFactory userFactory = new DeveloperUserFactory();
            User dev1 = userFactory.CreateUser("dev1", "dev1@mail", "dev1slack");

            SprintFactory sprintFactory = new ReleaseSprintFactory();
            Sprint sprint = sprintFactory.CreateSprint("test sprint", new DateTime(2024, 3, 23), new DateTime(2024, 3, 31));

            BacklogItem backlogItem = new BacklogItem((Developer)dev1, sprint, "UserAuthorizationFunctionality");
            backlogItem.SetToDoing();
            backlogItem.SetToReadyForTesting();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => backlogItem.SetToToDo());
        }

        [Fact]
        public void Should_ThrowWhenReadyForTestingDoing()
        {
            // Assert
            UserFactory userFactory = new DeveloperUserFactory();
            User dev1 = userFactory.CreateUser("dev1", "dev1@mail", "dev1slack");

            SprintFactory sprintFactory = new ReleaseSprintFactory();
            Sprint sprint = sprintFactory.CreateSprint("test sprint", new DateTime(2024, 3, 23), new DateTime(2024, 3, 31));

            BacklogItem backlogItem = new BacklogItem((Developer)dev1, sprint, "UserAuthorizationFunctionality");
            backlogItem.SetToDoing();
            backlogItem.SetToReadyForTesting();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => backlogItem.SetToDoing());
        }

        [Fact]
        public void Should_ThrowWhenReadyForTestingDone()
        {
            // Assert
            UserFactory userFactory = new DeveloperUserFactory();
            User dev1 = userFactory.CreateUser("dev1", "dev1@mail", "dev1slack");

            SprintFactory sprintFactory = new ReleaseSprintFactory();
            Sprint sprint = sprintFactory.CreateSprint("test sprint", new DateTime(2024, 3, 23), new DateTime(2024, 3, 31));

            BacklogItem backlogItem = new BacklogItem((Developer)dev1, sprint, "UserAuthorizationFunctionality");
            backlogItem.SetToDoing();
            backlogItem.SetToReadyForTesting();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => backlogItem.SetToDone());
        }

        [Fact]
        public void Should_ThrowWhenReadyForTestingClosed()
        {
            // Assert
            UserFactory userFactory = new DeveloperUserFactory();
            User dev1 = userFactory.CreateUser("dev1", "dev1@mail", "dev1slack");

            SprintFactory sprintFactory = new ReleaseSprintFactory();
            Sprint sprint = sprintFactory.CreateSprint("test sprint", new DateTime(2024, 3, 23), new DateTime(2024, 3, 31));

            BacklogItem backlogItem = new BacklogItem((Developer)dev1, sprint, "UserAuthorizationFunctionality");
            backlogItem.SetToDoing();
            backlogItem.SetToReadyForTesting();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => backlogItem.SetToClosed());
        }

        #endregion

        #region Invalid State Transitiion

        [Fact]
        public void Should_ThrowWhenTestingToInvalidState()
        {
            // Assert
            UserFactory userFactory = new DeveloperUserFactory();
            User dev1 = userFactory.CreateUser("dev1", "dev1@mail", "dev1slack");

            SprintFactory sprintFactory = new ReleaseSprintFactory();
            Sprint sprint = sprintFactory.CreateSprint("test sprint", new DateTime(2024, 3, 23), new DateTime(2024, 3, 31));

            BacklogItem backlogItem = new BacklogItem((Developer)dev1, sprint, "UserAuthorizationFunctionality");
            backlogItem.SetToDoing();
            backlogItem.SetToReadyForTesting();
            backlogItem.SetToTesting();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => backlogItem.SetToToDo());
            Assert.Throws<InvalidOperationException>(() => backlogItem.SetToDoing());
            Assert.Throws<InvalidOperationException>(() => backlogItem.SetToTesting());
            Assert.Throws<InvalidOperationException>(() => backlogItem.SetToDone());
            Assert.Throws<InvalidOperationException>(() => backlogItem.SetToClosed());
        }

        [Fact]
        public void Should_ThrowWhenTestedToInvalidState()
        {
            // Assert
            UserFactory userFactory = new DeveloperUserFactory();
            User dev1 = userFactory.CreateUser("dev1", "dev1@mail", "dev1slack");

            SprintFactory sprintFactory = new ReleaseSprintFactory();
            Sprint sprint = sprintFactory.CreateSprint("test sprint", new DateTime(2024, 3, 23), new DateTime(2024, 3, 31));

            BacklogItem backlogItem = new BacklogItem((Developer)dev1, sprint, "UserAuthorizationFunctionality");
            backlogItem.SetToDoing();
            backlogItem.SetToReadyForTesting();
            backlogItem.SetToTesting();
            backlogItem.SetToTested();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => backlogItem.SetToToDo());
            Assert.Throws<InvalidOperationException>(() => backlogItem.SetToDoing());
            Assert.Throws<InvalidOperationException>(() => backlogItem.SetToTesting());
            Assert.Throws<InvalidOperationException>(() => backlogItem.SetToTested());
            Assert.Throws<InvalidOperationException>(() => backlogItem.SetToDone());
            Assert.Throws<InvalidOperationException>(() => backlogItem.SetToClosed());
        }

        [Fact]
        public void Should_ThrowWhenDoneToInvalidState()
        {
            // Assert
            UserFactory userFactory = new DeveloperUserFactory();
            User dev1 = userFactory.CreateUser("dev1", "dev1@mail", "dev1slack");

            SprintFactory sprintFactory = new ReleaseSprintFactory();
            Sprint sprint = sprintFactory.CreateSprint("test sprint", new DateTime(2024, 3, 23), new DateTime(2024, 3, 31));

            BacklogItem backlogItem = new BacklogItem((Developer)dev1, sprint, "UserAuthorizationFunctionality");
            backlogItem.SetToDoing();
            backlogItem.SetToReadyForTesting();
            backlogItem.SetToTesting();
            backlogItem.SetToTested();
            backlogItem.SetToDone();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => backlogItem.SetToDoing());
            Assert.Throws<InvalidOperationException>(() => backlogItem.SetToReadyForTesting());
            Assert.Throws<InvalidOperationException>(() => backlogItem.SetToTesting());
            Assert.Throws<InvalidOperationException>(() => backlogItem.SetToTested());
            Assert.Throws<InvalidOperationException>(() => backlogItem.SetToDone());
        }

        [Fact]
        public void Should_ThrowWhenClosedToInvalidState()
        {
            // Assert
            UserFactory userFactory = new DeveloperUserFactory();
            User dev1 = userFactory.CreateUser("dev1", "dev1@mail", "dev1slack");

            SprintFactory sprintFactory = new ReleaseSprintFactory();
            Sprint sprint = sprintFactory.CreateSprint("test sprint", new DateTime(2024, 3, 23), new DateTime(2024, 3, 31));

            BacklogItem backlogItem = new BacklogItem((Developer)dev1, sprint, "UserAuthorizationFunctionality");
            backlogItem.SetToDoing();
            backlogItem.SetToReadyForTesting();
            backlogItem.SetToTesting();
            backlogItem.SetToTested();
            backlogItem.SetToDone();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => backlogItem.SetToToDo());
            Assert.Throws<InvalidOperationException>(() => backlogItem.SetToDoing());
            Assert.Throws<InvalidOperationException>(() => backlogItem.SetToReadyForTesting());
            Assert.Throws<InvalidOperationException>(() => backlogItem.SetToTesting());
            Assert.Throws<InvalidOperationException>(() => backlogItem.SetToTested());
            Assert.Throws<InvalidOperationException>(() => backlogItem.SetToDone());
            Assert.Throws<InvalidOperationException>(() => backlogItem.SetToClosed());
        }

        #endregion
    }
}
