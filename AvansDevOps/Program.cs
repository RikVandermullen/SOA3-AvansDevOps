using AvansDevOps.Domain;
using AvansDevOps.Domain.Adapters.GitHubAdapter;
using AvansDevOps.Domain.Adapters.SlackAdapter;
using AvansDevOps.Domain.Composites.ForumComposite;
using AvansDevOps.Domain.Composites.PipelineComposite;
using AvansDevOps.Domain.Factories.SprintFactory;
using AvansDevOps.Domain.Factories.UserFactory;
using AvansDevOps.Domain.Observers.NotificationObserver;
using AvansDevOps.Domain.Sprints;
using AvansDevOps.Domain.Users;
using AvansDevOps.Domain.Visitors.ForumVisitor;
using AvansDevOps.Domain.Visitors.PipelineVisitor;
using Action = AvansDevOps.Domain.Composites.PipelineComposite.Action;
using Thread = AvansDevOps.Domain.Composites.ForumComposite.Thread;

//UserFactory userFactory = new DeveloperUserFactory();
//User dev1 = userFactory.CreateUser("dev1", "dev1@mail", "dev1slack");
//User dev2 = userFactory.CreateUser("dev2", "dev2@mail", "dev2slack");

//SprintFactory sprintFactory = new ReleaseSprintFactory();
//Sprint sprint = sprintFactory.CreateSprint("test sprint", DateTime.Now, DateTime.Now);

//BacklogItem backlogItem = new BacklogItem((Developer)dev1, sprint, "UserAuthorizationFunctionality");

//Thread thread = new Thread(backlogItem, "AuthGuard Help");
//backlogItem.AddThread(thread);

//thread.Subscribe(new ThreadUpdateListener());

//thread.AddForumComponent(new Comment(dev1, "Im confused mate"));
//thread.AddForumComponent(new Comment(dev2, "Whatsup? Ill help you out"));

//Project project = new Project("Project1", new GitHubAdapter());
//project.Forum.AddForumComponent(thread);

//thread.AddForumComponent(new Comment(dev2, "You there?"));
//thread.AddForumComponent(new Comment(dev1, "Yeah sorry"));

//backlogItem.Subscribe(new StateTransitionListener());
//backlogItem.SetToDoing();
//backlogItem.SetToReadyForTesting();
//backlogItem.SetToTesting();
//backlogItem.SetToTested();
//backlogItem.SetToDone();

UserFactory userFactory = new ProductOwnerUserFactory();
User po = userFactory.CreateUser("po", "po@mail.com", "po-slack");

UserFactory smFactory = new ScrumMasterUserFactory();
User sm = smFactory.CreateUser("sm", "sm@mail.com", "sm-slack");
sm.AddPlatform(new SlackAdapter());

Project project = new Project("Project1", new GitHubAdapter(), (ProductOwner)po);

Dictionary<Category, List<Action>> components = new Dictionary<Category, List<Action>>();

Category category = new Category("Build");
List<Action> actions = new List<Action>
{
    new Action("build step 1"),
    new Action("build step 2"),
    new Action("build step 3"),
    new Action("build step 4"),
};

Category category1 = new Category("Test");
List<Action> actions1 = new List<Action>
{
    new Action("Test step 1"),
    new Action("Test step 2"),
    new Action("Test step 3"),
    new Action("Test step 4"),
};

components.Add(category, actions);
components.Add(category1, actions1);

project.CreatePipeline("test pipeline", components, new DryRunVisitor());


SprintFactory sprintFactory = new ReleaseSprintFactory();
Sprint sprint = sprintFactory.CreateSprint("test sprint", DateTime.Now, new DateTime(2023, 3, 22));
sprint.Subscribe(new StateTransitionListener());
sprint.AddUser(sm);
sprint.AddPipeline(project.Pipeline);
sprint.Start();
sprint.Finish();
sprint.Deploy();

