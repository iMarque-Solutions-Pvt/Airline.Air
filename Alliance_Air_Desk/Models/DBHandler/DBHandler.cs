using Alliance_Air_Desk.Models.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Alliance_Air_Desk.Models.DBHandler
{
    public class DBHandler
    {

        public List<AccountModel> GetAddedUser(string criteria, string condition1, string condition2, string condition3, string userID, string privilege, string region)
        {
            Classes.General OGL = new Classes.General();
            DataTable dt = new DataTable();
            dt = OGL.Get_UI_Elements(criteria, condition1, condition2, condition3, userID, privilege, region);
            if (dt.Rows.Count > 0)
            {
                List<AccountModel> _UserList = new List<AccountModel>();

                foreach (DataRow row in dt.Rows)
                {
                    _UserList.Add(new AccountModel()
                    {
                        sno = Convert.ToInt32(row["sno"].ToString()),
                        id = Convert.ToInt32(row["id"].ToString()),
                        guid = row["guid"].ToString(),
                        userId = row["userId"].ToString(),
                        empName = row["empName"].ToString(),
                        empCode = row["empCode"].ToString(),
                        privilege = row["privilege"].ToString(),
                        region = row["region"].ToString(),
                        status = row["status"].ToString(),                       
                        createdBy = row["createdBy"].ToString(),
                        createdTime = row["createdTime"].ToString(),
                        modifiedBy = row["modifiedBy"].ToString(),
                        modifiedTime = row["modifiedTime"].ToString()

                    });
                }

                return _UserList;
            }
            else
            {
                return new List<AccountModel>();
            }
        }

        public List<DisruptionModel> Get_Disruption_Flight_List(string criteria, string condition1, string condition2, string condition3, string userID, string privilege, string region)
        {
            Classes.General OGL = new Classes.General();
            DataTable dt = new DataTable();
            dt = OGL.Get_UI_Elements(criteria, condition1, condition2, condition3, userID, privilege, region);
            if (dt.Rows.Count > 0)
            {
                List<DisruptionModel> _UserList = new List<DisruptionModel>();

                foreach (DataRow row in dt.Rows)
                {
                    _UserList.Add(new DisruptionModel()
                    {
                        sno = Convert.ToInt32(row["sno"].ToString()),
                        rowid = Convert.ToInt32(row["id"].ToString()),
                        guid = row["guid"].ToString(),
                        flight_number = row["flight_number"].ToString(),
                        intimation_refno = row["intimation_refno"].ToString(),
                        origin = row["origin"].ToString(),
                        destination = row["destination"].ToString(),
                        actual_departure = row["actual_departure"].ToString(),
                        actual_arrival = row["actual_arrival"].ToString(),
                        revised_origin = row["revised_origin"].ToString(),
                        revised_destination = row["revised_destination"].ToString(),
                        revised_departure = row["revised_departure"].ToString(),
                        revised_arrival = row["revised_arrival"].ToString(),
                        disruption_type = row["disruption_type"].ToString(),
                        sms = row["sms"].ToString(),
                        email = row["email"].ToString(),
                        out_calling = row["out_calling"].ToString(),
                        mail_received_time = row["mail_received_time"].ToString(),
                        action_time = row["action_time"].ToString(),
                        status = row["status"].ToString(),
                        remarks = row["remarks"].ToString(),
                        createdBy = row["createdBy"].ToString(),
                        createdTime = row["createdTime"].ToString(),
                        modifiedBy = row["modifiedBy"].ToString(),
                        modifiedTime = row["modifiedTime"].ToString(),
                        var1 = row["var1"].ToString(),
                        var2 = row["var2"].ToString(),
                        var3 = row["var3"].ToString(),
                        var4 = row["var4"].ToString(),
                        var5 = row["var5"].ToString(),
                        var6 = row["var6"].ToString(),
                        var7 = row["var7"].ToString(),
                        var8 = row["var8"].ToString(),

                        domestic_template = string.Format(row["domestic_template"].ToString(), row["var1"].ToString(),
                        row["var2"].ToString(), row["var3"].ToString(), row["var4"].ToString(), row["var5"].ToString(), row["var6"].ToString(),
                        row["var7"].ToString(), row["var8"].ToString()),

                        international_template = string.Format(row["international_template"].ToString(), row["var1"].ToString(),
                        row["var2"].ToString(), row["var3"].ToString(), row["var4"].ToString(), row["var5"].ToString(), row["var6"].ToString(),
                        row["var7"].ToString(), row["var8"].ToString()),

                        QC_status = row["QC_status"].ToString(),
                        QC_Doneby = row["QC_Doneby"].ToString()


                    });
                }

                return _UserList;
            }
            else
            {
                return new List<DisruptionModel>();
            }
        }

        public List<InboundModel> Get_Inbound_List(string criteria, string condition1, string condition2, string condition3, string userID, string privilege, string region)
        {
            Classes.General OGL = new Classes.General();
            DataTable dt = new DataTable();
            dt = OGL.Get_UI_Elements(criteria, condition1, condition2, condition3, userID, privilege, region);
            if (dt.Rows.Count > 0)
            {
                List<InboundModel> _List = new List<InboundModel>();

                foreach (DataRow row in dt.Rows)
                {
                    _List.Add(new InboundModel()
                    {
                        sno = Convert.ToInt32(row["sno"].ToString()),
                        id = Convert.ToInt32(row["id"].ToString()),
                        loggedBy = row["loggedBy"].ToString(),
                        loggedTime = row["loggedTime"].ToString(),
                        phoneNo = row["phoneNo"].ToString(),
                        //guid = row["phoneNo"].ToString(),
                        pnr = row["pnr"].ToString(),
                        referenceId = row["referenceId"].ToString(),
                        name = row["Name"].ToString(),
                        qrc = row["qrc"].ToString(),
                        mainType = row["mainType"].ToString(),
                        subType = row["subType"].ToString(),
                        remarks = row["remarks"].ToString(),
                        status = row["Status"].ToString(),
                        call_transfer = row["call_transfer"].ToString(),
                        If_yes = row["If_yes"].ToString()

                    });
                }

                return _List;
            }
            else
            {
                return new List<InboundModel>();
            }
        }
        public List<InboundModel> Get_Inboundsupervisor_List(string criteria, string condition1, string condition2, string condition3, string userID, string privilege, string region)
        {
            Classes.General OGL = new Classes.General();
            DataTable dt = new DataTable();
            dt = OGL.Get_UI_Elements(criteria, condition1, condition2, condition3, userID, privilege, region);

            List<InboundModel> list = new List<InboundModel>();


            foreach (DataRow row in dt.Rows)
            {
                list.Add(new InboundModel()
                {

                    sno = Convert.ToInt32(row["sno"]),

                    id = Convert.ToInt32(row["id"]),


                    name = row["Name"].ToString(),
                    pnr = row["pnr"].ToString(),
                    phoneNo = row["phoneNo"].ToString(),
                    qrc = row["qrc"].ToString(),
                    mainType = row["mainType"].ToString(),

                    subType = row["subType"].ToString(),

                    resolution1 = row["resolution"].ToString(),


                    Requestraisedby = row["Requested by"].ToString(),

                    RequestDateandtime = row["Requested datetime"].ToString(),


                    //ValidatedStatus = row["Validated"].ToString(),

                    //ActionedBy = row["Actioned by"].ToString(),

                    //ActionBySupervisor = row["Action By Supervisor"].ToString(),

                    SupervisorStatus = row["Status"].ToString()

                    // ClosureDateandTime = row["Closure date and time"].ToString(),

                    //ETAForClosure = row["ETA for closure"].ToString()

                });
            }


            return list;

        }


        public List<InboundModel> Get_InboundSupervisor_Dashboard( string criteria, string condition1,  string condition2,  string condition3,  string userID, string privilege, string region)
        {
            Classes.General OGL = new Classes.General();
            DataTable dt = new DataTable();
            dt = OGL.Get_UI_Elements(criteria, condition1, condition2, condition3, userID,  privilege, region );
            List<InboundModel> _List =  new List<InboundModel>();
            foreach (DataRow row in dt.Rows)
            {
                _List.Add(new InboundModel()
                {
                    MonthName = row["MonthName"].ToString(),
                    TotalRequests = Convert.ToInt32(row["TotalRequests"].ToString()),
                    OpenCases = Convert.ToInt32(row["OpenCases"].ToString()),
                    ClosedCases = Convert.ToInt32(row["ClosedCases"].ToString())
                });
            }
            return _List;
        }

        public List<InboundModel> Get_Previous_Call_Details(string criteria, string condition1, string condition2, string condition3, string userID, string privilege, string region)
        {
            Classes.General OGL = new Classes.General();
            DataTable dt = new DataTable();
            dt = OGL.Get_UI_Elements(criteria, condition1, condition2, condition3, userID, privilege, region);
            if (dt.Rows.Count > 0)
            {
                List<InboundModel> _List = new List<InboundModel>();

                foreach (DataRow row in dt.Rows)
                {
                    _List.Add(new InboundModel()
                    {
                        phoneNo = row["phoneNo"].ToString(),
                        referenceId = row["referenceId"].ToString(),
                        pnr = row["pnr"].ToString(),
                        name = row["name"].ToString(),
                        callerCategory = row["callerCategory"].ToString(),
                        callingState = row["callingState"].ToString(),
                        language = row["language"].ToString(),
                        qrc = row["qrc"].ToString(),
                        mainType = row["mainType"].ToString(),
                        subType = row["subType"].ToString(),
                        resolution1 = row["resolution"].ToString(),
                        CaseEscalated = row["Highlight to Supervisor"].ToString(),
                        other_services = row["otherServices"].ToString(),
                        journeyType = row["journeyType"].ToString(),
                        origin = row["origin"].ToString(),
                        destination = row["destination"].ToString(),
                        flightNo = row["flightNo"].ToString(),
                        paymentType = row["paymentType"].ToString(),
                        paymentCard = row["paymentCard"].ToString(),
                        cardType = row["cardType"].ToString(),
                        payAmount = row["payAmount"].ToString(),
                        bank = row["bank"].ToString(),
                        payment_status = row["paymentStatus"].ToString(),
                        transactionId = row["transactionId"].ToString(),
                        remarks = row["remarks"].ToString(),
                        loggedBy = row["loggedBy"].ToString(),
                        loggedTime = row["loggedTime"].ToString()
                    });
                }

                return _List;
            }
            else
            {
                return new List<InboundModel>();
            }
        }

        public List<MailActionModel> Get_Previous_Mail_Details(string criteria, string condition1, string condition2, string condition3, string userID, string privilege, string region)
        {
            Classes.General OGL = new Classes.General();
            DataTable dt = new DataTable();
            dt = OGL.Get_UI_Elements(criteria, condition1, condition2, condition3, userID, privilege, region);
            if (dt.Rows.Count > 0)
            {
                List<MailActionModel> _List = new List<MailActionModel>();
                foreach (DataRow row in dt.Rows)
                {
                    _List.Add(new MailActionModel()
                    {
                        fromEmail = row["EmailID"].ToString(),
                        date_of_mail = row["Email_Date"].ToString(),
                        phoneNo = row["phoneNo"].ToString(),
                        referenceId = row["referenceId"].ToString(),
                        pnr = row["pnr"].ToString(),
                        mailSubject = row["mailSubject"].ToString(),
                        mailContent = row["mailContent"].ToString(),
                        QRC = row["Qrc"].ToString(),
                        type_of_mail = row["mailType"].ToString(),
                        subType = row["subType"].ToString(),
                        resolution = row["resolution"].ToString(),
                        resolution2 = row["resolution1"].ToString(),
                        content_template = row["content_template"].ToString(),
                        remarks = row["remarks"].ToString(),
                        loggedBy = row["loggedBy"].ToString(),
                        loggedTime = row["loggedTime"].ToString()
                    });
                }
                return _List;
            }
            else
            {
                return new List<MailActionModel>();
            }
        }

        
        public List<Content_Template> Get_Content_Template_List(string criteria, string condition1, string condition2, string condition3, string userID, string privilege, string region)
        {
            Classes.General OGL = new Classes.General();
            DataTable dt = new DataTable();
            dt = OGL.Get_UI_Elements(criteria, condition1, condition2, condition3, userID, privilege, region);
            if (dt.Rows.Count > 0)
            {
                List<Content_Template> _List = new List<Content_Template>();
                foreach (DataRow row in dt.Rows)
                {
                    _List.Add(new Content_Template()
                    {
                        sno = Convert.ToInt32(row["sno"].ToString()),
                        rowid = Convert.ToInt32(row["id"].ToString()),
                        guid = row["guid"].ToString(),
                        disruption_type = row["disruption_type"].ToString(),
                        domestic_template = row["domestic_template"].ToString(),
                        domestic_sample_sms = row["domestic_sample_sms"].ToString(),
                        international_template = row["international_template"].ToString(),
                        international_sample_sms = row["international_sample_sms"].ToString(),

                    });
                }

                return _List;
            }
            else
            {
                return new List<Content_Template>();
            }
        }

        //public List<WebApps> Delete_Content_Template(string Criteria, int ProcessID, string UserName, string Privilege, string UserType)
        //{
        //    Classes.General OGL = new Classes.General();
        //    DataTable dt = new DataTable();
        //    dt = OGL.GetUIElements(Criteria, ProcessID.ToString(), UserName, Privilege, UserType);
        //    if (dt.Rows.Count > 0)
        //    {
        //        return new List<WebApps>();
        //    }
        //    else
        //    {
        //        return new List<WebApps>();
        //    }
        //}

        public DataTable Login(LoginModel model)
        {
            try
            {
                Classes.General OGL = new Classes.General();
                DataTable dt = new DataTable();
                dt = OGL.Check_Login(model.userId, model.password, model.ipAddress, model.isMobileDevice.ToString(), model.sessionId);
                return dt;                            
            }
            catch (Exception ex)
            {
                return null;
            }
        }



        //public List<ContentModel> Template_Management(ContentModel model, string userID, string privilege, string region)
        //{
        //    Classes.General OGL = new Classes.General();
        //    DataTable dt = new DataTable();
        //    dt = OGL.Content_Template_Management
        //        (
        //        model.rowid.ToString(),
        //        model.guid ?? "",
        //        model.disruption_type ?? "",
        //        model.domestic_template ?? "",
        //        model.domestic_sample_sms ?? "",
        //        model.international_template ?? "",
        //        model.international_sample_sms ?? "",
        //        userID,
        //        privilege,
        //        region
        //        );
        //    if (dt.Rows.Count > 0)
        //    {
        //        return new List<ContentModel>();
        //    }
        //    else
        //    {
        //        return new List<ContentModel>();
        //    }
        //}


        public Object Template_Management(ContentModel model, string userID, string privilege, string region)
        {
            Classes.General OGL = new Classes.General();
            Response obj = new Response();
            DataTable dt = new DataTable();
            dt = OGL.Content_Template_Management
                (
                model.rowid.ToString(),
                model.guid ?? "",
                model.disruption_type ?? "",
                model.domestic_template ?? "",
                model.domestic_sample_sms ?? "",
                model.international_template ?? "",
                model.international_sample_sms ?? "",
                userID,
                privilege,
                region
                );
            if (dt.Rows.Count != 0)
            {
                if (dt.Rows[0]["MSG"].ToString().ToUpper().Equals("ADDED"))
                {
                    obj.status = "success";
                    obj.msg = "Template Saved Successfully";
                }
                else if (dt.Rows[0]["MSG"].ToString().ToUpper().Equals("UPDATED"))
                {
                    obj.status = "success";
                    obj.msg = "Template Modified Successfully";
                }
                else
                {
                    obj.status = "error";
                    obj.msg = dt.Rows[0]["MSG"].ToString();
                }
            }
            else
            {
                obj.status = "error";
                obj.msg = "somthing went wrong";
            }
            return obj;
        }



        public List<SelectListItem> Get_UI_Element_List(string criteria, string condition1, string condition2, string condition3, string userID, string privilege, string region)
        {
            Classes.General OGL = new Classes.General();
            DataTable dt = new DataTable();
            dt = OGL.Get_UI_Elements(criteria, condition1, condition2, condition3, userID, privilege, region);
            if (dt.Rows.Count > 0)
            {
                List<SelectListItem> items = new List<SelectListItem>();

                foreach (DataRow row in dt.Rows)
                {
                    items.Add(new SelectListItem()
                    {
                        Text = row["NAME"].ToString(),
                        Value = row["CODE"].ToString()
                    });
                }

                return items;

            }
            else
            {
                return new List<SelectListItem>();
            }
        }


        public List<Checkbox_Control> getCheckbox_Control_List(string Criteria, string Condition1, string Condition2, string Condition3, string userID, string privilege, string zone)
        {
            Classes.General OGL = new Classes.General();
            DataTable dt = new DataTable();
            dt = OGL.Get_UI_Elements(Criteria, Condition1, Condition2, Condition3, userID, privilege, zone);
            if (dt.Rows.Count > 0)
            {
                List<Checkbox_Control> _List = new List<Checkbox_Control>();

                foreach (DataRow row in dt.Rows)
                {
                    _List.Add(new Checkbox_Control()
                    {
                        code = Convert.ToInt32(row["code"].ToString()),
                        name = row["name"].ToString(),
                        isChecked = row["isChecked"].ToString().Equals("1") ? true : false
                    });
                }

                return _List;

            }
            else
            {
                return new List<Checkbox_Control>();
            }
        }



        public DataTable Get_UI_Element(string criteria, string condition1, string condition2, string condition3, string userID, string privilege, string region)
        {
            Classes.General OGL = new Classes.General();
            DataTable dt = new DataTable();
            dt = OGL.Get_UI_Elements(criteria, condition1, condition2, condition3, userID, privilege, region);
            return dt;

        }

        public DataTable Downloads_Reports(string fromDate, string toDate, string reportName, string userID, string privilege, string region)
        {
            try
            {
                Classes.General OGL = new Classes.General();
                DataTable dt = new DataTable();
                dt = OGL.get_Reports(fromDate, toDate, reportName, userID, privilege, region);
                return dt;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<call_History> Get_Inbound_Call_History(string criteria, string condition1, string condition2, string condition3, string userID, string privilege, string region)
        {
            Classes.General OGL = new Classes.General();
            DataTable dt = new DataTable();
            dt = OGL.Get_UI_Elements(criteria, condition1, condition2, condition3, userID, privilege, region);
            if (dt.Rows.Count > 0)
            {
                List<call_History> items = new List<call_History>();

                foreach (DataRow row in dt.Rows)
                {
                    items.Add(new call_History()
                    {
                        sno = Convert.ToInt32(row["sno"].ToString()),
                        id = Convert.ToInt32(row["id"].ToString()),
                        date = row["date"].ToString(),
                        loggedby = row["loggedby"].ToString(),
                        referenceId = row["referenceId"].ToString(),
                        pnr = row["pnr"].ToString(),
                        maintype = row["maintype"].ToString(),
                        subtype = row["subtype"].ToString(),
                        resolution = row["resolution"].ToString(),
                        HighlighttoSupervisor = row["Highlight to Supervisor"].ToString(),
                        remarks = row["remarks"].ToString(),
                    });
                }

                return items;

            }
            else
            {
                return new List<call_History>();
            }
        }

        public List<Escalation_call_History> Get_Inbound_Escalation_History(string criteria, string condition1, string condition2, string condition3, string userID, string privilege, string region)
        {
            Classes.General OGL = new Classes.General();
            DataTable dt = new DataTable();
            dt = OGL.Get_UI_Elements(criteria, condition1, condition2, condition3, userID, privilege, region);
            if (dt.Rows.Count > 0)
            {
                List<Escalation_call_History> items = new List<Escalation_call_History>();

                foreach (DataRow row in dt.Rows)
                {
                    items.Add(new Escalation_call_History()
                    {
                        sno = Convert.ToInt32(row["sno"].ToString()),
                        id = Convert.ToInt32(row["id"].ToString()),
                       // date = row["date"].ToString(),
                        loggedBy = row["loggedBy"].ToString(),
                        loggedTime = row["loggedTime"].ToString(),
                        phoneNo = row["phoneNo"].ToString(),
                        referenceId = row["referenceId"].ToString(),
                        pnr = row["pnr"].ToString(),
                        maintype = row["maintype"].ToString(),
                        subtype = row["subtype"].ToString(),
                        Escalation_remarks = row["remarks"].ToString(),
                        status = row["status"].ToString(),
                        call_transfer = row["call_transfer"].ToString(),
                        If_yes = row["If_yes"].ToString(),
                    });
                }

                return items;

            }
            else
            {
                return new List<Escalation_call_History>();
            }
        }

        public List<Mail_History> Get_Mail_History(string criteria, string condition1, string condition2, string condition3, string userID, string privilege, string region)
        {
            Classes.General OGL = new Classes.General();
            DataTable dt = new DataTable();
            dt = OGL.Get_UI_Elements(criteria, condition1, condition2, condition3, userID, privilege, region);
            if (dt.Rows.Count > 0)
            {
                List<Mail_History> items = new List<Mail_History>();

                foreach (DataRow row in dt.Rows)
                {
                    items.Add(new Mail_History()
                    {
                        sno = Convert.ToInt32(row["sno"].ToString()),
                        id = Convert.ToInt32(row["id"].ToString()),
                        date = row["date"].ToString(),
                        loggedby = row["loggedBy"].ToString(),
                        referenceId = row["referenceId"].ToString(),
                        pnr = row["pnr"].ToString(),
                        Qrc = row["Qrc"].ToString(),
                        maintype = row["maintype"].ToString(),
                        subtype = row["subtype"].ToString(),
                        resolution = row["resolution"].ToString(),
                        //resolution = row["resolution"].ToString(),
                        remarks = row["remarks"].ToString(),
                    });
                }

                return items;

            }
            else
            {
                return new List<Mail_History>();
            }
        }


        //public DataTable Add_Inbound_Calls(int registerId, string phoneNo, string pnr, string referenceId, string name, string callerCategory, string callingCountry, string language, string qrc, string mainType, string subType, string resolution, string journeyType, string origin, string destination, string flightNo, string otherServices, string paymentType, string paymentCard, string cardType, string payAmount, string bank, string status, string transactionId, string payRefId, string remarks,
        //    string campaignId, string crtObjectId, string userCrtObjectId, string customerId, string dialerSessionId, string maskingEnabled, string lead_name, string leadId, string callType, string ameyo_userId,
        //    string userID, string privilege, string region)
        //{
        //    try
        //    {
        //        Classes.General OGL = new Classes.General();
        //        DataTable dt = new DataTable();
        //        dt = OGL.Add_Inbound_Calls(registerId, phoneNo, pnr, referenceId, name, callerCategory, callingCountry, language, qrc, mainType, subType, resolution, journeyType, origin, destination, flightNo, otherServices, paymentType, paymentCard, cardType, payAmount, bank, status, transactionId, remarks,
        //        campaignId, crtObjectId, userCrtObjectId, customerId, dialerSessionId, maskingEnabled, lead_name, leadId, callType, ameyo_userId, userID, privilege, region);
        //        return dt;

        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}
        
        public Object Add_Inbound_Call_Details(int id,int registerId, string phoneNo, string pnr, string referenceId, string name, string callerCategory, 
            string callingState, string language, string qrc, string mainType, string subType, string resolution1, string CaseEscalated, string journeyType,
            string origin, string destination, string flightNo, string penaltyAmt,string otherServices, string paymentType, string paymentCard, string cardType, string payAmount, string bank, string payment_status, string transactionId,  string remarks,string campaignId, string crtObjectId, string userCrtObjectId, string customerId, string dialerSessionId, string maskingEnabled, string lead_name, string leadId, string callType, string ameyo_userId,
       string escalation_remarks,string Inbound_status,string call_transfer,string If_yes, string userID, string privilege, string region)
        { 
            Classes.General OGL = new Classes.General();
            Response obj = new Response();
            DataTable dt = new DataTable();
            dt = OGL.Add_Inbound_Calls(id,registerId, phoneNo, pnr, referenceId, name, callerCategory, callingState, language, qrc, mainType, subType, resolution1, CaseEscalated, journeyType, origin, destination, flightNo, penaltyAmt,otherServices, paymentType, paymentCard, cardType, payAmount, bank, payment_status, transactionId, remarks,campaignId, crtObjectId, userCrtObjectId, customerId, dialerSessionId, maskingEnabled, lead_name, leadId, callType, ameyo_userId,escalation_remarks,Inbound_status, call_transfer, If_yes, userID, privilege, region);
            if (dt.Rows.Count != 0)
            {
                if (dt.Rows[0]["MSG"].ToString().ToUpper().Equals("ADDED"))
                {
                    obj.status = "success";
                    obj.msg = "Details Saved Successfully, Reference No: "+ dt.Rows[0]["ReferenceId"].ToString();
                    obj.resultCode = dt.Rows[0]["ReferenceId"].ToString();
                }
                else if (dt.Rows[0]["MSG"].ToString().ToUpper().Equals("UPDATED"))
                {
                    obj.status = "success";
                    obj.msg = "Details updated Successfully, Reference No: " + dt.Rows[0]["ReferenceId"].ToString();
                    obj.resultCode = dt.Rows[0]["ReferenceId"].ToString();
                }
                else
                {
                    obj.status = "error";
                    obj.msg = dt.Rows[0]["MSG"].ToString();
                }
            }
            else
            {
                obj.status = "error";
                obj.msg = "somthing went wrong";
            }
            return obj;
        }
        public DataTable Save_Inbound_Supervisor_Action(
  int InboundId,
  string ValidatedStatus,
  string ActionedBy,
  string ActionBySupervisor,
  string SupervisorStatus,
  string ClosureDateandTime
  //          ,
  //string ETAForClosure
            )
        {
            Classes.General OGL = new Classes.General();

            DataTable dt = new DataTable();

            try
            {
                dt = OGL.Save_Inbound_Supervisor_Action(
                    InboundId,
                    ValidatedStatus,
                    ActionedBy,
                    ActionBySupervisor,
                    SupervisorStatus,
                    ClosureDateandTime
                    //,
                    //ETAForClosure
                );
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return dt;
        }


        public Object Add_MailAction_Details(string rowid, string guid, string fromEmail, string Mail_date, string pnr, string phoneNo, string referenceId, string mailSubject, string mailContent, string QRC, string type_of_mail, string subType, string resolution, string resolution2, string content_template, string remarks,
        string userID, string privilege, string region)
        {
            Classes.General OGL = new Classes.General();
            Response obj = new Response();
            DataTable dt = new DataTable();
            dt = OGL.Add_MailAction(rowid, guid, fromEmail, Mail_date, pnr, phoneNo, referenceId, mailSubject, mailContent,QRC, type_of_mail, subType, resolution, resolution2, content_template, remarks, userID, privilege, region);
            if (dt.Rows.Count != 0)
            {
                if (dt.Rows[0]["MSG"].ToString().ToUpper().Equals("ADDED"))
                {
                    obj.status = "success";
                    obj.msg = "Details Saved Successfully, Reference No: " + dt.Rows[0]["ReferenceId"].ToString();
                    obj.resultCode = dt.Rows[0]["ReferenceId"].ToString();
                }
                else
                {
                    obj.status = "error";
                    obj.msg = dt.Rows[0]["MSG"].ToString();
                }
            }
            else
            {
                obj.status = "error";
                obj.msg = "somthing went wrong";
            }
            return obj;
        }


        public Object Add_Disruption_Managment(string rowid, string guid, string flight_number, string intimation_refno, string origin, string destination, string actual_departure, string actual_arrival, string revised_origin, string revised_destination, string revised_departure, string revised_arrival, string disruption_type, string sms, string email, string out_calling, string mail_received_time, string status, string QC_status, string remarks, string userID, string privilege, string region)
        {
            Classes.General OGL = new Classes.General();
            Response obj = new Response();
            DataTable dt = new DataTable();
            dt = OGL.Disruption_Managment(rowid, guid, flight_number, intimation_refno, origin, destination, actual_departure, actual_arrival, revised_origin, revised_destination, revised_departure, revised_arrival, disruption_type, sms, email, out_calling, mail_received_time, status, QC_status, remarks, userID, privilege, region);
            if (dt.Rows.Count != 0)
            {
                if (dt.Rows[0]["MSG"].ToString().ToUpper().Equals("ADDED"))
                {
                    obj.status = "success";
                    obj.msg = "Details Saved Successfully";
                }
                else if (dt.Rows[0]["MSG"].ToString().ToUpper().Equals("UPDATED"))
                {
                    obj.status = "success";
                    obj.msg = "Details Modified Successfully";
                }
                else
                {
                    obj.status = "error";
                    obj.msg = dt.Rows[0]["MSG"].ToString();
                }
            }
            else
            {
                obj.status = "error";
                obj.msg = "somthing went wrong";
            }
            return obj;
        }

        public Object Add_QCDisruption_Managment(string rowid, string guid, string resk, string mailDate, string subject, string travelDate, string flightNo, string scenario, string crm_Tagging, string sms_Sent, string mail_Sent, string remarks, string userID, string privilege, string region)
        {
            Classes.General OGL = new Classes.General();
            Response obj = new Response();
            DataTable dt = new DataTable();
            dt = OGL.QCDisruption_Managment(rowid, guid, resk, mailDate, subject, travelDate, flightNo, scenario, crm_Tagging, sms_Sent, mail_Sent, remarks, userID, privilege, region);
            if (dt.Rows.Count != 0)
            {
                if (dt.Rows[0]["MSG"].ToString().ToUpper().Equals("ADDED"))
                {
                    obj.status = "success";
                    obj.msg = "Details Saved Successfully";
                } 
                else
                {
                    obj.status = "error";
                    obj.msg = dt.Rows[0]["MSG"].ToString();
                }
            }
            else
            {
                obj.status = "error";
                obj.msg = "somthing went wrong";
            }
            return obj;
        }
        public DataTable Register_Call_Details(string searchType, string phone, string pnrNo, string campaignId, string crtObjectId, string userCrtObjectId, string customerId, string sessionId, string maskingEnabled, string lead_name, string leadId, string callType, string ameyo_userId, string crm_userID)
        {
            try
            {
                Classes.General OGL = new Classes.General();
                DataTable dt = new DataTable();
                dt = OGL.Register_Call_Details(searchType, phone, pnrNo, campaignId, crtObjectId, userCrtObjectId, customerId, sessionId, maskingEnabled, lead_name, leadId, callType, ameyo_userId, crm_userID);
                return dt;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable Manage_User_Master(string guid, string userId, string password, string empCode, string empName, string privilege, string region, string status, string LoggedInuserID, string LoggedInprivilege)
        {
            try
            {
                Classes.General OGL = new Classes.General();
                DataTable dt = new DataTable();
                dt = OGL.User_Management(guid, userId, password, empCode, empName, privilege, region, status, LoggedInuserID, LoggedInprivilege);
                return dt;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable Add_Marquee(string message, string bgcolor, string color, string scrollamount, string userID, string privilege, string region)
        {
            Classes.General OGL = new Classes.General();
            DataTable dt = new DataTable();
            dt = OGL.Add_Marquee(message, bgcolor, color, scrollamount, userID, privilege, region);
            return dt;

        }
        public DataTable Add_File(string FileName, string FileExtension, string FilePath, string userID, string privilege, string region)
        {
            Classes.General OGL = new Classes.General();
            DataTable dt = new DataTable();
            dt = OGL.Add_File(FileName, FileExtension, FilePath, userID, privilege, region);
            return dt;

        }
        public List<DataPoint> get_Analytics(string fromDate, string toDate, string reportName, string userID, string privilege, string region)
        {
            Classes.General OGL = new Classes.General();
            DataTable dt = new DataTable();
            dt = OGL.get_Reports(fromDate, toDate, reportName, userID, privilege, region);
            if (dt.Rows.Count > 0)
            {
                List<DataPoint> items = new List<DataPoint>();

                foreach (DataRow row in dt.Rows)
                {
                    items.Add(new DataPoint()
                    {
                        Label = row["Text"].ToString(),
                        Y = Convert.ToDouble(row["Total"].ToString())
                    });
                }

                return items;
            }
            else
            {
                return new List<DataPoint>();
            }
        }

        public List<Hourly_Dashboard> Hourly_Dashboard(string fromDate, string toDate, string reportName, string userID, string privilege, string region)
        {
            Classes.General OGL = new Classes.General();
            DataTable dt = new DataTable();
            dt = OGL.get_Reports(fromDate, toDate, reportName, userID, privilege, region);
            if (dt.Rows.Count > 0)
            {
                List<Hourly_Dashboard> _List = new List<Hourly_Dashboard>();

                foreach (DataRow row in dt.Rows)
                {
                    _List.Add(new Hourly_Dashboard()
                    {

                        name = row["name"].ToString(),
                        empCode = row["empCode"].ToString(),
                        privilege = row["privilege"].ToString(),
                        region = row["region"].ToString(),
                        date = row["date"].ToString(),
                        total = Convert.ToInt32(row["total"].ToString()),
                        zero = Convert.ToInt32(row["12AM_1AM"].ToString()),
                        one = Convert.ToInt32(row["1AM_2AM"].ToString()),
                        two = Convert.ToInt32(row["2AM_3AM"].ToString()),
                        three = Convert.ToInt32(row["3AM_4AM"].ToString()),
                        four = Convert.ToInt32(row["4AM_5AM"].ToString()),
                        five = Convert.ToInt32(row["5AM_6AM"].ToString()),
                        six = Convert.ToInt32(row["6AM_7AM"].ToString()),
                        seven = Convert.ToInt32(row["7AM_8AM"].ToString()),
                        eight = Convert.ToInt32(row["8AM_9AM"].ToString()),
                        nine = Convert.ToInt32(row["9AM_10AM"].ToString()),
                        ten = Convert.ToInt32(row["10AM_11AM"].ToString()),
                        eleven = Convert.ToInt32(row["11AM_12PM"].ToString()),
                        twelve = Convert.ToInt32(row["12PM_1PM"].ToString()),
                        thirteen = Convert.ToInt32(row["1PM_2PM"].ToString()),
                        fourteen = Convert.ToInt32(row["2PM_3PM"].ToString()),
                        fifteen = Convert.ToInt32(row["3PM_4PM"].ToString()),
                        sixteen = Convert.ToInt32(row["4PM_5PM"].ToString()),
                        seventeen = Convert.ToInt32(row["5PM_6PM"].ToString()),
                        eighteen = Convert.ToInt32(row["6PM_7PM"].ToString()),
                        nineteen = Convert.ToInt32(row["7PM_8PM"].ToString()),
                        twenty = Convert.ToInt32(row["8PM_9PM"].ToString()),
                        twentyOne = Convert.ToInt32(row["9PM_10PM"].ToString()),
                        twentyTwo = Convert.ToInt32(row["10PM_11PM"].ToString()),
                        twentyThree = Convert.ToInt32(row["11PM_12PM"].ToString())
                    });
                }

                return _List;
            }
            else
            {
                return new List<Hourly_Dashboard>();
            }
        }

    }
}