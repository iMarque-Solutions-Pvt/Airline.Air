using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Alliance_Air_Desk.Models.Model
{
    public class ReportModel
    {
        [Required(ErrorMessage = "From Date is Required")]
        [Display(Name = "From Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime fromDate { get; set; }

        [Required(ErrorMessage = "To Date is Required")]
        [Display(Name = "To Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime toDate { get; set; }

        [Required(ErrorMessage = "Pls Select Report Name")]
        [Display(Name = "Report")]
        public int? reportName { get; set; }

        public List<SelectListItem> reporNametList { get; set; }
    }
}