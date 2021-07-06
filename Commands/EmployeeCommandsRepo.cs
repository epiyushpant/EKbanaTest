using EKbanaTest.DAL;
using EKbanaTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EKbanaTest.Commands
{
    public class EmployeeCommandsRepo : IEmployeeCommandsRepo
    {


        private readonly ApplicationDBContext _context;

        public EmployeeCommandsRepo(ApplicationDBContext context)
        {
            _context = context;
        }


        public Employee Add(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return employee;

        }

        public Employee Find(int Id)
        {
            var result =_context.Employees.FirstOrDefault(x => x.EmployeeId == Id);
            return result;
        }

        public void  Remove(int EmployeeId)
        {
             Employee emp = _context.Employees.FirstOrDefault(x => x.EmployeeId == EmployeeId);
            _context.Employees.Remove(emp);
            _context.SaveChanges();
            return; 
        }

        public Employee Update(Employee employee)
        {
            _context.Employees.Update(employee);
            _context.SaveChanges();
            return employee;

        }
    }
}
