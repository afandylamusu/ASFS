using Astra.Core.Interfaces;
using Astra.Infrastructure.Data;
using FieldSupport.Api.Infrastructure;
using FieldSupport.Domain.Maintenance;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldSupport.Api.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class EngineerSearchContext : SearchContext
    {

    }

    /// <summary>
    /// 
    /// </summary>
    public interface IEngineerService : IBaseFacade<Engineer, EngineerSearchContext>
    {
    }

    /// <summary>
    /// 
    /// </summary>
    public class EngineerService : BaseFacade<Engineer, EngineerSearchContext>, IEngineerService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public EngineerService(FieldSupportContext context) : base(context)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public override IQueryable<Engineer> SearchQuery(EngineerSearchContext search)
        {
            return EntitySet.Where(q => true);
        }
    }
}
