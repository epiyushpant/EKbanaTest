
using EKbanaTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EKbanaTest.Commands
{
    public interface  IEmployeeCommandsRepo
    {
        //For Update 
       Employee Find(int Id);

       Employee Add(Employee empoyee);

      Employee Update(Employee employee);

      void Remove(int  EmployeeId);

    }
}
