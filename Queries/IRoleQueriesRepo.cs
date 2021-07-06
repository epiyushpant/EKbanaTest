using EKbanaTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EKbanaTest.Queries
{
    public interface IRoleQueriesRepo
    {

        List<Role> GetAll();

        Role Find(int Id);

    }
}
