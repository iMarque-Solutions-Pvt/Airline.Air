using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Alliance_Air_Desk.Models.Model
{
    public class DashboardModel
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
        public List<Hourly_Dashboard> hourly_dashboard { get; set; }
    }


    public class Hourly_Dashboard
    {
        public string name { get; set; }
        public string empCode { get; set; }
        public string privilege { get; set; }
        public string region { get; set; }
        public string date { get; set; }
        public int total { get; set; }
        public int zero { get; set; }
        public int one { get; set; }
        public int two { get; set; }
        public int three { get; set; }
        public int four { get; set; }
        public int five { get; set; }
        public int six { get; set; }
        public int seven { get; set; }
        public int eight { get; set; }
        public int nine { get; set; }
        public int ten { get; set; }
        public int eleven { get; set; }
        public int twelve { get; set; }
        public int thirteen { get; set; }
        public int fourteen { get; set; }
        public int fifteen { get; set; }
        public int sixteen { get; set; }
        public int seventeen { get; set; }
        public int eighteen { get; set; }
        public int nineteen { get; set; }
        public int twenty { get; set; }
        public int twentyOne { get; set; }
        public int twentyTwo { get; set; }
        public int twentyThree { get; set; }

    }
}