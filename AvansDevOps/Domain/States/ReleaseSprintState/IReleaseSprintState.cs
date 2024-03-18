using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Domain.States.ReleaseSprintState
{
    public interface IReleaseSprintState
    {
        public void Start();
        public void Finish();
        public void Deploy();
        public void Cancel();
        public void Close();
    }
}
