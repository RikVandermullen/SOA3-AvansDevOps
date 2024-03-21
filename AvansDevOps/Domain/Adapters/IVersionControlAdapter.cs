using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Domain.Adapters
{
    public interface IVersionControlAdapter
    {
        public void Commit(string ProjectName, BacklogItem item);
        public void Push(string ProjectName, BacklogItem item);
        public void Pull(string ProjectName);
    }
}
