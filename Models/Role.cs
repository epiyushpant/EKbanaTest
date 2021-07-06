using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EKbanaTest.Models
{
    public class Role
    {

        public int RoleId { get; set; }


        [Required(ErrorMessage = "Role is Required")]

        [Display(Name = "Role Name")]
        public string RoleName { get; set; }
    }
}
