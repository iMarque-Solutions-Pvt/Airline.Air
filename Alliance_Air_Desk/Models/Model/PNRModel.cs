using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Alliance_Air_Desk.Models.Model
{
    public class PNRModel
    {
    }

    public class All_Book_Info
    {
        
        [Display(Name = "Error Code")]
        public string err_code { get; set; }

        [Display(Name = "Error Message")]
        public string err_msg { get; set; }

        [Required(ErrorMessage = "Booking code is Required")]
        [Display(Name = "Booking code")]
        [DataType(DataType.Text)]
        public string book_code { get; set; }

        [Display(Name = "Numeric code")]
        [DataType(DataType.Text)]
        public long num_code { get; set; }

        [Display(Name = "Caller")]
        [DataType(DataType.Text)]
        public string caller { get; set; }

        [Display(Name = "Normal Selling Price")]
        [DataType(DataType.Text)]
        public int normal_sales { get; set; }

        [Display(Name = "Balance/outstanding of booking")]
        [DataType(DataType.Text)]
        public int book_balance { get; set; }
        public List<List<string>> pax_list { get; set; }
        public List<List<string>> route_info { get; set; }
        public List<List<string>> route_detail { get; set; }
        public List<List<string>> ssr_detail { get; set; }
        public List<List<object>> book_ancillary_fee { get; set; }
        public List<object> payment_history { get; set; }

        [Display(Name = "Contact")]
        [DataType(DataType.Text)]
        public string contact { get; set; }

        [Display(Name = "Contact2")]
        [DataType(DataType.Text)]
        public string contact2 { get; set; }

        [Display(Name = "Contact Email")]
        [DataType(DataType.Text)]
        public string contact_email { get; set; }

        [Display(Name = "Booking made by")]
        [DataType(DataType.Text)]
        public string book_by { get; set; }

        [Display(Name = "Booking office")]
        [DataType(DataType.Text)]
        public string book_office_by { get; set; }

        [Display(Name = "Booking CCY")]
        [DataType(DataType.Text)]
        public string book_ccy { get; set; }

        [Display(Name = "Origin Destination")]
        [DataType(DataType.Text)]
        public string org_des { get; set; }

        [Display(Name = "Payment time limit")]
        [DataType(DataType.Text)]
        public string pay_limit { get; set; }

        [Display(Name = "Create Time")]
        [DataType(DataType.Text)]
        public string create_time { get; set; }


    }
}