using EKbanaTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EKbanaTest.Commands
{
    public interface IRoleCommandsRepo
    {
        Role Add(Role role);
        Role Update(Role role);

        void Remove(int RoleId);
    }
}
