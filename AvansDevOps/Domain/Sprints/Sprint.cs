using AvansDevOps.Domain.Observers;
using AvansDevOps.Domain.States;
using AvansDevOps.Domain.States.ReleaseSprintState;
using AvansDevOps.Domain.Users;
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

        public Sprint(string name, DateTime startDate, DateTime endDate)
        {
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            Users = new List<User>();
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
    }
}
