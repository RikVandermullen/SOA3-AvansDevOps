using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansDevOps.Domain;
using AvansDevOps.Domain.Adapters;
using AvansDevOps.Domain.Adapters.EmailAdapter;
using AvansDevOps.Domain.Adapters.SlackAdapter;
using AvansDevOps.Domain.Composites.ForumComposite;
using AvansDevOps.Domain.Factories.SprintFactory;
using AvansDevOps.Domain.Factories.UserFactory;
using AvansDevOps.Domain.Observers.NotificationObserver;
using AvansDevOps.Domain.Sprints;
using AvansDevOps.Domain.Users;
using Moq;
using Thread = AvansDevOps.Domain.Composites.ForumComposite.Thread;

namespace AvansDevOps.Tests
{
    public class F09_Tests
    {
        [Fact]
        public void F09_1_Should_AddMediaPlatform()
        {
            // Arrange
            UserFactory userFactory = new DeveloperUserFactory();

            // Act
            User dev1 = userFactory.CreateUser("dev1", "dev1@mail", "dev1slack");

            // Assert
            Assert.Single(dev1.NotificationPlatforms);
        }

        [Fact]
        public void F09_7_1_Should_NotNotifyWhenPublisherNotOfTypeThread()
        {
            // Arrange
            UserFactory userFactory = new DeveloperUserFactory();
            User dev1 = userFactory.CreateUser("dev1", "dev1@mail", "dev1slack");
            User dev2 = userFactory.CreateUser("dev2", "dev2@mail", "dev2slack");

            SprintFactory sprintFactory = new ReleaseSprintFactory();
            Sprint sprint = sprintFactory.CreateSprint("test sprint", DateTime.Now, DateTime.Now);

            BacklogItem backlogItem = new BacklogItem((Developer)dev1, sprint, "UserAuthorizationFunctionality");

            backlogItem.Subscribe(new ThreadUpdateListener());
            var mockService = new Mock<INotificationAdapter>();

            // Act
            backlogItem.NotifyListeners();

            // Assert
            mockService.Verify(service => service.Send(It.IsAny<User>(), It.IsAny<string>()), Times.Never());
        }

        [Fact]
        public void F09_7_2_Should_NotNotifyWhenPublisherHasNoUsers()
        {
            // Arrange
            UserFactory userFactory = new DeveloperUserFactory();
            User dev1 = userFactory.CreateUser("dev1", "dev1@mail", "dev1slack");
            User dev2 = userFactory.CreateUser("dev2", "dev2@mail", "dev2slack");

            SprintFactory sprintFactory = new ReleaseSprintFactory();
            Sprint sprint = sprintFactory.CreateSprint("test sprint", DateTime.Now, DateTime.Now);

            BacklogItem backlogItem = new BacklogItem((Developer)dev1, sprint, "UserAuthorizationFunctionality");
            Thread thread = new Thread(backlogItem, "AuthGuard Help");
            backlogItem.AddThread(thread);

            thread.Subscribe(new ThreadUpdateListener());

            var mockService = new Mock<INotificationAdapter>();

            // Act
            backlogItem.NotifyListeners();

            // Assert
            mockService.Verify(service => service.Send(It.IsAny<User>(), It.IsAny<string>()), Times.Never());
        }

        [Fact]
        public void F09_7_3_Should_NotifyWhenUserNotAuthorOfComment()
        {
            // Arrange
            UserFactory userFactory = new DeveloperUserFactory();
            User dev1 = userFactory.CreateUser("dev1", "dev1@mail", "dev1slack");
            dev1.AddPlatform(new SlackAdapter());
            User dev2 = userFactory.CreateUser("dev2", "dev2@mail", "dev2slack");

            SprintFactory sprintFactory = new ReleaseSprintFactory();
            Sprint sprint = sprintFactory.CreateSprint("test sprint", DateTime.Now, DateTime.Now);

            BacklogItem backlogItem = new BacklogItem((Developer)dev1, sprint, "UserAuthorizationFunctionality");
            Thread thread = new Thread(backlogItem, "AuthGuard Help");
            backlogItem.AddThread(thread);

            thread.Users = new List<User>
            {
                dev1,
            };

            thread.Subscribe(new ThreadUpdateListener());
            thread.AddForumComponent(new Comment(dev2, "Sending help"));

            var mockService = new Mock<INotificationAdapter>();

            // Act
            thread.NotifyListeners();

            // Assert
            mockService.Verify(service => service.Send(It.IsAny<User>(), It.IsAny<string>()), Times.Never());
        }

        [Fact]
        public void F09_7_4_Should_NotNotifyWhenUserAuthorOfComment()
        {
            // Arrange
            UserFactory userFactory = new DeveloperUserFactory();
            User dev1 = userFactory.CreateUser("dev1", "dev1@mail", "dev1slack");
            User dev2 = userFactory.CreateUser("dev2", "dev2@mail", "dev2slack");

            SprintFactory sprintFactory = new ReleaseSprintFactory();
            Sprint sprint = sprintFactory.CreateSprint("test sprint", DateTime.Now, DateTime.Now);

            BacklogItem backlogItem = new BacklogItem((Developer)dev1, sprint, "UserAuthorizationFunctionality");
            Thread thread = new Thread(backlogItem, "AuthGuard Help");
            backlogItem.AddThread(thread);

            thread.Users = new List<User>
            {
                dev1,
            };


            thread.Subscribe(new ThreadUpdateListener());

            thread.AddForumComponent(new Comment(dev1, "thanks"));
            var mockService = new Mock<INotificationAdapter>();

            // Act
            backlogItem.NotifyListeners();

            // Assert
            mockService.Verify(service => service.Send(dev1, It.IsAny<string>()), Times.Never());
        }

        [Fact]
        public void F09_2_Should_NotifyTestersWhenBacklogItemInReadyForTesting()
        {
            // Arrange
            var userFactory = new DeveloperUserFactory();
            User dev1 = userFactory.CreateUser("dev1", "dev1@mail", "dev1slack");

            var testerFactory = new TesterUserFactory();
            User tester = testerFactory.CreateUser("tester", "tester@mail", "testerslack");
            var mockService = new Mock<INotificationAdapter>();
            tester.AddPlatform(mockService.Object);

            SprintFactory sprintFactory = new ReleaseSprintFactory();
            Sprint sprint = sprintFactory.CreateSprint("test sprint", new DateTime(2024, 3, 23), new DateTime(2024, 3, 31));
            sprint.AddUser(tester);

            var listener = new StateTransitionListener();

            sprint.Subscribe(listener);

            BacklogItem backlogItem = new BacklogItem((Developer)dev1, sprint, "UserAuthorizationFunctionality");
            backlogItem.SetToDoing();

            // Act
            backlogItem.SetToReadyForTesting();

            // Assert
            mockService.Verify(service => service.Send(tester, It.IsAny<string>()), Times.Never());
        }

        [Fact]
        public void F09_3_Should_NotifyScrummasterWhenBacklogItemFromForTestingToToDo()
        {
            // Arrange
            var userFactory = new DeveloperUserFactory();
            User dev1 = userFactory.CreateUser("dev1", "dev1@mail", "dev1slack");

            var testerFactory = new TesterUserFactory();
            User tester = testerFactory.CreateUser("tester", "tester@mail", "testerslack");
            var scrummasterFactory = new ScrumMasterUserFactory();
            User scrumMaster = scrummasterFactory.CreateUser("scrumMaster", "scrumMaster@mail", "scrumMasterSlack");
            var mockService = new Mock<INotificationAdapter>();
            tester.AddPlatform(mockService.Object);

            SprintFactory sprintFactory = new ReleaseSprintFactory();
            Sprint sprint = sprintFactory.CreateSprint("test sprint", new DateTime(2024, 3, 23), new DateTime(2024, 3, 31));
            sprint.AddUser(tester);
            sprint.AddUser(scrumMaster);

            var listener = new StateTransitionListener();

            sprint.Subscribe(listener);

            BacklogItem backlogItem = new BacklogItem((Developer)dev1, sprint, "UserAuthorizationFunctionality");
            backlogItem.SetToDoing();
            backlogItem.SetToReadyForTesting();
            backlogItem.SetToTesting();

            // Act
            backlogItem.SetToToDo();

            // Assert
            mockService.Verify(service => service.Send(scrumMaster, It.IsAny<string>()), Times.Never());
        }

        [Fact]
        public void F09_4_Should_NotifyScrummasterAndProductOwnerWhenReleaseSprintCancelled()
        {
            // Arrange
            var scrummasterFactory = new ScrumMasterUserFactory();
            User scrumMaster = scrummasterFactory.CreateUser("scrumMaster", "scrumMaster@mail", "scrumMasterSlack");
            var productOwnerFactory = new ProductOwnerUserFactory();
            User productOwner = productOwnerFactory.CreateUser("productOwner", "productOwner@mail", "productOwnerSlack");
            var mockService = new Mock<INotificationAdapter>();

            SprintFactory sprintFactory = new ReleaseSprintFactory();
            Sprint sprint = sprintFactory.CreateSprint("test sprint", new DateTime(2024, 3, 23), new DateTime(2024, 3, 20));
            sprint.AddUser(scrumMaster);
            sprint.AddUser(productOwner);

            var listener = new StateTransitionListener();

            sprint.Subscribe(listener);

            sprint.Start();
            sprint.Finish();
            sprint.Deploy();

            // Act
            sprint.Cancel();

            // Assert
            mockService.Verify(service => service.Send(scrumMaster, It.IsAny<string>()), Times.Never());
            mockService.Verify(service => service.Send(productOwner, It.IsAny<string>()), Times.Never());
        }

        [Fact]
        public void F09_5_Should_NotifyScrummasterAndProductOwnerWhenReleaseSprintSuccesfullyReleased()
        {
            // Arrange
            var scrummasterFactory = new ScrumMasterUserFactory();
            User scrumMaster = scrummasterFactory.CreateUser("scrumMaster", "scrumMaster@mail", "scrumMasterSlack");
            var productOwnerFactory = new ProductOwnerUserFactory();
            User productOwner = productOwnerFactory.CreateUser("productOwner", "productOwner@mail", "productOwnerSlack");
            var mockService = new Mock<INotificationAdapter>();

            SprintFactory sprintFactory = new ReleaseSprintFactory();
            Sprint sprint = sprintFactory.CreateSprint("test sprint", new DateTime(2024, 3, 23), new DateTime(2024, 3, 20));
            sprint.AddUser(scrumMaster);
            sprint.AddUser(productOwner);

            var listener = new StateTransitionListener();

            sprint.Subscribe(listener);

            sprint.Start();
            sprint.Finish();

            // Act
            sprint.Deploy();

            // Assert
            mockService.Verify(service => service.Send(scrumMaster, It.IsAny<string>()), Times.Never());
            mockService.Verify(service => service.Send(productOwner, It.IsAny<string>()), Times.Never());
        }

    }
}
