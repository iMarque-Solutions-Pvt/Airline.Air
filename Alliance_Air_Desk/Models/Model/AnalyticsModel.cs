using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Mvc;

namespace Alliance_Air_Desk.Models.Model
{
    public class AnalyticsModel
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
        public string SearchType { get; set; }
        public List<SelectListItem> reporNametList { get; set; }

        //public List<Hourly_Dashboard> hourly_dashboard { get; set; }
    }
    [DataContract]
    public class DataPoint
    {
        public DataPoint(string label, double y)
        {
            this.Label = label;
            this.Y = y;
        }
        public DataPoint()
        {
        }

        //Explicitly setting the name to be used while serializing to JSON.
        [DataMember(Name = "label")]
        public string Label = "";

        //Explicitly setting the name to be used while serializing to JSON.
        [DataMember(Name = "y")]
        public Nullable<double> Y = null;
    }
    public class DateRange
    {
        public string fromDate { get; set; }
        public string toDate { get; set; }
    }
}