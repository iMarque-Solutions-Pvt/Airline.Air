using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Alliance_Air_Desk.Models.Model
{
    public class InfoModel
    {
    }
    public class Marquee
    {
        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Marquee Text")]
        public string message { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Backgroud Color")]
        public string bgcolor { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Text Color")]
        public string color { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Scroll Speed (Prefered 5 or 6)")]
        public int? scrollamount { get; set; }
    }
}