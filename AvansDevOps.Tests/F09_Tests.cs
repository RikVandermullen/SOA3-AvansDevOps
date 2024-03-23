using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansDevOps.Domain;
using AvansDevOps.Domain.Adapters;
using AvansDevOps.Domain.Adapters.EmailAdapter;
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
    }
}
