using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astra.CommandBus
{
    public abstract class IntegrationCommand
    {
        public Guid Id { get; private set; }
        public DateTime Sent { get; private set; }

        public abstract object AsObject();

        protected IntegrationCommand()
        {
            Id = Guid.NewGuid();
            Sent = DateTime.UtcNow;
        }

    }

    public class IntegrationCommand<T> : IntegrationCommand
    {
        public T Data { get; private set; }
        public string Name { get; private set; }
        public override object AsObject() { return Data; }

        public IntegrationCommand(string name, T data) : base()
        {
            Data = data;
            Name = name;
        }
    }
}
