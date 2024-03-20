using AvansDevOps.Domain;
using AvansDevOps.Domain.Composites.PipelineComposite;
using AvansDevOps.Domain.Factories.SprintFactory;
using AvansDevOps.Domain.Factories.UserFactory;
using AvansDevOps.Domain.Observers.NotificationObserver;
using AvansDevOps.Domain.Sprints;
using AvansDevOps.Domain.Users;
using AvansDevOps.Domain.Visitors.PipelineVisitor;
using Action = AvansDevOps.Domain.Composites.PipelineComposite.Action;

Pipeline pipeline = new Pipeline("Test Pipeline");

Category category = new Category("Build");
category.AddPipelineComponent(new Action("git clone"));
category.AddPipelineComponent(new Action("git clone"));
category.AddPipelineComponent(new Action("git clone"));
category.AddPipelineComponent(new Action("git clone"));
category.AddPipelineComponent(new Action("git clone"));
category.AddPipelineComponent(new Action("git clone"));

pipeline.AddPipelineComponent(category);


ExecuteVisitor visitor = new ExecuteVisitor();

pipeline.AcceptVisitor(visitor);

