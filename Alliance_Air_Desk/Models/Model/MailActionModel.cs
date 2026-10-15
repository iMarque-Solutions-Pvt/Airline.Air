using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Alliance_Air_Desk.Models.Model
{
    public class MailActionModel
    {        
        public int? sno {get;set;}
        public int rowid { get; set; } 
        public string guid { get; set; }

        //[Required(ErrorMessage = "This field is required.")]
        //[Display(Name = "Search")]
        //[DataType(DataType.Text)]
        //public string search { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "From Mail ID")]
        [DataType(DataType.Text)]
        public string fromEmail { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Date of Mail")]
        [DataType(DataType.DateTime)]
        public string date_of_mail { get; set; }

       // [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "PNR")]
        [DataType(DataType.Text)]
        public string pnr { get; set; }

       // [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Mobile No (If any)")]
        [DataType(DataType.Text)]
        public string phoneNo { get; set; }


       // [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Reference ID")]
        [DataType(DataType.Text)]
        public string referenceId { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Mail Subject")]
        [DataType(DataType.Text)]
        public string mailSubject { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Mail Content")]
        [DataType(DataType.MultilineText)]
        public string mailContent { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Type of Mail")]
        [DataType(DataType.Text)]
        public string type_of_mail { get; set; }
        public List<SelectListItem> type_of_mail_List { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "QRC")]
        [DataType(DataType.Text)]
        public string QRC { get; set; }
        public List<SelectListItem> QRC_List { get; set; }


        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "SubType")]
        [DataType(DataType.Text)]
        public string subType { get; set; }
        public List<SelectListItem> subType_List { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Resolution")]
        [DataType(DataType.Text)]
        public string resolution { get; set; }
        public List<SelectListItem> resolution_List { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Resolution2")]
        [DataType(DataType.Text)]
        public string resolution2 { get; set; }
        public List<SelectListItem> resolution2_List { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Template Retrival")]
        [DataType(DataType.MultilineText)]
        public string content_template { get; set; }

        public string status { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Remarks")]
        [DataType(DataType.MultilineText)]
        public string remarks { get; set; }


        public string loggedBy { get; set; }
        public string loggedTime { get; set; }
        public string modifiedBy { get; set; }
        public string modifiedTime { get; set; }
      



    }

    public class Mail_History
    {
        [Display(Name = "S.No")]
        public int sno { get; set; }
        [Display(Name = "ID")]
        public int id { get; set; }
        [Display(Name = "Date")]
        public string date { get; set; }
        [Display(Name = "Loggedby")]
        public string loggedby { get; set; }


        [Display(Name = "Ref. Id")]
        public string referenceId { get; set; }

        [Display(Name = "PNR")]
        public string pnr { get; set; }
        [Display(Name = "QRC")]
        public string Qrc { get; set; }

        [Display(Name = "Maintype")]
        public string maintype { get; set; }
        [Display(Name = "Subtype")]
        public string subtype { get; set; }
        [Display(Name = "Resolution")]
        public string resolution { get; set; }
        [Display(Name = "Resolution")]
        public string resolution2 { get; set; }
        [Display(Name = "Remarks")]
        public string remarks { get; set; }
    }
}