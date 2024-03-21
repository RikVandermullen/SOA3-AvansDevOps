using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Domain.Adapters
{
    public interface IVersionControlAdapter
    {
        public void Commit(string projectName, BacklogItem item);
        public void Push(string projectName, BacklogItem item);
        public void Pull(string projectName);
    }
}
