using AvansDevOps.Domain;
using AvansDevOps.Domain.Adapters.GitHubAdapter;
using AvansDevOps.Domain.Composites.ForumComposite;
using AvansDevOps.Domain.Composites.PipelineComposite;
using AvansDevOps.Domain.Factories.SprintFactory;
using AvansDevOps.Domain.Factories.UserFactory;
using AvansDevOps.Domain.Observers.NotificationObserver;
using AvansDevOps.Domain.Sprints;
using AvansDevOps.Domain.Users;
using AvansDevOps.Domain.Visitors.ForumVisitor;
using AvansDevOps.Domain.Visitors.PipelineVisitor;
using Thread = AvansDevOps.Domain.Composites.ForumComposite.Thread;

IUserFactory userFactory = new DeveloperUserFactory();
User dev1 = userFactory.CreateUser("dev1", "dev1@mail", "dev1slack");
User dev2 = userFactory.CreateUser("dev2", "dev2@mail", "dev2slack");

ISprintFactory sprintFactory = new ReleaseSprintFactory();
Sprint sprint = sprintFactory.CreateSprint("test sprint", DateTime.Now, DateTime.Now);

BacklogItem backlogItem = new BacklogItem((Developer)dev1, sprint, "UserAuthorizationFunctionality");
Thread thread = new Thread(backlogItem, "AuthGuard Help");
thread.Subscribe(new ThreadUpdateListener());

thread.AddForumComponent(new Comment(dev1, "Im confused mate"));
thread.AddForumComponent(new Comment(dev2, "Whatsup? Ill help you out"));

Project project = new Project("Project1", new GitHubAdapter());
project.Forum.AddForumComponent(thread);

thread.AddForumComponent(new Comment(dev2, "You there?"));
thread.AddForumComponent(new Comment(dev1, "Yeah sorry"));

//LockVisitor lockVisitor = new LockVisitor();
//project.Forum.AcceptVisitor(lockVisitor);