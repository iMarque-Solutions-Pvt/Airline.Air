using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Alliance_Air_Desk.Models.Model
{
    public class DisruptionModel
    {
        public int rowid { get; set; }
        public int sno { get; set; }
        public string guid { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Flight Number")]
        [DataType(DataType.Text)]
        public string flight_number { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Intimation Ref #")]
        [DataType(DataType.Text)]
        public string intimation_refno { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Origin")]
        [DataType(DataType.Text)]
        public string origin { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Destination")]
        [DataType(DataType.Text)]
        public string destination { get; set; }


        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Actual Departure")]
        [DataType(DataType.DateTime)]
        public string actual_departure { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Actual Arrival")]
        [DataType(DataType.DateTime)]
        public string actual_arrival { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Revised Origin")]
        [DataType(DataType.Text)]
        public string revised_origin { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Revised Destination")]
        [DataType(DataType.Text)]
        public string revised_destination { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Revised Departure")]
        [DataType(DataType.DateTime)]
        public string revised_departure { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Revised Arrival")]
        [DataType(DataType.DateTime)]
        public string revised_arrival { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Disruption Type")]
        [DataType(DataType.Text)]
        public string disruption_type { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "SMS (Yes/No/NA)")]
        [DataType(DataType.Text)]
        public string sms { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Email (Yes/No/NA)")]
        [DataType(DataType.Text)]
        public string email { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Out Calling (Yes/No/NA)")]
        [DataType(DataType.Text)]
        public string out_calling { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Mail Received Time")]
        [DataType(DataType.DateTime)]
        public string mail_received_time { get; set; }

        public string action_time { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Action Status")]
        [DataType(DataType.Text)]
        public string status { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "QC Status")]
        [DataType(DataType.Text)]
        public string QC_status { get; set; }
        public string QC_Doneby { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Remarks")]
        [DataType(DataType.MultilineText)]
        public string remarks { get; set; }
        public string createdBy { get; set; }
        public string createdTime { get; set; }
        public string modifiedBy { get; set; }
        public string modifiedTime { get; set; }
        public string domestic_template { get; set; }
        public string international_template { get; set; }
        public string var1 { get; set; }
        public string var2 { get; set; }
        public string var3 { get; set; }
        public string var4 { get; set; }
        public string var5 { get; set; }
        public string var6 { get; set; }
        public string var7 { get; set; }
        public string var8 { get; set; }


    }
}