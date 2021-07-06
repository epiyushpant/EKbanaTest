using EKbanaTest.DAL;
using EKbanaTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EKbanaTest.Queries
{
    public class RoleQueriesRepo : IRoleQueriesRepo
    {
        private readonly ApplicationDBContext _context;

        public RoleQueriesRepo(ApplicationDBContext context)
        {
            _context = context;
        }

        public Role Find(int Id)
        {
            return _context.Roles.FirstOrDefault(x => x.RoleId == Id);
        }

        public List<Role> GetAll()
        {
            return _context.Roles.ToList();
        }
    }
}
