using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astra.Core.SharedKernel
{
    public interface IOptions<T>
    {
        T Value { get; }
    }

    public class Options<T> : IOptions<T>
    {
        private readonly T _Value;

        public Options()
        {
            _Value = Activator.CreateInstance<T>();
        }

        public T Value => _Value;
    }
}
