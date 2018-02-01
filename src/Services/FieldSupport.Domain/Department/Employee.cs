using FieldSupport.Domain.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldSupport.Domain.Department
{
    public class Employee
    {
        public int Department_Id { get; set; }
        public int Contact_Id { get; set; }
        public virtual DepartmentInfo Department { get; set; }
        public virtual ContactInfo Contact { get; set; }
    }
}
