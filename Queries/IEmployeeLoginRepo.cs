using EKbanaTest.DTO;
using EKbanaTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EKbanaTest.Queries
{
   public interface IEmployeeLoginRepo
    {

        Employee ValidateEmployee(EmployeeLogin emp);

        
   
    }
}
