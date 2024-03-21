using AvansDevOps.Domain.Observers;
using AvansDevOps.Domain.Observers.NotificationObserver;
using AvansDevOps.Domain.Users;
using AvansDevOps.Domain.Visitors.ForumVisitor;
using AvansDevOps.Domain.Visitors.PipelineVisitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Domain.Composites.ForumComposite
{
    public class Thread : ForumComposite, IPublisher
    {
        public List<User> Users = new List<User>();
        public List<IListener> Listeners = new List<IListener>();
        public BacklogItem BacklogItem { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public Thread(BacklogItem backlogItem, string name)
        {
            BacklogItem = backlogItem;
            Name = $"{backlogItem.Name}-Thread: {name}";
            IsActive = true;
        }

        public override void AcceptVisitor(ForumVisitor visitor)
        {
            visitor.VisitThread(this);
            base.AcceptVisitor(visitor);
        }

        public override void AddForumComponent(ForumComponent component)
        {
            if(IsActive)
            {
                base.AddForumComponent(component);
                NotifyListeners();

                Comment comment = (Comment)component;
                
                if(!Users.Contains(comment.Author)) Users.Add(comment.Author);
            } else
            {
                Console.WriteLine("Cant add comments to thread as it has been locked.");
            }
        }

        public void NotifyListeners()
        {
            foreach (IListener listener in Listeners)
            {
                listener.Notify(this);
            }
        }

        public void Subscribe(IListener listener)
        {
            Listeners.Add(listener);
        }

        public void Unsubscribe(IListener listener)
        {
            Listeners.Remove(listener);
        }

    }
}
