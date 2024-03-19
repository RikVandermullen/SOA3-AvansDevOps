using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Domain.Observers
{
    public interface IListener
    {
        public void Notify(IPublisher publisher);
    }
}
