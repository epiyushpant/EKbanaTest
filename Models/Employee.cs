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

      
        [Display(Name = "Employee Parent Name")]
        public Nullable<int> EmployeeParentId { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email Addresss is Required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [StringLength(8, ErrorMessage = "Must be between 5 and 8 character", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Passsword { get; set; }

        /*
        [NotMapped]
        [StringLength(8, ErrorMessage ="Must be between 5 and 8 character",MinimumLength =5)]
        [Required(ErrorMessage = "Confirm Password is Required")]  
       
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password ")]
        [Compare("Password", ErrorMessage ="Confirm password doesnot match")]
        public string ConfirmPassword { get; set; }

        */

        

        [Required(ErrorMessage = "Role is Required")]
        [Display(Name = "Role Name")]
        public virtual int RoleId { get; set; }

        [ForeignKey("RoleId")]
        public virtual Role Roles { get; set; }


        [DataType(DataType.Date)]
        public string DateOfBirth { get; set; }

    }
}
