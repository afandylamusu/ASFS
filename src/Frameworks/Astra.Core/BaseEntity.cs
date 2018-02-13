using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Data.Entity
{
    public interface IEntity
    {
        int Id { get; set; }
        bool Active { get; set; }
    }

    public abstract class BaseEntity : IEntity
    {
        public int Id { get; set; }
        
        public bool Active { get; set; }
    }
}
