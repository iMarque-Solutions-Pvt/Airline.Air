using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Alliance_Air_Desk.Models.Model
{
    public class InboundModel
    {
        public int registerId { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Calling Number")]
        [DataType(DataType.Text)]
        public string phoneNo { get; set; }

        [Display(Name = "PNR")]
        [DataType(DataType.Text)]
        public string pnr { get; set; }

        [Display(Name = "Name")]
        [DataType(DataType.Text)]
        public string name { get; set; }

        [Display(Name = "Reference Id")]
        [DataType(DataType.Text)]
        public string referenceId { get; set; }

        [Display(Name = "Caller Category")]
        [DataType(DataType.Text)]
        public string callerCategory { get; set; }
        public List<SelectListItem> callerCategory_List { get; set; }

        [Display(Name = "Calling State")]
        [DataType(DataType.Text)]
        public string callingState { get; set; }
        public List<SelectListItem> callingState_List { get; set; }

        [Display(Name = "Language")]
        [DataType(DataType.Text)]
        public string language { get; set; }
        public List<SelectListItem> language_List { get; set; }

        [Display(Name = "QRC")]
        [DataType(DataType.Text)]
        public string qrc { get; set; }

        public List<SelectListItem> qrc_List { get; set; }


        [Display(Name = "Main Type")]
        [DataType(DataType.Text)]
        public string mainType { get; set; }

        public List<SelectListItem> mainType_List { get; set; }


        [Display(Name = "Sub Type")]
        [DataType(DataType.Text)]
        public string subType { get; set; }

        public List<SelectListItem> subType_List { get; set; }


        [Display(Name = "Resolution")]
        [DataType(DataType.Text)]
        public string resolution1 { get; set; }
        [Display(Name = "Request Raised by")]
        public string Requestraisedby { get; set; }
        [Display(Name = "Request Date and time")]
        public string RequestDateandtime { get; set; }
        public List<SelectListItem> Validated { get; set; }
        public List<SelectListItem> resolution1_List { get; set; }
        [Display(Name = "Resolution2")]
        [DataType(DataType.Text)]
        public string resolution2 { get; set; }

        public List<SelectListItem> resolution2_List { get; set; }

        [Display(Name = "Journey Type")]
        [DataType(DataType.Text)]
        public string journeyType { get; set; }

        public List<SelectListItem> journeyType_List { get; set; }

        [Display(Name = "Origin")]
        [DataType(DataType.Text)]
        public string origin { get; set; }

        public List<SelectListItem> origin_List { get; set; }

        [Display(Name = "Destination")]
        [DataType(DataType.Text)]
        public string destination { get; set; }
        public List<SelectListItem> destination_List { get; set; }

        [Display(Name = "Flight No")]
        [DataType(DataType.Text)]
        public string flightNo { get; set; }

        //[Display(Name = "Other Services")]        
        //public bool otherServices { get; set; }
        [Display(Name = "Penalty Amount")]
        [DataType(DataType.Text)]
        public string penaltyAmt { get; set; }


        [Display(Name = "Payment Type")]
        [DataType(DataType.Text)]
        public string paymentType { get; set; }

        public List<SelectListItem> paymentType_List { get; set; }

        [Display(Name = "Payment Card")]
        [DataType(DataType.Text)]
        public string paymentCard { get; set; }

        public List<SelectListItem> paymentCard_List { get; set; }

        [Display(Name = "Card Type")]
        [DataType(DataType.Text)]
        public string cardType { get; set; }

        public List<SelectListItem> cardType_List { get; set; }

        [Display(Name = "Pay Amount")]
        [DataType(DataType.Text)]
        public string payAmount { get; set; }

        [Display(Name = "Bank")]
        [DataType(DataType.Text)]
        public string bank { get; set; }

        [Display(Name = "Payment Status")]
        [DataType(DataType.Text)]
        public string payment_status { get; set; }

        public List<SelectListItem> payment_status_List { get; set; }

        [Display(Name = "Transaction ID")]
        [DataType(DataType.Text)]
        public string transactionId { get; set; }

        //[Display(Name = "Pay Reference Id")]
        //[DataType(DataType.Text)]
        //public string payRefId { get; set; }

        [Display(Name = "Remarks")]
        [DataType(DataType.MultilineText)]
        public string remarks { get; set; }

        [Display(Name = "Escalation Remarks")]
        [DataType(DataType.MultilineText)]
        public string Escalation_remarks { get; set; }

        [Display(Name = "Inbound Status")]
        [DataType(DataType.Text)]
        public string Inb_status { get; set; }
        public List<SelectListItem> Inb_status_List { get; set; }

        [Display(Name = "Call Transfer")]
        [DataType(DataType.Text)]
        public string call_transfer { get; set; }
        public List<SelectListItem> call_transfer_List { get; set; }

        [Display(Name = "If Yes")]
        [DataType(DataType.Text)]
        public string If_yes { get; set; }
        [Display(Name = "Highlight to Supervisor")]
        [DataType(DataType.Text)]


        public string CaseEscalated { get; set; }

        public string maskedPhoneNo { get; set; }

        public List<SelectListItem> Case_Escalated { get; set; }
        public string maskedPhone { get; set; }
        public string campaignId { get; set; }
        public string crtObjectId { get; set; }
        public string userCrtObjectId { get; set; }
        public string customerId { get; set; }
        public string dialerSessionId { get; set; }
        public string maskingEnabled { get; set; }
        public string lead_name { get; set; }
        public string ameyo_userId { get; set; }
        public string callType { get; set; }
        public string leadId { get; set; }
        public string dispositionName { get; set; }
        public string loggedBy { get; set; }
        public string loggedTime { get; set; }
        public List<call_History> _call_History { get; set; }
        public string other_services { get; set; }
        public List<Checkbox_Control> other_services_list { get; set; }

        public int sno { get; set; }
        public int id { get; set; }
        public string status { get; set; }
        // public string guid { get; set; }
        [Display(Name = "Validated")]
        public string ValidatedStatus { get; set; }


        [Display(Name = "Actioned By")]
        public string ActionedBy { get; set; }


        [Display(Name = " Supervisor Remarks")]
        public string ActionBySupervisor { get; set; }


        [Display(Name = "Status")]
        public string SupervisorStatus { get; set; }


        [Display(Name = "Closure Date and Time")]
        public string ClosureDateandTime { get; set; }


        [Display(Name = "ETA For Closure")]
        public string ETAForClosure { get; set; }

        public List<Escalation_call_History> _Escalation_Call { get; set; }

        public string MonthName { get; set; }

        public int TotalRequests { get; set; }

        public int OpenCases { get; set; }

        public int ClosedCases { get; set; }
    }

    public class Checkbox_Control
    {
        public string name { get; set; }
        public int code { get; set; }
        public bool isChecked { get; set; }
        public string status { get; set; }
    }


    public class Response
    {

        public string resultCode { get; set; }
        public string status { get; set; }
        public string msg { get; set; }

    }

    public class call_History
    {
        [Display(Name = "S.No")]
        public int sno { get; set; }
        [Display(Name = "ID")]
        public int id { get; set; }
        public string phoneNo { get; set; }
        [Display(Name = "Date")]

        public string maskedPhoneNo { get; set; }
        [Display(Name = "Date")]
        public string date { get; set; }
        [Display(Name = "Loggedby")]
        public string loggedby { get; set; }

        [Display(Name = "Ref. Id")]
        public string referenceId { get; set; }

        [Display(Name = "PNR")]
        public string pnr { get; set; }

        [Display(Name = "Maintype")]
        public string maintype { get; set; }
        [Display(Name = "Subtype")]
        public string subtype { get; set; }
        [Display(Name = "Resolution")]
        public string resolution { get; set; }
        [Display(Name = "Resolution2")]
        public string resolution2 { get; set; }
        [Display(Name = "Remarks")]
        public string remarks { get; set; }

        public string HighlighttoSupervisor { get; set; }


    }
    public class Escalation_call_History
    {
        [Display(Name = "S.No")]
        public int sno { get; set; }
        [Display(Name = "ID")]
        public int id { get; set; }
        public string phoneNo { get; set; }
        //[Display(Name = "Date")]
        //public string date { get; set; }  
        [Display(Name = "Ref. Id")]
        public string referenceId { get; set; }
        [Display(Name = "PNR")]
        public string pnr { get; set; }
        [Display(Name = "Maintype")]
        public string maintype { get; set; }
        [Display(Name = "Subtype")]
        public string subtype { get; set; }
        [Display(Name = "Remarks")]
        public string Escalation_remarks { get; set; }
        [Display(Name = "Status")]
        public string status { get; set; }
        [Display(Name = "Call Transfer")]
        public string call_transfer { get; set; }
        public string If_yes { get; set; }
        public string loggedBy { get; set; }
        public string loggedTime { get; set; }



    }


}