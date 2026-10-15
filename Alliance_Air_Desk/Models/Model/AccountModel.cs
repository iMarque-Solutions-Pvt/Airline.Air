using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Alliance_Air_Desk.Models.Model
{
    public class AccountModel
    {
        public int id { get; set; }
        public int sno { get; set; }

        public string guid { get; set; }

        [Required(ErrorMessage = "User ID is required.")]
        [Display(Name = "User Name")]
        [StringLength(15, MinimumLength = 1, ErrorMessage = "UserName Required Minimum 1 and Maximum 15 Characters")]
        [DataType(DataType.Text)]
        public string userId { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "UserName Required Minimum 3 and Maximum 15 Characters")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Required(ErrorMessage = "Employee Code is required.")]
        [Display(Name = "EmpCode")]
        [DataType(DataType.Text)]
        public string empCode { get; set; }


        [Required(ErrorMessage = "Employee Name/Full Name is required.")]
        [Display(Name = "Employee Name/Full Name")]
        [DataType(DataType.Text)]
        public string empName { get; set; }

        [Required(ErrorMessage = "Privilege is required.")]
        [Display(Name = "Privilege")]
        [DataType(DataType.Text)]
        public string privilege { get; set; }


        [Required(ErrorMessage = "Region is required.")]
        [Display(Name = "Region")]
        [DataType(DataType.Text)]
        public string region { get; set; }
                
        [Required(ErrorMessage = "Privilege is required.")]
        [Display(Name = "Is Active?")]
        [DataType(DataType.Text)]
        public string status { get; set; }
        
        public string createdBy { get; set; }
        public string createdTime { get; set; }
        public string modifiedBy { get; set; }
        public string modifiedTime { get; set; }
    }
}