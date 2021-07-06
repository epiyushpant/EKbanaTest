using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EKbanaTest.Models
{
    public class Employee
    {

        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Employee Parent is Required")]
        [Display(Name = "Employee Parent Name")]
        
        public int EmployeeParentId { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [StringLength(8, ErrorMessage = "Must be between 5 and 8 character", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Passsword { get; set; }

        [StringLength(8, ErrorMessage ="Must be between 5 and 8 character",MinimumLength =5)]
        [Required(ErrorMessage = "Confirm Password is Required")]

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password ")]
        public string ConfirmPassword { get; set; }

        
        [Required(ErrorMessage = "Role is Required")]
        [Display(Name = "Role Name")]
        public virtual int RoleId { get; set; }

        [ForeignKey("RoleId")]
        public virtual Role Roles { get; set; }


        [DataType(DataType.Date)]
        public string DateOfBirth { get; set; }

    }
}
