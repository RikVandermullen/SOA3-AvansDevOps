using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Domain.Observers
{
    public interface Listener
    {
        public void Notify(Publisher publisher);
    }
}
