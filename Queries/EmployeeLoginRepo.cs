using EKbanaTest.DAL;
using EKbanaTest.DTO;
using EKbanaTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EKbanaTest.Queries
{
    public class EmployeeLoginRepo : IEmployeeLoginRepo
    {
        private readonly ApplicationDBContext _context;

        public EmployeeLoginRepo(ApplicationDBContext context)
        {
            _context = context;
        }

        public Employee ValidateEmployee(EmployeeLogin emp)
        {

           Employee employee = _context.Employees.Where(x => x.Email.ToLower() == emp.Email.ToLower() && x.Passsword == emp.Passsword).FirstOrDefault();

           return employee; 

        }
    }
}
