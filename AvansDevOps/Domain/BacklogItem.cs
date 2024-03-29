﻿using AvansDevOps.Domain.Observers;
using AvansDevOps.Domain.Observers.NotificationObserver;
using AvansDevOps.Domain.Sprints;
using AvansDevOps.Domain.States.BacklogItemState;
using AvansDevOps.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Thread = AvansDevOps.Domain.Composites.ForumComposite.Thread;

namespace AvansDevOps.Domain
{
    public class BacklogItem : IPublisher
    {
        public IBacklogItemState BacklogItemState { get; private set; }
        public IBacklogItemState PreviousState { get; private set; }
        public List<Activity> Activities { get; set; }
        public Developer Developer { get; set; }
        public List<IListener> Listeners { get; set; }
        public Sprint Sprint { get; set; }
        public string Name { get; set; }
        public List<Thread> Threads { get; set; }

        public BacklogItem(Developer developer, Sprint sprint, string name)
        {
            BacklogItemState = new TodoState(this);
            PreviousState = BacklogItemState;

            Activities = new List<Activity>();
            Developer = developer;
            Sprint = sprint;
            Name = name;
            Threads = new List<Thread>();

            Listeners = new List<IListener>();
        }

        public bool CheckActivitiesDone()
        {
            bool done = true;
            foreach (Activity activity in Activities)
            {
                if (!activity.IsCompleted)
                {
                    done = false;
                    break;
                }
            }
            return done;
        }

        public void AddActivity(Activity activity)
        {
            Activities.Add(activity);
        }

        public void AddThread(Thread thread)
        {
            Threads.Add(thread);
        }

        public void SetState(IBacklogItemState backlogItemState)
        {
            PreviousState = BacklogItemState;
            BacklogItemState = backlogItemState;
            NotifyListeners();
        }

        public void SetToToDo()
        {
            BacklogItemState.SetToToDo();
        }

        public void SetToDoing()
        {
            BacklogItemState.SetToDoing();
        }

        public void SetToReadyForTesting()
        {
            BacklogItemState.SetToReadyForTesting();
        }

        public void SetToTesting()
        {
            BacklogItemState.SetToTesting();
        }

        public void SetToTested()
        {
            BacklogItemState.SetToTested();
        }

        public void SetToDone()
        {
            BacklogItemState.SetToDone();
        }

        public void SetToClosed()
        {
            BacklogItemState.SetToClosed();
        }

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
            foreach(IListener listener in Listeners)
            {
                listener.Notify(this);
            }
        }
    }
}
