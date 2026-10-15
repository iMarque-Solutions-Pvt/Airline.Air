using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Alliance_Air_Desk.Models.Model
{
    public class QC_DisruptionModel
    {

        public int rowid { get; set; }
        public string guid { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Resk")]
        [DataType(DataType.Text)]
        public string resk { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Mail Date and Time")]
        [DataType(DataType.DateTime)]
        public string mailDate { get; set; }

        [Display(Name = "Subject")]
        [DataType(DataType.Text)]
        public string subject { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Travel Date")]
        [DataType(DataType.DateTime)]
        public string travelDate { get; set; }

        [Display(Name = "Flight Number")]
        [DataType(DataType.Text)]
        public string flightNo { get; set; }

        [Display(Name = "Scenario")]
        [DataType(DataType.Text)]
        public string scenario { get; set; }
       

        [Display(Name = "CRM Tagging")]
        [DataType(DataType.Text)]
        public string crm_Tagging { get; set; }
     

        [Display(Name = "SMS Sent")]
        [DataType(DataType.Text)]
        public string sms_Sent { get; set; }

        


        [Display(Name = "Mail Sent")]
        [DataType(DataType.Text)]
        public string mail_Sent { get; set; }

     

        [Display(Name = "Remarks")]
        [DataType(DataType.MultilineText)]
        public string remarks { get; set; }
        
    }
}