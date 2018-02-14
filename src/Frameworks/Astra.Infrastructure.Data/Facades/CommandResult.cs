using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astra.Facades
{
    public interface ICommandResult<T>
    {
        T Data { get; }
        string Message { get; }

        bool Success { get; }

    }

    public class CommandResult<T> : ICommandResult<T>
    {
        public CommandResult(T data, bool success = true, string message = null)
        {
            Data = data;
            Success = success;
            Message = message;
        }

        public T Data { get; private set; }

        public string Message { get; private set; }

        public bool Success { get; private set; }
    }
}
