﻿using AvansDevOps.Domain.Composites.PipelineComposite;
using AvansDevOps.Domain.Observers;
using AvansDevOps.Domain.States;
using AvansDevOps.Domain.States.ReleaseSprintState;
using AvansDevOps.Domain.Strategy.ReportStrategy;
using AvansDevOps.Domain.Users;
using AvansDevOps.Domain.Visitors.PipelineVisitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Domain.Sprints
{
    public abstract class Sprint : IPublisher
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<User> Users { get; set; }
        public List<IListener> Listeners = new List<IListener>();
        public Pipeline Pipeline { get; set; } = null!;
        public List<BacklogItem> BacklogItems { get; set; }
        public Report Report { get; set; } = null!;

        public Sprint(string name, DateTime startDate, DateTime endDate)
        {
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            Users = new List<User>();
            BacklogItems = new List<BacklogItem>();
        }

        public bool EndDateReached()
        {
            DateTime currentDate = DateTime.Now;
            return currentDate > EndDate;
        }

        public void AddUser(User user)
        {
            Users.Add(user);
        }

        public abstract void AddPipeline(Pipeline pipeline);

        public abstract void SetState(ISprintState sprintState);

        public abstract void Start();

        public abstract void Finish();

        public abstract void StartReview();

        public abstract void Deploy();

        public abstract void Cancel();

        public abstract void Close();

        public void Subscribe(IListener listener)
        {
            Listeners.Add(listener);
        }

        public void Unsubscribe(IListener listener)
        {
            Listeners.Remove(listener);
        }

        public void NotifyListeners()
        {
            foreach (IListener listener in Listeners)
            {
                listener.Notify(this);
            }
        }

        public void AddBacklogItems(List<BacklogItem> backlogItems)
        {
            BacklogItems.AddRange(backlogItems);
        }

        public void GenerateReport(string companyName, string projectName, string version, IReportExportStrategy exportStrategy)
        {
            DateTime currentDate = DateTime.Now;
            Report = new Report(companyName, projectName, version, currentDate);
            Report.SetExportStrategy(exportStrategy);
            Report.Export();
        }
    }
}
