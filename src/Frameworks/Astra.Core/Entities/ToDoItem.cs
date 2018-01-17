using System;
using Astra.Core.Events;
using Astra.Core.Interfaces;
using Astra.Core.SharedKernel;

namespace Astra.Core.Entities
{
    public class ToDoItem : BaseEntity, IAuditTrail
    {
        public string Title { get; set; } 
        public string Description { get; set; }
        public bool IsDone { get; private set; } = false;

        public DateTime _CreatedUtc { get; set; }
        public string _CreatedBy { get; set; }
        public string _CreatedAgent { get; set; }
        public DateTime _LastModifiedUtc { get; set; }
        public string _LastModifiedBy { get; set; }
        public string _LastModifiedAgent { get; set; }

        public void MarkComplete()
        {
            IsDone = true;
            Events.Add(new ToDoItemCompletedEvent(this));
        }
    }
}