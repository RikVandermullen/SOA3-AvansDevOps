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

IUserFactory productownerFactory = new ProductOwnerUserFactory();
User owner = productownerFactory.CreateUser("productowner", "productowner@mail.com", "productowner-slack");

ISprintFactory sprintFactory = new ReleaseSprintFactory();
Sprint sprint = sprintFactory.CreateSprint("TestSprint", DateTime.Now, DateTime.Now);
sprint.AddUser(dev);
sprint.AddUser(test);
sprint.AddUser(master);
sprint.AddUser(owner);

BacklogItem item = new BacklogItem((Developer)dev, sprint);
StateTransitionListener transitionListener = new StateTransitionListener();

item.Subscribe(transitionListener);

item.SetToDoing();
item.SetToReadyForTesting();
item.SetToTesting();
item.SetToToDo();

sprint.Subscribe(transitionListener);

sprint.Start();
sprint.Finish();
sprint.Deploy();
sprint.Finish();
sprint.Cancel();