using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astra.Infrastructure
{
    public class Lazier<T> : Lazy<T> where T : class
    {
        public Lazier(IContainer container)
            : base(() => container.Resolve<T>())
        {
        }
    }
}
