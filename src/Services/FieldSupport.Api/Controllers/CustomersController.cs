using Astra.Infrastructure;
using FieldSupport.Api.Services;
using FieldSupport.Domain.Maintenance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FieldSupport.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class CustomersController : BaseApiController<ICustomerService, Customer, CustomerSearchContext>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        public CustomersController(ICustomerService service) : base(service)
        {
        }
    }
}