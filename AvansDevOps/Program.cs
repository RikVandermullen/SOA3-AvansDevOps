using AvansDevOps.Domain;
using AvansDevOps.Domain.Factories.SprintFactory;
using AvansDevOps.Domain.Sprints;

ISprintFactory releaseFactory = new ReleaseSprintFactory();
Sprint releaseSprint = releaseFactory.CreateSprint("releaseSprint", DateTime.Now, DateTime.Now);
releaseSprint.Start();