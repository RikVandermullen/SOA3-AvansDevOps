using AvansDevOps.Domain;
using AvansDevOps.Domain.Factories.SprintFactory;
using AvansDevOps.Domain.Factories.UserFactory;
using AvansDevOps.Domain.Observers.NotificationObserver;
using AvansDevOps.Domain.Sprints;
using AvansDevOps.Domain.Users;

IUserFactory devFactory = new DeveloperUserFactory();
User dev = devFactory.CreateUser("rik", "rik@mail.com", "rik-slack");

IUserFactory testFactory = new TesterUserFactory();
User test = testFactory.CreateUser("tester", "tester@mail.com", "tester-slack");

IUserFactory scrummasterFactory = new ScrumMasterUserFactory();
User master = scrummasterFactory.CreateUser("scrummaster", "scrummaster@mail.com", "scrummaster-slack");

ISprintFactory sprintFactory = new ReleaseSprintFactory();
Sprint sprint = sprintFactory.CreateSprint("Name", DateTime.Now, DateTime.Now);
sprint.AddUser(dev);
sprint.AddUser(test);
sprint.AddUser(master);

BacklogItem item = new BacklogItem((Developer)dev, sprint);
StateTransitionListener transitionListener = new StateTransitionListener();

item.Subscribe(transitionListener);

item.SetToDoing();
item.SetToReadyForTesting();
item.SetToTesting();
item.SetToToDo();