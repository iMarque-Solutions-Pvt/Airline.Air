using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Alliance_Air_Desk.Models.Model
{
    public class ContentModel
    {

        public int rowid { get; set; }
        public int sno { get; set; }

        public string guid { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Disruption Type")]
        [DataType(DataType.Text)]
        public string disruption_type { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Domestic Template")]
        [DataType(DataType.MultilineText)]
        public string domestic_template { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Domestic Sample Content")]
        [DataType(DataType.MultilineText)]
        public string domestic_sample_sms { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "International Template")]
        [DataType(DataType.MultilineText)]
        public string international_template { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "International SMS Sample Content")]
        [DataType(DataType.MultilineText)]
        public string international_sample_sms { get; set; }

        public List<Content_Template> _Content_Template { get; set; }

    }

    public class Content_Template
    {
        public int rowid { get; set; }
        public int sno { get; set; }
        public string guid { get; set; }
        public string disruption_type { get; set; }
        public string domestic_template { get; set; }
        public string domestic_sample_sms { get; set; }
        public string international_template { get; set; }
        public string international_sample_sms { get; set; }
    }
}