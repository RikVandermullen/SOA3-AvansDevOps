using AvansDevOps.Domain.Composites.PipelineComposite;
using AvansDevOps.Domain.Observers;
using AvansDevOps.Domain.States;
using AvansDevOps.Domain.States.ReleaseSprintState;
using AvansDevOps.Domain.Visitors.PipelineVisitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Domain.Sprints
{
    public class ReleaseSprint : Sprint
    {
        public IReleaseSprintState ReleaseSprintState { get; set; }
        public List<IListener> Listeners = new List<IListener>();
        public IReleaseSprintState PreviousState { get; set; }

        public ReleaseSprint(string name, DateTime startDate, DateTime endDate) : base(name, startDate, endDate)
        {
            ReleaseSprintState = new CreatedState(this);
            PreviousState = ReleaseSprintState;
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
        }

        public override void SetState(ISprintState releaseSprintState)
        {
            PreviousState = ReleaseSprintState;
            ReleaseSprintState = (IReleaseSprintState) releaseSprintState;
            NotifyListeners();
        }

        public override void Start()
        {
            ReleaseSprintState.Start();
        }

        public override void Finish()
        {
           ReleaseSprintState.Finish();
        }

        public override void Deploy()
        {
            ReleaseSprintState.Deploy();
            Pipeline.AcceptVisitor(new ExecuteVisitor());
        }

        public override void Cancel()
        {
            ReleaseSprintState.Cancel();
        }

        public override void Close()
        {
            ReleaseSprintState.Close();
        }

        public override void StartReview()
        {
            throw new NotImplementedException();
        }

        public override void AddPipeline(Pipeline pipeline)
        {
            Pipeline = pipeline;
        }
    }
}
