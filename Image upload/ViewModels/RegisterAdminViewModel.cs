 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Image_upload.ViewModels { 

    public class RegisterAdminViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Confirm passwod")]
        [Compare("Password",ErrorMessage ="password and conformation password dont match.")]
        public string ConfirmPassword { get; set; }
    }
}
