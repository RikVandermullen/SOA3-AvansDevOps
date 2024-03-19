using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Domain.Observers
{
    public interface Publisher
    {
        public void Subscribe(Listener listener);

        public void Unsubscribe(Listener listener);

        public void NotifyListeners();
    }
}
