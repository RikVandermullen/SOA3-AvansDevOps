﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Domain.States.BacklogItemState
{
    public class TodoState : IBacklogItemState
    {
        private BacklogItem BacklogItem { get; set; }

        public TodoState(BacklogItem backlogItem)
        {
            BacklogItem = backlogItem;
        }

        public void SetToToDo()
        {
            throw new InvalidOperationException();
        }

        public void SetToDoing()
        {
            BacklogItem.SetState(new DoingState(BacklogItem));
        }

        public void SetToReadyForTesting()
        {
            throw new InvalidOperationException();
        }

        public void SetToTesting()
        {
            throw new InvalidOperationException();
        }

        public void SetToTested()
        {
            throw new InvalidOperationException();
        }

        public void SetToDone()
        {
            throw new InvalidOperationException();
        }
    }
}
