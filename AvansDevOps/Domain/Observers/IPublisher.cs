using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Domain.Observers
{
    public interface IPublisher
    {
        public void Subscribe(IListener listener);

        public void Unsubscribe(IListener listener);

        public void NotifyListeners();
    }
}
