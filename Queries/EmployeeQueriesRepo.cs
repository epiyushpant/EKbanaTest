using EKbanaTest.DAL;
using EKbanaTest.DTO;
using EKbanaTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EKbanaTest.Queries
{
    public class EmployeeQueriesRepo : IEmployeeQueriesRepo
    {

        private readonly ApplicationDBContext _context;

        public EmployeeQueriesRepo(ApplicationDBContext context)
        {
            _context = context;
        }

        public EmployeeQueries Find(int Id)
        {
          
           var result = (
           from E1 in _context.Employees
           join E2 in _context.Employees on E1.EmployeeParentId equals E2.EmployeeId into r
           from emp in r.DefaultIfEmpty()
           join role in _context.Roles on E1.RoleId equals role.RoleId

           select new EmployeeQueries
           {

               EmployeeId = E1.EmployeeId,
               EmployeeParentId = emp.EmployeeId,
               EmployeeParentName = emp.Name,
               Name = E1.Name,
               Email = E1.Email,
               Passsword = E1.Passsword,
               RoleId = role.RoleId,
               RoleName = role.RoleName,
               DateOfBirth = E1.DateOfBirth
           }).FirstOrDefault(x => x.EmployeeId == Id);

            return result; 
        }

        public List<EmployeeQueries> GetAll()
        {

            var result = (
            from  E1 in _context.Employees 
            join  E2 in _context.Employees on E1.EmployeeParentId equals E2.EmployeeId into r
            from emp in r.DefaultIfEmpty()
            join  role in _context.Roles on E1.RoleId equals role.RoleId
        
            select new EmployeeQueries
            {
                   
                    EmployeeId = E1.EmployeeId,
                    EmployeeParentId = emp.EmployeeId,
                    EmployeeParentName = emp.Name,
                    Name = E1.Name,
                    Email = E1.Email,
                    Passsword = E1.Passsword,
                    RoleId = role.RoleId,
                    RoleName  = role.RoleName,
                    DateOfBirth = E1.DateOfBirth
            }).ToList();

            return result;

         
        }
    }
}
