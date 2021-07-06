using EKbanaTest.DAL;
using EKbanaTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EKbanaTest.Commands
{
    public class RoleCommandsRepo : IRoleCommandsRepo
    {
        private readonly ApplicationDBContext _context;

        public RoleCommandsRepo(ApplicationDBContext context)
        {
            _context = context;
        }

        public Role Add(Role role)
        {
            _context.Roles.Add(role);
            _context.SaveChanges();
            return role;

        }

        public void Remove(int RoleId)
        {
            Role role = _context.Roles.FirstOrDefault(x => x.RoleId == RoleId);
            _context.Roles.Remove(role);
            _context.SaveChanges();
            return;
        }

        public Role Update(Role role)
        {
            _context.Roles.Update(role);
            _context.SaveChanges();
            return role;


        }
    }
}
