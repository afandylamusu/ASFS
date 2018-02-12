using Astra.Core.Interfaces;
using Astra.Infrastructure.Data;
using FieldSupport.Domain.Maintenance;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldSupport.Api.Services
{
    public interface ICustomerService : IBaseFacade<Customer, CustomerSearchContext>
    {
    }

    public class CustomerSearchContext : SearchContext
    {
    }

    public class CustomerService : BaseFacade<Customer, CustomerSearchContext>, ICustomerService
    {
        public CustomerService(DbContext context) : base(context)
        {
        }

        public override IQueryable<Customer> SearchQuery(CustomerSearchContext search)
        {
            return EntitySet.Where(q => true);
        }
    }
}
