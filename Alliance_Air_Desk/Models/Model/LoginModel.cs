using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Alliance_Air_Desk.Models.Model
{
    public class LoginModel
    {
        [Required(ErrorMessage = "UserName is Required")]
        [Display(Name = "UserName")]
        [StringLength(15, MinimumLength = 1, ErrorMessage = "Username Required Minimum 1 and Maximum 15 Characters")]
        [DataType(DataType.Text)]
        public string userId { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [Display(Name = "Password")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Password Required Minimum 3 and Maximum 15 Characters")]
        [DataType(DataType.Password)]
        public string password { get; set; }
        public string ipAddress { get; set; }
        public string sessionId { get; set; }

        public int isMobileDevice { get; set; }

    }
}