using Astra.Core.Events;
using Astra.Core.Interfaces;

namespace Astra.Core.Services
{
    public class ToDoItemService : IHandle<ToDoItemCompletedEvent>
    {
        public void Handle(ToDoItemCompletedEvent domainEvent)
        {
            // Do Nothing
        }
    }
}
