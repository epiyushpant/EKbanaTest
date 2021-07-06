using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EKbanaTest.DTO
{
    public class EmployeeLogin
    {
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Passsword { get; set; }

        public bool IsPersistant { get; set; }

    }
}
