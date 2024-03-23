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
using Thread = AvansDevOps.Domain.Composites.ForumComposite.Thread;
using AvansDevOps.Domain.Observers.NotificationObserver;
using AvansDevOps.Domain.States.BacklogItemState;
using AvansDevOps.Domain.Composites.ForumComposite;

namespace AvansDevOps.Tests
{
    public class F06_Tests
    {
        [Fact]
        public void F06_1_Should_CreateThreadsForBacklogItem()
        {
            // Arrange
            UserFactory factory = new ProductOwnerUserFactory();
            User po = factory.CreateUser("po", "po@mail.com", "po-slack");
            UserFactory factory1 = new DeveloperUserFactory();
            Developer dev = (Developer)factory1.CreateUser("dev", "dev@mail.com", "dev-slack");

            string name = "Test Project";
            var project = new Project(name, Mock.Of<IVersionControlAdapter>(), (ProductOwner)po);

            SprintFactory sprintFactory = new ReleaseSprintFactory();
            Sprint sprint = sprintFactory.CreateSprint("test sprint", new DateTime(2024, 3, 23), new DateTime(2024, 3, 31));
            BacklogItem item = new BacklogItem(dev, sprint, "Test BacklogItem");
            project.AddBacklogItem(item);

            // Act
            item.AddThread(new Thread(item, "Test Thread"));
            item.AddThread(new Thread(item, "Test Thread 2"));

            // Assert
            Assert.Equal(2, item.Threads.Count);
        }

        [Fact]
        public void F06_2_Should_AutomaticallyLockThreadsWhenTheirBacklogItemGetsClosed()
        {
            // Arrange
            UserFactory factory = new ProductOwnerUserFactory();
            User po = factory.CreateUser("po", "po@mail.com", "po-slack");
            UserFactory factory1 = new DeveloperUserFactory();
            Developer dev = (Developer)factory1.CreateUser("dev", "dev@mail.com", "dev-slack");

            string name = "Test Project";
            var project = new Project(name, Mock.Of<IVersionControlAdapter>(), (ProductOwner)po);

            SprintFactory sprintFactory = new ReleaseSprintFactory();
            Sprint sprint = sprintFactory.CreateSprint("test sprint", new DateTime(2024, 3, 23), new DateTime(2024, 3, 31));
            BacklogItem item = new BacklogItem(dev, sprint, "Test BacklogItem");

            project.AddBacklogItem(item);
            item.AddThread(new Thread(item, "Test Thread"));

            item.Subscribe(new StateTransitionListener());
            item.SetToDoing();
            item.SetToReadyForTesting();
            item.SetToTesting();
            item.SetToTested();
            item.SetToDone();

            // Act
            item.SetToClosed();

            // Assert
            Assert.False(item.Threads[0].IsActive);
        }

        [Fact]
        public void F06_3_Should_BeAbleToPostCommentUnderActiveThread()
        {
            // Arrange
            UserFactory factory = new ProductOwnerUserFactory();
            User po = factory.CreateUser("po", "po@mail.com", "po-slack");
            UserFactory factory1 = new DeveloperUserFactory();
            Developer dev = (Developer)factory1.CreateUser("dev", "dev@mail.com", "dev-slack");

            string name = "Test Project";
            var project = new Project(name, Mock.Of<IVersionControlAdapter>(), (ProductOwner)po);

            SprintFactory sprintFactory = new ReleaseSprintFactory();
            Sprint sprint = sprintFactory.CreateSprint("test sprint", new DateTime(2024, 3, 23), new DateTime(2024, 3, 31));
            BacklogItem item = new BacklogItem(dev, sprint, "Test BacklogItem");
            project.AddBacklogItem(item);
            item.AddThread(new Thread(item, "Test Thread"));

            // Act
            item.Threads[0].AddForumComponent(new Comment(dev, "Test"));

            // Assert
            Assert.NotNull(item.Threads[0].GetLastForumComponent());
        }
    }
}
