using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Eng_Part.Models.ViewModels
{
    public class UserModel { 
    
    }

    public class UserSignUpView  
    {
        [Key]
        public int SYSUserID { get; set; }

        public int LOOKUPRoleID { get; set; }
        
        public string RoleName { get; set; }
        
        [Required(ErrorMessage = "* Please enter Login ID ")]
        [Display(Name = "Login ID")]
        public string LoginName { get; set; }
        
        [Required(ErrorMessage = "* Please enter password ")]
        [Display(Name = "Password")]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "* Please enter first name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "* Please enter last name")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        
        public string Gender { get; set; }
    }

    public class UserLoginView
    {
        [Key]
        public int SYSUserID { get; set; }

        [Required(ErrorMessage = "* Please enter Login ID")]
        [Display(Name = "Login ID")]
        public string LoginName { get; set; }

        [Required(ErrorMessage = "* Please enter password")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    } 

}