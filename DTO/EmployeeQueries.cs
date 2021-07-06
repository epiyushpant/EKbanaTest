using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EKbanaTest.DTO
{
    public class EmployeeQueries
    {

        public int EmployeeId { get; set; }


        public Nullable<int> EmployeeParentId { get; set; }

        [Display(Name = "Employee Parent Name")]
        public string EmployeeParentName { get; set; }

        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Passsword { get; set; }
    
        [Display(Name = "Role")]
        public  int RoleId { get; set; }

        [Display(Name = "Role Name")]
        public  string  RoleName { get; set; }

        [DataType(DataType.Date)]
        public string DateOfBirth { get; set; }
    }
}
