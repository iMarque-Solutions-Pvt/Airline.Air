using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Alliance_Air_Desk.Classes
{
    [Serializable]
    public class General
    {
        public static string dbname;
        SqlHelper Helper;
        public General()
        {
            Helper = new SqlHelper();
        }


        public DataTable Check_Login(string userId, string password, string ipAddress, string isMobileDevice, string sessionid)
        {
            DataTable _Data = new DataTable("_Data");
            try
            {
                System.Collections.Specialized.HybridDictionary Params = new System.Collections.Specialized.HybridDictionary(1);
                Params.Add("@userId", userId);
                Params.Add("@password", password);
                Params.Add("@ipAddress", ipAddress);
                Params.Add("@isMobileDevice", isMobileDevice);
                Params.Add("@sessionid", sessionid);

                _Data = Helper.ReturnDataTable("SP_Check_Login", Params);
            }
            catch (Exception ex)
            {
                throw;
            }
            return _Data;
        }


        public DataTable Content_Template_Management(string rowid, string guid, string disruption_type, string domestic_template, string domestic_sample_sms, string international_template, string international_sample_sms, string userID, string privilege, string region)
        {
            DataTable MenuData = new DataTable("MenuData");
            try
            {
                System.Collections.Specialized.HybridDictionary Params = new System.Collections.Specialized.HybridDictionary(1);
                Params.Add("@rowid", rowid);
                Params.Add("@guid", guid);
                Params.Add("@disruption_type", disruption_type);
                Params.Add("@domestic_template", domestic_template);
                Params.Add("@domestic_sample_sms", domestic_sample_sms);
                Params.Add("@international_template", international_template);
                Params.Add("@international_sample_sms", international_sample_sms);
                Params.Add("@userID", userID);
                Params.Add("@privilege", privilege);
                Params.Add("@region", region);



                MenuData = Helper.ReturnDataTable("SP_Template_Management", Params);
            }
            catch (Exception ex)
            {
                throw;
            }
            return MenuData;
        }


        public DataTable get_Reports(string fromDate, string toDate, string reportName, string userID, string privilege, string region)
        {
            DataTable _Data = new DataTable("_Data");
            try
            {
                System.Collections.Specialized.HybridDictionary Params = new System.Collections.Specialized.HybridDictionary(1);
                Params.Add("@fromDate", fromDate);
                Params.Add("@toDate", toDate);
                Params.Add("@reportName", reportName);
                Params.Add("@userID", userID);
                Params.Add("@privilege", privilege);
                Params.Add("@region", region);

                _Data = Helper.ReturnDataTable("SP_Get_Reports", Params);
            }
            catch (Exception ex)
            {
                throw;
            }
            return _Data;
        }
        public DataTable Add_Inbound_Calls(int id,int registerId, string phoneNo, string pnr, string referenceId, string name, string callerCategory, string callingState,
            string language, string qrc, string mainType, string subType, string resolution1, string CaseEscalated, string journeyType, string origin, string destination, string flightNo, string penaltyAmt, string otherServices, string paymentType, string paymentCard, string cardType, string payAmount, string bank, string payment_status, string transactionId, string remarks,
            string campaignId, string crtObjectId, string userCrtObjectId, string customerId, string dialerSessionId, string maskingEnabled, string lead_name, string leadId, string callType, string ameyo_userId, string escalation_remarks,string Inbound_status,string call_transfer, string If_yes,string userID, string privilege, string region)
        {
            DataTable _Data = new DataTable("_Data");
            try
            {
                System.Collections.Specialized.HybridDictionary Params = new System.Collections.Specialized.HybridDictionary(1);

                Params.Add("@id", id);
                Params.Add("@registerId", registerId);
                Params.Add("@phoneNo", phoneNo);
                Params.Add("@pnr", pnr);
                Params.Add("@referenceId", referenceId);
                Params.Add("@name", name);
                Params.Add("@callerCategory", callerCategory);
                Params.Add("@callingState", callingState);
                Params.Add("@language", language);
                Params.Add("@qrc", qrc);
                Params.Add("@mainType", mainType);
                Params.Add("@subType", subType);
                Params.Add("@resolution", resolution1);
                Params.Add("@CaseEscalated", CaseEscalated);
                Params.Add("@journeyType", journeyType);
                Params.Add("@origin", origin);
                Params.Add("@destination", destination);
                Params.Add("@flightNo", flightNo);
                Params.Add("@penaltyAmt", penaltyAmt);
                Params.Add("@otherServices", otherServices);
                Params.Add("@paymentType", paymentType);
                Params.Add("@paymentCard", paymentCard);
                Params.Add("@cardType", cardType);
                Params.Add("@payAmount", payAmount);
                Params.Add("@bank", bank);
                Params.Add("@payment_status", payment_status);
                Params.Add("@transactionId", transactionId);
                Params.Add("@remarks", remarks);
                Params.Add("@campaignId", campaignId);
                Params.Add("@crtObjectId", crtObjectId);
                Params.Add("@userCrtObjectId", userCrtObjectId);
                Params.Add("@customerId", customerId);
                Params.Add("@dialerSessionId", dialerSessionId);
                Params.Add("@maskingEnabled", maskingEnabled);
                Params.Add("@lead_name", lead_name);
                Params.Add("@leadId", leadId);
                Params.Add("@callType", callType);
                Params.Add("@ameyo_userId", ameyo_userId);
                Params.Add("@escalation_remarks", escalation_remarks);
                Params.Add("@Inbound_status", Inbound_status);
                Params.Add("@call_transfer", call_transfer);
                Params.Add("@If_yes", If_yes);   
                Params.Add("@userID", userID);
                Params.Add("@privilege", privilege);
                Params.Add("@region", region);


                _Data = Helper.ReturnDataTable("SP_Add_Inbound_Call_Details", Params);
            }
            catch (Exception ex)
            {
                throw;
            }
            return _Data;
        }
        public DataTable Save_Inbound_Supervisor_Action(
    int InboundId,
    string ValidatedStatus,
    string ActionedBy,
    string ActionBySupervisor,
    string SupervisorStatus,
    string ClosureDateandTime
         //   ,
    //string ETAForClosure
            )
        {
            DataTable _Data = new DataTable("_Data");

            try
            {
                System.Collections.Specialized.HybridDictionary Params =
                    new System.Collections.Specialized.HybridDictionary(1);


                Params.Add("@InboundId", InboundId);
                Params.Add("@ValidatedStatus", ValidatedStatus);
                Params.Add("@ActionedBy", ActionedBy);
                Params.Add("@ActionBySupervisor", ActionBySupervisor);
                Params.Add("@SupervisorStatus", SupervisorStatus);
                Params.Add("@ClosureDateandTime", ClosureDateandTime);
               // Params.Add("@ETAForClosure", ETAForClosure);

                //Params.Add("@userID", userID);
//Params.Add("@privilege", privilege);
                //Params.Add("@region", region);


                _Data = Helper.ReturnDataTable(
                    "UspSaveInboundSupervisorAction",
                    Params
                );
            }
            catch (Exception ex)
            {
                throw;
            }

            return _Data;
        }
        public DataTable Add_MailAction(string rowid, string guid, string fromEmail, string Mail_date, string pnr, string phoneNo, string referenceId, string mailSubject, string mailContent,string QRC, string type_of_mail, string subType, string resolution, string resolution2, string content_template, string remarks,
           string userID, string privilege, string region)
        {
            DataTable _Data = new DataTable("_Data");
            try
            {
                System.Collections.Specialized.HybridDictionary Params = new System.Collections.Specialized.HybridDictionary(1);


                Params.Add("@rowid", rowid);
                Params.Add("@guid", guid);
                Params.Add("@fromEmail", fromEmail);
                Params.Add("@Mail_date", Mail_date);
                Params.Add("@pnr", pnr);
                Params.Add("@phoneNo", phoneNo);
                Params.Add("@referenceId", referenceId);
                Params.Add("@mailSubject", mailSubject);
                Params.Add("@mailContent", mailContent);
                Params.Add("@QRC", QRC);
                Params.Add("@type_of_mail", type_of_mail);
                Params.Add("@subType", subType);
                Params.Add("@resolution", resolution);
                Params.Add("@resolution2", resolution2);
                Params.Add("@content_template", content_template);
                Params.Add("@remarks", remarks);
                Params.Add("@userID", userID);
                Params.Add("@privilege", privilege);
                Params.Add("@region", region);


                _Data = Helper.ReturnDataTable("SP_Add_MailAction_Details", Params);
            }
            catch (Exception ex)
            {
                throw;
            }
            return _Data;
        }


        public DataTable Disruption_Managment(string rowid, string guid, string flight_number, string intimation_refno, string origin, string destination, string actual_departure, string actual_arrival, string revised_origin, string revised_destination, string revised_departure, string revised_arrival, string disruption_type, string sms, string email, string out_calling, string mail_received_time, string status, string QC_status, string remarks, string userID, string privilege, string region)
        {
            DataTable _Data = new DataTable("_Data");
            try
            {
                System.Collections.Specialized.HybridDictionary Params = new System.Collections.Specialized.HybridDictionary(1);


                Params.Add("@rowid", rowid);
                Params.Add("@guid", guid);
                Params.Add("@flight_number", flight_number);
                Params.Add("@intimation_refno", intimation_refno);
                Params.Add("@origin", origin);
                Params.Add("@destination", destination);
                Params.Add("@actual_departure", actual_departure);
                Params.Add("@actual_arrival", actual_arrival);
                Params.Add("@revised_origin", revised_origin);
                Params.Add("@revised_destination", revised_destination);
                Params.Add("@revised_departure", revised_departure);
                Params.Add("@revised_arrival", revised_arrival);
                Params.Add("@disruption_type", disruption_type);
                Params.Add("@sms", sms);
                Params.Add("@email", email);
                Params.Add("@out_calling", out_calling);
                Params.Add("@mail_received_time", mail_received_time);
                Params.Add("@status", status); 
                Params.Add("@QC_status", QC_status);
                Params.Add("@remarks", remarks);
                Params.Add("@userID", userID);
                Params.Add("@privilege", privilege);
                Params.Add("@region", region);

                _Data = Helper.ReturnDataTable("SP_Disruption_Managment", Params);
            }
            catch (Exception ex)
            {
                throw;
            }
            return _Data;
        }

        public DataTable QCDisruption_Managment(string rowid, string guid, string resk, string mailDate, string subject, string travelDate, string flightNo, string scenario, string crm_Tagging, string sms_Sent, string mail_Sent, string remarks, string userID, string privilege, string region)
        {
            DataTable _Data = new DataTable("_Data");
            try
            {
                System.Collections.Specialized.HybridDictionary Params = new System.Collections.Specialized.HybridDictionary(1);
                Params.Add("@rowid", rowid);
                Params.Add("@guid", guid);
                Params.Add("@resk", resk);
                Params.Add("@mailDate", mailDate);
                Params.Add("@subject", subject);
                Params.Add("@travelDate", travelDate);
                Params.Add("@flightNo", flightNo);
                Params.Add("@scenario", scenario);
                Params.Add("@crm_Tagging", crm_Tagging);
                Params.Add("@sms_Sent", sms_Sent);
                Params.Add("@mail_Sent", mail_Sent);
                Params.Add("@remarks", remarks);
                Params.Add("@userID", userID);
                Params.Add("@privilege", privilege);
                Params.Add("@region", region);

                _Data = Helper.ReturnDataTable("SP_QCDisruption_Managment", Params);
            }
            catch (Exception ex)
            {
                throw;
            }
            return _Data;
        }


        public DataTable Register_Call_Details(string searchType, string phone, string pnrNo, string campaignId, string crtObjectId, string userCrtObjectId, string customerId, string sessionId, string maskingEnabled, string lead_name, string leadId, string callType, string ameyo_userId, string crm_userID)
        {
            DataTable _Data = new DataTable("_Data");
            try
            {
                System.Collections.Specialized.HybridDictionary Params = new System.Collections.Specialized.HybridDictionary(1);

                Params.Add("@searchType", searchType);
                Params.Add("@phone", phone);
                Params.Add("@pnrNo", pnrNo);
                Params.Add("@campaignId", campaignId);
                Params.Add("@crtObjectId", crtObjectId);
                Params.Add("@userCrtObjectId", userCrtObjectId);
                Params.Add("@customerId", customerId);
                Params.Add("@sessionId", sessionId);
                Params.Add("@maskingEnabled", maskingEnabled);
                Params.Add("@lead_name", lead_name);
                Params.Add("@leadId", leadId);
                Params.Add("@callType", callType);
                Params.Add("@ameyo_userId", ameyo_userId);
                Params.Add("@crm_userID", crm_userID);



                _Data = Helper.ReturnDataTable("SP_Register_Call_Details", Params);
            }
            catch (Exception ex)
            {
                throw;
            }
            return _Data;
        }



        public DataTable User_Management(string guid, string userId, string password, string empCode, string empName, string privilege, string region, string status, string LoggedInuserID, string LoggedInprivilege)
        {
            DataTable _Data = new DataTable("_Data");
            try
            {
                System.Collections.Specialized.HybridDictionary Params = new System.Collections.Specialized.HybridDictionary(1);

                Params.Add("@guid", guid);
                Params.Add("@userId", userId);
                Params.Add("@password", password);
                Params.Add("@empCode", empCode);
                Params.Add("@empName", empName);
                Params.Add("@privilege", privilege);
                Params.Add("@region", region);
                Params.Add("@status", status);
                Params.Add("@LoggedInuserID", LoggedInuserID);
                Params.Add("@LoggedInprivilege", LoggedInprivilege);

                _Data = Helper.ReturnDataTable("SP_User_Management", Params);
            }
            catch (Exception ex)
            {
                throw;
            }
            return _Data;
        }

        public DataTable Get_UI_Elements(string criteria, string condition1, string condition2, string condition3, string userID, string privilege, string region)
        {
            DataTable _Data = new DataTable("_Data");
            try
            {
                System.Collections.Specialized.HybridDictionary Params = new System.Collections.Specialized.HybridDictionary(1);
                Params.Add("@criteria", criteria);
                Params.Add("@condition1", condition1);
                Params.Add("@condition2", condition2);
                Params.Add("@condition3", condition3);
                Params.Add("@userID", userID);
                Params.Add("@privilege", privilege);
                Params.Add("@region", region);

                _Data = Helper.ReturnDataTable("SP_UI_Elements", Params);
            }
            catch (Exception ex)
            {
                throw;
            }
            return _Data;
        }

        public DataTable Bulk_Data_Upload(string fileName, string notes, string userID, string privilege, string zone)
        {
            DataTable MenuData = new DataTable("MenuData");
            try
            {
                System.Collections.Specialized.HybridDictionary Params = new System.Collections.Specialized.HybridDictionary(1);

                Params.Add("@fileName", fileName);
                Params.Add("@notes", notes);
                Params.Add("@userID", userID);
                Params.Add("@privilege", privilege);
                Params.Add("@zone", zone);

                MenuData = Helper.ReturnDataTable("SP_Bulk_Load_Covid_Master_Cases", Params);
            }
            catch (Exception ex)
            {
                throw;
            }
            return MenuData;
        }

        //public DataTable Get_IOBLR_UI_Elements(string Criteria, string Condition1, string Condition2, string Condition3, string Condition4, string Condition5)
        //{
        //    DataTable _Data = new DataTable("_Data");
        //    try
        //    {
        //        System.Collections.Specialized.HybridDictionary Params = new System.Collections.Specialized.HybridDictionary(1);
        //        Params.Add("@Criteria", Criteria);
        //        Params.Add("@Condition1", Condition1);
        //        Params.Add("@Condition2", Condition2);
        //        Params.Add("@Condition3", Condition3);
        //        Params.Add("@Condition4", Condition4);
        //        Params.Add("@Condition5", Condition5);

        //        _Data = Helper.ReturnDataTable("SP_GETUI_ELEMENTS", Params);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //    return _Data;
        //}


        public DataTable Get_IOBLR_Call_History(string Process, string SearchType, string MobileNo)
        {
            DataTable _Data = new DataTable("_Data");
            try
            {
                System.Collections.Specialized.HybridDictionary Params = new System.Collections.Specialized.HybridDictionary(1);
                Params.Add("@Process", Process);
                Params.Add("@SearchType", SearchType);
                Params.Add("@Number", MobileNo);

                _Data = Helper.ReturnDataTable("SP_Get_Call_History", Params);
            }
            catch (Exception ex)
            {
                throw;
            }
            return _Data;
        }

        public DataTable Add_IOBLR_calls(string phone, string monthCode, string userId, string disposition, string payMode, string remarks, string nextActionDate, string MobileDevice)
        {
            DataTable _Data = new DataTable("_Data");
            try
            {
                System.Collections.Specialized.HybridDictionary Params = new System.Collections.Specialized.HybridDictionary(1);

                Params.Add("@phone", phone);
                Params.Add("@monthCode", monthCode);
                Params.Add("@userId", userId);
                Params.Add("@disposition", disposition);
                Params.Add("@payMode", payMode);
                Params.Add("@remarks", remarks);
                Params.Add("@nextActionDate", nextActionDate);
                Params.Add("@MobileDevice", MobileDevice);


                _Data = Helper.ReturnDataTable("SP_INSERT_IOBLR_MOBILEAPP", Params);
            }
            catch (Exception ex)
            {
                throw;
            }
            return _Data;
        }


        public DataTable Get_loan_recovery_calls(string phone)
        {
            DataTable _Data = new DataTable("_Data");
            try
            {
                System.Collections.Specialized.HybridDictionary Params = new System.Collections.Specialized.HybridDictionary(1);
                Params.Add("@phone", phone);

                _Data = Helper.ReturnDataTable("Sp_IOBL_MobileApp_Information", Params);
            }
            catch (Exception ex)
            {
                throw;
            }
            return _Data;
        }





        ////////////////UCV_EMI/////////////////


        public DataTable Get_UCV_EMI_UI_Elements(string Criteria, string Condition1, string Condition2, string Condition3, string Condition4, string Condition5)
        {
            DataTable _Data = new DataTable("_Data");
            try
            {
                System.Collections.Specialized.HybridDictionary Params = new System.Collections.Specialized.HybridDictionary(1);
                Params.Add("@Criteria", Criteria);
                Params.Add("@Condition1", Condition1);
                Params.Add("@Condition2", Condition2);
                Params.Add("@Condition3", Condition3);
                Params.Add("@Condition4", Condition4);
                Params.Add("@Condition5", Condition5);

                _Data = Helper.ReturnDataTable("SP_TVS_TMT_GETUI_ELEMENTS", Params);
            }
            catch (Exception ex)
            {
                throw;
            }
            return _Data;
        }


        public DataTable Get_SLP_Followup_Details(string reportID, string stdate, string enDate, string userName, string Role, string Apptype)
        {
            DataTable _Data = new DataTable("_Data");
            try
            {
                System.Collections.Specialized.HybridDictionary Params = new System.Collections.Specialized.HybridDictionary(1);
                Params.Add("@ReportName", reportID);
                Params.Add("@StDate", stdate);
                Params.Add("@EndDate", enDate);
                Params.Add("@userName", userName);
                Params.Add("@Privilege", Role);
                Params.Add("@Apptype", Apptype);


                _Data = Helper.ReturnDataTable("SP_SELF_PAY_GETREPORTS", Params);
            }
            catch (Exception ex)
            {
                throw;
            }
            return _Data;
        }

        public DataTable Get_SLP_Call_History(string Process, string SearchType, string MobileNo)
        {
            DataTable _Data = new DataTable("_Data");
            try
            {
                System.Collections.Specialized.HybridDictionary Params = new System.Collections.Specialized.HybridDictionary(1);
                Params.Add("@Process", Process);
                Params.Add("@SearchType", SearchType);
                Params.Add("@Number", MobileNo);

                _Data = Helper.ReturnDataTable("SP_Get_Call_History", Params);
            }
            catch (Exception ex)
            {
                throw;
            }
            return _Data;
        }

        public DataTable Add_EMI_Call_Details(string monthcode, string agreementNo, string customer_number, string disposition, string subDisposition, string nextActionDate, string remarks, string updateAllRecords, string userId, string callType, string customerId, string MobileDevice)
        {
            DataTable _Data = new DataTable("_Data");
            try
            {
                System.Collections.Specialized.HybridDictionary Params = new System.Collections.Specialized.HybridDictionary(1);

                Params.Add("@monthcode", monthcode);
                Params.Add("@agreementNo", agreementNo);
                Params.Add("@phone", customer_number);
                Params.Add("@disposition", disposition);
                Params.Add("@subDisposition", subDisposition);
                Params.Add("@nextActionDate", nextActionDate);
                Params.Add("@remarks", remarks);
                Params.Add("@updateAllRecords", updateAllRecords);
                Params.Add("@userId", userId);
                Params.Add("@callType", callType);
                Params.Add("@customerId", customerId);
                Params.Add("@MobileDevice", MobileDevice);


                _Data = Helper.ReturnDataTable("SP_INSERT_UCVEMI_MOBILEAPP", Params);
            }
            catch (Exception ex)
            {
                throw;
            }
            return _Data;
        }


        //public DataTable get_EMICalling_Customer_Details(string agmtNo)
        //{
        //    DataTable _Data = new DataTable("_Data");
        //    try
        //    {
        //        System.Collections.Specialized.HybridDictionary Params = new System.Collections.Specialized.HybridDictionary(1);
        //        Params.Add("@agmtNo", agmtNo);

        //        _Data = Helper.ReturnDataTable("SP_SLP_MobileApp_Information", Params);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //    return _Data;
        //}

        /////////////Tenure and Mature///////////

        public DataTable Get_TMT_UI_Elements(string Criteria, string Condition1, string Condition2, string Condition3, string Condition4, string Condition5)
        {
            DataTable _Data = new DataTable("_Data");
            try
            {
                System.Collections.Specialized.HybridDictionary Params = new System.Collections.Specialized.HybridDictionary(1);
                Params.Add("@Criteria", Criteria);
                Params.Add("@Condition1", Condition1);
                Params.Add("@Condition2", Condition2);
                Params.Add("@Condition3", Condition3);
                Params.Add("@Condition4", Condition4);
                Params.Add("@Condition5", Condition5);

                _Data = Helper.ReturnDataTable("SP_TVS_TMT_GETUI_ELEMENTS", Params);
            }
            catch (Exception ex)
            {
                throw;
            }
            return _Data;
        }


        public DataTable Get_TNM_Call_History(string Process, string SearchType, string MobileNo)
        {
            DataTable _Data = new DataTable("_Data");
            try
            {
                System.Collections.Specialized.HybridDictionary Params = new System.Collections.Specialized.HybridDictionary(1);
                Params.Add("@Process", Process);
                Params.Add("@SearchType", SearchType);
                Params.Add("@Number", MobileNo);

                _Data = Helper.ReturnDataTable("SP_Get_Call_History", Params);
            }
            catch (Exception ex)
            {
                throw;
            }
            return _Data;
        }


        public DataTable Add_TenureMature_calls(string phone, string agreementNo, string userId, string disposition, string paid_amount, string waiver_amount, string receiptNo, string remarks, string nextActionDate, string MobileDevice)
        {
            DataTable _Data = new DataTable("_Data");
            try
            {
                System.Collections.Specialized.HybridDictionary Params = new System.Collections.Specialized.HybridDictionary(1);

                Params.Add("@phone", phone);
                Params.Add("@agreementNo", agreementNo);
                Params.Add("@userId", userId);
                Params.Add("@disposition", disposition);
                Params.Add("@paid_amount", paid_amount);
                Params.Add("@waiver_amount", waiver_amount);
                Params.Add("@receiptNo", receiptNo);
                Params.Add("@remarks", remarks);
                Params.Add("@nextActionDate", nextActionDate);
                Params.Add("@MobileDevice", MobileDevice);


                _Data = Helper.ReturnDataTable("SP_INSERT_TVSTMT_MOBILEAPP", Params);
            }
            catch (Exception ex)
            {
                throw;
            }
            return _Data;
        }


        public DataTable get_Call_TANDM_call_Details(string Option, string phone)
        {
            DataTable _Data = new DataTable("_Data");
            try
            {
                System.Collections.Specialized.HybridDictionary Params = new System.Collections.Specialized.HybridDictionary(1);
                Params.Add("@Option", Option);
                Params.Add("@phone", phone);

                _Data = Helper.ReturnDataTable("SP_TMT_MobileApp_Information", Params);
            }
            catch (Exception ex)
            {
                throw;
            }
            return _Data;
        }


        ////////////////////////End    













        public DataTable Get_ITS_Reports(string ReportName, string startDate, string endDate, string bufval1, string bufval2, string UserName, string EmpCode, string Privilege, string Process, string Region, string RiskOwner, string ReportAccess)
        {
            DataTable MenuData = new DataTable("MenuData");
            try
            {
                System.Collections.Specialized.HybridDictionary Params = new System.Collections.Specialized.HybridDictionary(1);
                Params.Add("@ReportName", ReportName);
                Params.Add("@startDate", startDate);
                Params.Add("@endDate", endDate);
                Params.Add("@bufval1", bufval1);
                Params.Add("@bufval2", bufval2);
                Params.Add("@UserName", UserName);
                Params.Add("@EmpCode", EmpCode);
                Params.Add("@Privilege", Privilege);
                Params.Add("@Process", Process);
                Params.Add("@Region", Region);
                Params.Add("@RiskOwner", RiskOwner);
                Params.Add("@ReportAccess", ReportAccess);


                MenuData = Helper.ReturnDataTable("SP_Get_ITS_Report", Params);
            }
            catch (Exception ex)
            {
                throw;
            }
            return MenuData;
        }

        public DataTable ITS_Ticket_Tracking(string TicketNo, string UserName, string EmpCode, string Privilege, string Process, string Region, string RiskOwner)
        {
            DataTable _Data = new DataTable("_Data");
            try
            {
                System.Collections.Specialized.HybridDictionary Params = new System.Collections.Specialized.HybridDictionary(1);
                Params.Add("@TicketNo", TicketNo);
                Params.Add("@UserName", UserName);
                Params.Add("@EmpCode", EmpCode);
                Params.Add("@Privilege", Privilege);
                Params.Add("@Process", Process);
                Params.Add("@Region", Region);
                Params.Add("@RiskOwner", RiskOwner);

                _Data = Helper.ReturnDataTable("SP_ITS_Tracking", Params);
            }
            catch (Exception ex)
            {
                throw;
            }
            return _Data;
        }

        public DataTable Get_ITS_UserProfile(string UserName, string EmpCode, string Privilege, string Process, string Region)
        {
            DataTable _Data = new DataTable("_Data");
            try
            {
                System.Collections.Specialized.HybridDictionary Params = new System.Collections.Specialized.HybridDictionary(1);
                Params.Add("@UserName", UserName);
                Params.Add("@EmpCode", EmpCode);
                Params.Add("@Privilege", Privilege);
                Params.Add("@Process", Process);
                Params.Add("@Region", Region);

                _Data = Helper.ReturnDataTable("SP_ITS_Get_UserProfile", Params);
            }
            catch (Exception ex)
            {
                throw;
            }
            return _Data;
        }


        public DataTable GetUIElements(string Condition1, string Condition2, string Condition3, string Condition4, string Condition5)
        {
            DataTable _Data = new DataTable("_Data");
            try
            {
                System.Collections.Specialized.HybridDictionary Params = new System.Collections.Specialized.HybridDictionary(1);
                Params.Add("@Condition1", Condition1);
                Params.Add("@Condition2", Condition2);
                Params.Add("@Condition3", Condition3);
                Params.Add("@Condition4", Condition4);
                Params.Add("@Condition5", Condition5);

                _Data = Helper.ReturnDataTable("SP_UI_ELEMENT", Params);
            }
            catch (Exception ex)
            {
                throw;
            }
            return _Data;
        }

        public DataTable AddLocation(int RegionID, string RegionName, string ShortCode, string StatusID)
        {
            DataTable _Data = new DataTable("_Data");
            try
            {
                System.Collections.Specialized.HybridDictionary Params = new System.Collections.Specialized.HybridDictionary(1);
                Params.Add("@RegionID", RegionID);
                Params.Add("@RegionName", RegionName);
                Params.Add("@ShortCode", ShortCode);
                Params.Add("@StatusID", StatusID);

                _Data = Helper.ReturnDataTable("SP_Add_Region", Params);
            }
            catch (Exception ex)
            {
                throw;
            }
            return _Data;
        }


        public DataTable ITS_Create_New_Ticket(string Region, string Branch, string Floor, string Conventional_Field, string TicketTo, string Department, string Subject, string Category, string SubCategory, string Priority,
        string Description, string ContatPerson, string ContactNo, string ContactMail, string Status, string LoginUserName, string EmpCode, string Privilege, string Process, string LoginRegion)
        {
            DataTable _Data = new DataTable("_Data");
            try
            {
                System.Collections.Specialized.HybridDictionary Params = new System.Collections.Specialized.HybridDictionary(1);
                Params.Add("@Region", Region);
                Params.Add("@Branch", Branch);
                Params.Add("@Floor", Floor);
                Params.Add("@Conventional_Field", Conventional_Field);
                Params.Add("@TicketTo", TicketTo);
                Params.Add("@Department", Department);
                Params.Add("@Subject", Subject);
                Params.Add("@Category", Category);
                Params.Add("@SubCategory", SubCategory);
                Params.Add("@Priority", Priority);
                Params.Add("@Description", Description);
                Params.Add("@ContatPerson", ContatPerson);
                Params.Add("@ContactNo", ContactNo);
                Params.Add("@ContactMail", ContactMail);
                Params.Add("@Status", Status);
                Params.Add("@LoginUserName", LoginUserName);
                Params.Add("@EmpCode", EmpCode);
                Params.Add("@Privilege", Privilege);
                Params.Add("@Process", Process);
                Params.Add("@LoginRegion", LoginRegion);


                _Data = Helper.ReturnDataTable("SP_ITS_Create_New_Ticket", Params);
            }
            catch (Exception ex)
            {
                throw;
            }
            return _Data;
        }












        public DataTable ITS_Modify_Ticket(string TicketNo, string Region, string Branch, string Floor, string Conventional_Field, string TicketTo, string Department, string Subject, string Category, string SubCategory, string Priority,
       string Description, string ContatPerson, string ContactNo, string ContactMail, string Status, string LoginUserName, string EmpCode, string Privilege, string Process, string LoginBranch)
        {
            DataTable _Data = new DataTable("_Data");
            try
            {
                System.Collections.Specialized.HybridDictionary Params = new System.Collections.Specialized.HybridDictionary(1);
                Params.Add("@TicketNo", TicketNo);
                Params.Add("@Region", Region);
                Params.Add("@Branch", Branch);
                Params.Add("@Floor", Floor);
                Params.Add("@Conventional_Field", Conventional_Field);
                Params.Add("@TicketTo", TicketTo);
                Params.Add("@Department", Department);
                Params.Add("@Subject", Subject);
                Params.Add("@Category", Category);
                Params.Add("@SubCategory", SubCategory);
                Params.Add("@Priority", Priority);
                Params.Add("@Description", Description);
                Params.Add("@ContatPerson", ContatPerson);
                Params.Add("@ContactNo", ContactNo);
                Params.Add("@ContactMail", ContactMail);
                Params.Add("@Status", Status);
                Params.Add("@LoginUserName", LoginUserName);
                Params.Add("@EmpCode", EmpCode);
                Params.Add("@Privilege", Privilege);
                Params.Add("@Process", Process);
                Params.Add("@LoginBranch", LoginBranch);


                _Data = Helper.ReturnDataTable("SP_ITS_Modify_Ticket", Params);
            }
            catch (Exception ex)
            {
                throw;
            }
            return _Data;
        }



        public DataTable ITS_Assign_Ticket(string TicketNo, string GUID, string ID, string AssignedTo, string Status, string LoginUserName, string EmpCode, string Privilege, string Process, string LoginRegion)
        {
            DataTable _Data = new DataTable("_Data");
            try
            {
                System.Collections.Specialized.HybridDictionary Params = new System.Collections.Specialized.HybridDictionary(1);
                Params.Add("@TicketNo", TicketNo);
                Params.Add("@GUID", GUID);
                Params.Add("@ID", ID);
                Params.Add("@AssignedTo", AssignedTo);
                Params.Add("@Status", Status);
                Params.Add("@LoginUserName", LoginUserName);
                Params.Add("@EmpCode", EmpCode);
                Params.Add("@Privilege", Privilege);
                Params.Add("@Process", Process);
                Params.Add("@LoginRegion", LoginRegion);


                _Data = Helper.ReturnDataTable("SP_ITS_Assign_Ticket", Params);
            }
            catch (Exception ex)
            {
                throw;
            }
            return _Data;
        }


        public DataTable ITS_Response_Ticket(string TicketNo, string GUID, string Status,
            string Followup_Date, string Solution,
            string LoginUserName, string EmpCode, string Privilege, string Process, string LoginRegion)
        {
            DataTable _Data = new DataTable("_Data");
            try
            {
                System.Collections.Specialized.HybridDictionary Params = new System.Collections.Specialized.HybridDictionary(1);
                Params.Add("@TicketNo", TicketNo);
                Params.Add("@GUID", GUID);
                Params.Add("@Status", Status);
                Params.Add("@Followup_Date", Followup_Date);
                Params.Add("@Solution", Solution);
                Params.Add("@LoginUserName", LoginUserName);
                Params.Add("@EmpCode", EmpCode);
                Params.Add("@Privilege", Privilege);
                Params.Add("@Process", Process);
                Params.Add("@LoginRegion", LoginRegion);


                _Data = Helper.ReturnDataTable("SP_ITS_Response_Ticket", Params);
            }
            catch (Exception ex)
            {
                throw;
            }
            return _Data;
        }


        public DataTable ITS_Add_or_Modifiy_Category(string type, string ID, string Category, string GroupName, string Status, string LoginUserName, string EmpCode, string Privilege, string Process, string LoginRegion)
        {
            DataTable _Data = new DataTable("_Data");
            try
            {
                System.Collections.Specialized.HybridDictionary Params = new System.Collections.Specialized.HybridDictionary(1);

                Params.Add("@type", type);
                Params.Add("@ID", ID);
                Params.Add("@Category", Category);
                Params.Add("@GroupName", GroupName);
                Params.Add("@Status", Status);
                Params.Add("@LoginUserName", LoginUserName);
                Params.Add("@EmpCode", EmpCode);
                Params.Add("@Privilege", Privilege);
                Params.Add("@Process", Process);
                Params.Add("@LoginRegion", LoginRegion);

                _Data = Helper.ReturnDataTable("SP_ITS_Save_Issue_Category", Params);
            }
            catch (Exception ex)
            {
                throw;
            }
            return _Data;
        }


        public DataTable ITS_Save_User_Master(string type, string GUID, string UserName, string Password, string EmpCode, string EmpName, string Privilege, string Region, string Status, string Email, string Phone, string Process, string RiskOwner, string ReportAccess, string LoginUserName, string LoginEmpCode, string LoginPrivilege, string LoginProcess, string LoginRegion)
        {
            DataTable _Data = new DataTable("_Data");
            try
            {
                System.Collections.Specialized.HybridDictionary Params = new System.Collections.Specialized.HybridDictionary(1);

                Params.Add("@type", type);
                Params.Add("@GUID", GUID);
                Params.Add("@UserName", UserName);
                Params.Add("@Password", Password);
                Params.Add("@EmpCode", EmpCode);
                Params.Add("@EmpName", EmpName);
                Params.Add("@Privilege", Privilege);
                Params.Add("@Region", Region);
                Params.Add("@Status", Status);
                Params.Add("@Email", Email);
                Params.Add("@Phone", Phone);
                Params.Add("@Process", Process);
                Params.Add("@RiskOwner", RiskOwner);
                Params.Add("@ReportAccess", ReportAccess);
                Params.Add("@LoginUserName", LoginUserName);
                Params.Add("@LoginEmpCode", LoginEmpCode);
                Params.Add("@LoginPrivilege", LoginPrivilege);
                Params.Add("@LoginProcess", LoginProcess);
                Params.Add("@LoginRegion", LoginRegion);


                _Data = Helper.ReturnDataTable("SP_ITS_SAVE_USERMASTER", Params);
            }
            catch (Exception ex)
            {
                throw;
            }
            return _Data;
        }

        public DataTable ITS_Add_or_Modifiy_Sub_Category(string type, string ID, string Category, string SubCategory, string GroupName, string Status, string LoginUserName, string EmpCode, string Privilege, string Process, string LoginRegion)
        {
            DataTable _Data = new DataTable("_Data");
            try
            {
                System.Collections.Specialized.HybridDictionary Params = new System.Collections.Specialized.HybridDictionary(1);

                Params.Add("@type", type);
                Params.Add("@ID", ID);
                Params.Add("@Category", Category);
                Params.Add("@SubCategory", SubCategory);
                Params.Add("@GroupName", GroupName);
                Params.Add("@Status", Status);
                Params.Add("@LoginUserName", LoginUserName);
                Params.Add("@EmpCode", EmpCode);
                Params.Add("@Privilege", Privilege);
                Params.Add("@Process", Process);
                Params.Add("@LoginRegion", LoginRegion);

                _Data = Helper.ReturnDataTable("SP_ITS_Save_Issue_Sub_Category", Params);
            }
            catch (Exception ex)
            {
                throw;
            }
            return _Data;
        }


        public DataTable ITS_Add_Attachment(string TicketID, string HistoryID, string FileName, string Ext, string ImagePath, string UserName, string Privilege, string Region)
        {
            DataTable _Data = new DataTable("_Data");
            try
            {
                System.Collections.Specialized.HybridDictionary Params = new System.Collections.Specialized.HybridDictionary(1);
                Params.Add("@TicketID", TicketID);
                Params.Add("@HistoryID", HistoryID);
                Params.Add("@FileName", FileName);
                Params.Add("@Extension", Ext);
                Params.Add("@ImagePath", ImagePath);
                Params.Add("@UserName", UserName);
                Params.Add("@Privilege", Privilege);
                Params.Add("@Region", Region);


                _Data = Helper.ReturnDataTable("SP_ITS_Add_Attachment", Params);
            }
            catch (Exception ex)
            {
                throw;
            }
            return _Data;
        }



        public DataTable ITS_Mail_Status(string TicketID, string HistoryID, string Mail_Log_ID, string MailStatus, string MailResponse, string UserName, string Privilege, string Region)
        {
            DataTable _Data = new DataTable("_Data");
            try
            {
                System.Collections.Specialized.HybridDictionary Params = new System.Collections.Specialized.HybridDictionary(1);
                Params.Add("@TicketID", TicketID);
                Params.Add("@HistoryID", HistoryID);
                Params.Add("@Mail_Log_ID", Mail_Log_ID);
                Params.Add("@MailStatus", MailStatus);
                Params.Add("@MailResponse", MailResponse);
                Params.Add("@UserName", UserName);
                Params.Add("@Privilege", Privilege);
                Params.Add("@Region", Region);


                _Data = Helper.ReturnDataTable("SP_ITS_Update_Mail_Status", Params);
            }
            catch (Exception ex)
            {
                throw;
            }
            return _Data;
        }

        public DataTable Add_Marquee(string message, string bgcolor, string color, string scrollamount, string userID, string privilege, string region)
        {
            DataTable _Data = new DataTable("_Data");
            try
            {
                System.Collections.Specialized.HybridDictionary Params = new System.Collections.Specialized.HybridDictionary(1);
                Params.Add("@message", message);
                Params.Add("@bgcolor", bgcolor);
                Params.Add("@color", color);
                Params.Add("@scrollamount", scrollamount);
                Params.Add("@userID", userID);
                Params.Add("@privilege", privilege);
                Params.Add("@region", region);

                _Data = Helper.ReturnDataTable("SP_Add_Marquee", Params);
            }
            catch (Exception ex)
            {
                throw;
            }
            return _Data;
        }

        public DataTable Add_File(string FileName, string FileExtension, string FilePath, string userID, string privilege, string region)
        {
            DataTable _Data = new DataTable("_Data");
            try
            {
                System.Collections.Specialized.HybridDictionary Params = new System.Collections.Specialized.HybridDictionary(1);
                Params.Add("@FileName", FileName);
                Params.Add("@FileExtension", FileExtension);
                Params.Add("@FilePath", FilePath);
                Params.Add("@userID", userID);
                Params.Add("@privilege", privilege);
                Params.Add("@region", region);

                _Data = Helper.ReturnDataTable("SP_FileUpload", Params);
            }
            catch (Exception ex)
            {
                throw;
            }
            return _Data;
        }
    }
}