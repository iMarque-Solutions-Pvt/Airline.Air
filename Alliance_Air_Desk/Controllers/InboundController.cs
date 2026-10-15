using Alliance_Air_Desk.Classes;
using Alliance_Air_Desk.Models.DBHandler;
using Alliance_Air_Desk.Models.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Alliance_Air_Desk.Controllers
{
    [HandleError]
    public class InboundController : Controller
    {
        Classes.UserDetails _userdetails = new Classes.UserDetails();

        public ActionResult Index(string callingNo, string pnrNo, string id)
        {
            string searchType = "";
            string phoneNo = "";

            Classes.SessionHandler.ValidateSession(ref _userdetails);

            try
            {
                DataTable dt = new DataTable();
                InboundModel _mod = new InboundModel();
                DBHandler _dbcontext = new DBHandler();
                List<Checkbox_Control> other_services_list = new List<Checkbox_Control>();

                string campaignId = Request.QueryString["campaignId"] ?? "";
                string sessionId = Request.QueryString["sessionId"] ?? "";
                string QueryPhone = Request.QueryString["phone"] ?? "";
                string crtObjectId = Request.QueryString["crtObjectId"] ?? "";
                string userCrtObjectId = Request.QueryString["userCrtObjectId"] ?? "";
                string dialerCustomerId = Request.QueryString["customerId"] ?? "";
                string leadId = Request.QueryString["leadId"] ?? "";
                string leadName = Request.QueryString["lead_name"] ?? "";
                string dialerCallType = Request.QueryString["callType"] ?? "";
                string maskingEnabled = Request.QueryString["maskingEnabled"] ?? "";
                string ameyoUserId = Request.QueryString["userId"] ?? "";
                string crmPushGeneratedTime = Request.QueryString["crm_push_generated_time"] ?? "";
                string maskedPhone = Request.QueryString["maskedPhone"] ?? "";
                string instanceId = Request.QueryString["instanceId"] ?? "";
                string customerInfo = Request.QueryString["customerInfo"] ?? "";
                string CustomerNumber = "";


                if (!string.IsNullOrEmpty(Request.QueryString["actualphone"]))
                {
                    CustomerNumber = Request.QueryString["actualphone"];
                }
                else
                {
                    CustomerNumber = Request.QueryString["phone"];
                }
                CustomerNumber = CustomerNumber?.Trim() ?? "";
                string DialerConfigCallConnectionUrl =  ConfigurationManager.AppSettings["AmeyoUnmaskingUrl"];

                if (!string.IsNullOrEmpty(CustomerNumber))
                {
                    if (CustomerNumber.Length >= 15 &&
                        !string.IsNullOrWhiteSpace(sessionId))
                    {
                        try
                        {
                            System.Diagnostics.Debug.WriteLine("========== DECRYPT START ==========");
                            System.Diagnostics.Debug.WriteLine("CustomerNumber: " + CustomerNumber);
                            System.Diagnostics.Debug.WriteLine("SessionId: " + sessionId);
                            System.Diagnostics.Debug.WriteLine("Decrypt URL: " + DialerConfigCallConnectionUrl);
                            CustomerNumber = Cryptography.GetDecryptedValue( CustomerNumber, sessionId,  DialerConfigCallConnectionUrl);
                            CustomerNumber = CustomerNumber?.Trim() ?? "";
                            System.Diagnostics.Debug.WriteLine("DECRYPTED NUMBER: " + CustomerNumber);
                            System.Diagnostics.Debug.WriteLine("========== DECRYPT SUCCESS ==========");
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine("========== DECRYPT FAILED ==========");
                            System.Diagnostics.Debug.WriteLine(ex.ToString());

                            throw;
                        }
                    }
                }

                if (!string.IsNullOrEmpty(CustomerNumber) && CustomerNumber.Length == 11 && CustomerNumber.StartsWith("0"))
                {
                    CustomerNumber = CustomerNumber.Substring(1);
                }
                phoneNo = CustomerNumber;

                if (!string.IsNullOrEmpty(callingNo))
                {
                    searchType = "Inbound No";
                }
                else if (!string.IsNullOrEmpty(pnrNo))
                {
                    searchType = "PNR";
                }
                else
                {
                    searchType = "";
                }

                _mod.phoneNo = phoneNo;
                _mod.campaignId = campaignId;
                _mod.crtObjectId = crtObjectId;
                _mod.userCrtObjectId = userCrtObjectId;
                _mod.customerId = dialerCustomerId;
                _mod.dialerSessionId = sessionId;
                _mod.maskingEnabled = maskingEnabled;
                _mod.lead_name = leadName;
                _mod.leadId = leadId;
                _mod.callType = dialerCallType;
                _mod.ameyo_userId = ameyoUserId;
                _mod.callerCategory_List = _dbcontext.Get_UI_Element_List( "Caller_Category", "", "", "", _userdetails.userID,  _userdetails.privilege.ToString(),  _userdetails.region.ToString()).ToList();
                _mod.callingState_List = _dbcontext.Get_UI_Element_List( "State", "", "", "", _userdetails.userID,  _userdetails.privilege.ToString(), _userdetails.region.ToString()).ToList();
                _mod.language_List = _dbcontext.Get_UI_Element_List("Language", "", "", "", _userdetails.userID, _userdetails.privilege.ToString(),  _userdetails.region.ToString()).ToList();
                _mod.qrc_List =  _dbcontext.Get_UI_Element_List("QRC", "", "", "",  _userdetails.userID,   _userdetails.privilege.ToString(),  _userdetails.region.ToString()).ToList();
                _mod.mainType_List = _dbcontext.Get_UI_Element_List( "MainType", "", "", "", _userdetails.userID, _userdetails.privilege.ToString(), _userdetails.region.ToString()).ToList();
                _mod.subType_List = _dbcontext.Get_UI_Element_List( "SubType", "", "", "", _userdetails.userID,  _userdetails.privilege.ToString(), _userdetails.region.ToString()).ToList();
                _mod.resolution1_List =_dbcontext.Get_UI_Element_List( "Resolution", "", "", "",  _userdetails.userID,_userdetails.privilege.ToString(), _userdetails.region.ToString()).ToList();
                _mod.resolution2_List = _dbcontext.Get_UI_Element_List( "Resolution2", "", "", "", _userdetails.userID, _userdetails.privilege.ToString(),  _userdetails.region.ToString()).ToList();
                _mod.journeyType_List =_dbcontext.Get_UI_Element_List( "Journey_Type", "", "", "", _userdetails.userID, _userdetails.privilege.ToString(), _userdetails.region.ToString()).ToList();
                _mod.origin_List = _dbcontext.Get_UI_Element_List( "Origin", "", "", "", _userdetails.userID,  _userdetails.privilege.ToString(), _userdetails.region.ToString()).ToList();
                _mod.destination_List = _dbcontext.Get_UI_Element_List( "Destination", "", "", "", _userdetails.userID, _userdetails.privilege.ToString(), _userdetails.region.ToString()).ToList();
                _mod.paymentType_List = _dbcontext.Get_UI_Element_List("Payment_Type", "", "", "", _userdetails.userID, _userdetails.privilege.ToString(), _userdetails.region.ToString()).ToList();
                _mod.paymentCard_List = _dbcontext.Get_UI_Element_List("Payment_Card", "", "", "",  _userdetails.userID,   _userdetails.privilege.ToString(),  _userdetails.region.ToString()).ToList();
                _mod.cardType_List =  _dbcontext.Get_UI_Element_List( "CardType", "", "", "", _userdetails.userID, _userdetails.privilege.ToString(),  _userdetails.region.ToString()).ToList();
                _mod.payment_status_List =_dbcontext.Get_UI_Element_List("Payment_Status", "", "", "", _userdetails.userID, _userdetails.privilege.ToString(), _userdetails.region.ToString()).ToList();
                _mod.other_services_list = _dbcontext.getCheckbox_Control_List( "Inbound_Other_Services", "", "", "",_userdetails.userID,  _userdetails.privilege.ToString(), _userdetails.region.ToString()).ToList();
                _mod.Inb_status_List = _dbcontext.Get_UI_Element_List(  "Inbound_Status", "", "", "",  _userdetails.userID,  _userdetails.privilege.ToString(),  _userdetails.region.ToString()).ToList();
                _mod.call_transfer_List =  _dbcontext.Get_UI_Element_List( "Escalation_status", "", "", "", _userdetails.userID, _userdetails.privilege.ToString(),  _userdetails.region.ToString()).ToList();
                _mod.Case_Escalated = _dbcontext.Get_UI_Element_List("Escalation_status", "", "", "",_userdetails.userID, _userdetails.privilege.ToString(), _userdetails.region.ToString()).ToList();

                if (!string.IsNullOrEmpty(phoneNo))
                {
                    dt = _dbcontext.Register_Call_Details(  searchType,  phoneNo, pnrNo ?? "", campaignId, crtObjectId, userCrtObjectId,  dialerCustomerId, sessionId, maskingEnabled,   leadName, leadId, dialerCallType,  ameyoUserId,  _userdetails.userID);
                    if (dt.Rows.Count > 0)
                    {
                        _mod.registerId = Convert.ToInt32(dt.Rows[0]["RegisterID"].ToString());
                    }
                }

             
                // EDIT
                if (!string.IsNullOrEmpty(id))
                {
                    dt = _dbcontext.Get_UI_Element("Get_Inbound_Details_Edit", id, "",  "",  _userdetails.userID,  _userdetails.privilege.ToString(), _userdetails.region.ToString());
                    if (dt.Rows.Count > 0)
                    {
                        _mod.id = Convert.ToInt32(dt.Rows[0]["id"].ToString());
                        string editPhoneNo = dt.Rows[0]["phoneNo"].ToString();
                        if (!string.IsNullOrEmpty(editPhoneNo))
                        {
                            editPhoneNo = editPhoneNo.Trim();
                            if (editPhoneNo.Length >= 15)
                            {
                                editPhoneNo = Cryptography.GetDecryptedValue( editPhoneNo,sessionId, DialerConfigCallConnectionUrl);
                                editPhoneNo = editPhoneNo?.Trim() ?? "";
                            }

                            if (editPhoneNo.Length == 11
                                && editPhoneNo.StartsWith("0"))
                            {
                                editPhoneNo = editPhoneNo.Substring(1);
                            }
                        }

                        _mod.phoneNo = editPhoneNo;
                        _mod.pnr = dt.Rows[0]["pnr"].ToString();
                        _mod.name = dt.Rows[0]["Name"].ToString();
                        _mod.referenceId = dt.Rows[0]["referenceId"].ToString();
                        _mod.callerCategory = dt.Rows[0]["callerCategory"].ToString();
                        _mod.callingState = dt.Rows[0]["callingState"].ToString();
                        _mod.language = dt.Rows[0]["language"].ToString();
                        _mod.qrc = dt.Rows[0]["qrc"].ToString();
                        _mod.mainType_List =_dbcontext.Get_UI_Element_List("MainType",  _mod.qrc,"",  "",_userdetails.userID,  _userdetails.privilege.ToString(),   _userdetails.region.ToString()).ToList();
                        _mod.mainType = dt.Rows[0]["mainType"].ToString();
                        _mod.subType_List =_dbcontext.Get_UI_Element_List( "SubType", _mod.mainType,"", "", _userdetails.userID,  _userdetails.privilege.ToString(),  _userdetails.region.ToString()).ToList();
                        _mod.subType = dt.Rows[0]["subtype"].ToString();
                        _mod.resolution1 = dt.Rows[0]["resolution"].ToString();
                        _mod.resolution2 = dt.Rows[0]["resolution2"].ToString();
                        _mod.journeyType = dt.Rows[0]["journeyType"].ToString();
                        _mod.origin = dt.Rows[0]["origin"].ToString();
                        _mod.destination = dt.Rows[0]["Destination"].ToString();
                        _mod.flightNo = dt.Rows[0]["flightNo"].ToString();
                        _mod.remarks = dt.Rows[0]["remarks"].ToString();
                        _mod.Escalation_remarks = dt.Rows[0]["Escalation_remarks"].ToString();
                        _mod.Inb_status = dt.Rows[0]["Inbound_Status"].ToString();
                        _mod.call_transfer =  dt.Rows[0]["call_transfer"].ToString();
                        _mod.If_yes = dt.Rows[0]["If_yes"].ToString();
                        dt = _dbcontext.Get_UI_Element( "Inbound_Checkbox_Edit", id, "", "", _userdetails.userID, _userdetails.privilege.ToString(),_userdetails.region.ToString());

                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow row in dt.Rows)
                            {
                                other_services_list.Add(
                                    new Checkbox_Control()
                                    {
                                        code = Convert.ToInt32(row["Code"].ToString()),
                                        name = row["Name"].ToString(),
                                        isChecked = row["Checked"].ToString().Equals("1")
                                    });
                            }
                        }
                        else
                        {
                            other_services_list.Add(new Checkbox_Control());
                        }
                    }
                    _mod.other_services_list = other_services_list;
                }

                ViewBag.MobileNo = _mod.phoneNo;
                ViewBag.QueryPhone = QueryPhone;
                ViewBag.CampaignId = campaignId;
                ViewBag.CrtObjectId = crtObjectId;
                ViewBag.UserCrtObjectId = userCrtObjectId;
                ViewBag.DialerCustomerId = dialerCustomerId;
                ViewBag.LeadId = leadId;
                ViewBag.LeadName = leadName;
                ViewBag.DialerCallType = dialerCallType;
                ViewBag.MaskingEnabled = maskingEnabled;
                ViewBag.CrmPushGeneratedTime = crmPushGeneratedTime;
                ViewBag.MaskedPhone = maskedPhone;
                ViewBag.InstanceId = instanceId;
                ViewBag.sessionId = sessionId;
                ViewBag.Config = campaignId + "|" + sessionId;
                ViewBag.UserName = _userdetails.userName;
                ViewBag.Privilege = Convert.ToInt32(_userdetails.privilege);
                ViewBag.SearchInput =!string.IsNullOrEmpty(pnrNo)? pnrNo : phoneNo;
                return View(_mod);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    public JsonResult Get_Call_History(string searchno,string searchtype)
        {
        Classes.SessionHandler.ValidateSession(ref _userdetails);
        InboundModel _mod = new InboundModel();
        DBHandler _dbcontext = new DBHandler();
        var list = _dbcontext.Get_Inbound_Call_History("Inbound_Call_History", searchno ?? "", searchtype??"", "", _userdetails.userID, _userdetails.privilege.ToString(), _userdetails.region.ToString()).ToList();
        return Json(list, JsonRequestBehavior.AllowGet);
        }


    public JsonResult GetPreviousCallInfoById(string id)
    {
        Classes.SessionHandler.ValidateSession(ref _userdetails);
        try
        {
            DBHandler _dbcontext = new DBHandler();
            var list = _dbcontext.Get_Previous_Call_Details("Get_Previous_Call_Details", id ?? "0", "", "", _userdetails.userID, _userdetails.privilege.ToString(), _userdetails.region.ToString()).ToList();
            InboundModel model = list.FirstOrDefault();
            string value = string.Empty;
            value = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public JsonResult EncryptPhone(string phoneNo)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(phoneNo))
                {
                    return Json(new
                    {
                        status = "error",
                        msg = "Phone number is required"
                    }, JsonRequestBehavior.AllowGet);
                }
                string encryptedPhone = Cryptography.Encrypt(phoneNo);
                return Json(new
                {
                    status = "success",
                    encryptedPhone = encryptedPhone
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    status = "error",
                    msg = ex.Message
                }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult getMaintype(string id)
    {
        try
        {
            JsonResult result = new JsonResult();
            result.Data = get_maintype_listItem(id);
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }
    }

    private List<SelectListItem> get_maintype_listItem(string id)
    {
        Classes.SessionHandler.ValidateSession(ref _userdetails);
        DBHandler _dbcontext = new DBHandler();
        var list = _dbcontext.Get_UI_Element_List("MainType", id, "", "", _userdetails.userID, _userdetails.privilege.ToString(), _userdetails.region.ToString()).ToList();
        return list;
    }

    public JsonResult getSubtype(string id)
    {
        try
        {
            JsonResult result = new JsonResult();
            result.Data = get_subtype_list(id);
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }
    }

    private List<SelectListItem> get_subtype_list(string id)
    {
        Classes.SessionHandler.ValidateSession(ref _userdetails);
        DBHandler _dbcontext = new DBHandler();
        var list = _dbcontext.Get_UI_Element_List("SubType", id, "", "", _userdetails.userID, _userdetails.privilege.ToString(), _userdetails.region.ToString()).ToList();
        return list;
    }


    public JsonResult getresolution(string id)
    {
        try
        {
            JsonResult result = new JsonResult();
            result.Data = get_resolution_list(id);
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }
    }

       
        private List<SelectListItem> get_resolution_list(string id)
    {
        Classes.SessionHandler.ValidateSession(ref _userdetails);
        DBHandler _dbcontext = new DBHandler();
        var list = _dbcontext.Get_UI_Element_List("Resolution", id, "", "", _userdetails.userID, _userdetails.privilege.ToString(), _userdetails.region.ToString()).ToList();
        return list;
    }
    
        [HttpPost]
    public JsonResult PostData(InboundModel mod)
    {
        Classes.SessionHandler.ValidateSession(ref _userdetails);
        try
        {
            DBHandler _dbcontext = new DBHandler();
            InboundModel _mod = new InboundModel();
                
            var data = _dbcontext.Add_Inbound_Call_Details(
                    mod.id,
                    mod.registerId,
                    mod.phoneNo ?? "",
                    mod.pnr ?? "",
                    mod.referenceId ?? "",
                    mod.name ?? "",
                    mod.callerCategory ?? "",
                    mod.callingState ?? "",
                    mod.language ?? "",
                    mod.qrc ?? "",
                    mod.mainType ?? "",
                    mod.subType ?? "",
                    mod.resolution1 ?? "",
                    mod.CaseEscalated ?? "",
                    mod.journeyType ?? "",
                    mod.origin ?? "",
                    mod.destination ?? "",
                    mod.flightNo ?? "",
                    mod.penaltyAmt ?? "",
                    mod.other_services ?? "",
                    mod.paymentType ?? "",
                    mod.paymentCard ?? "",
                    mod.cardType ?? "",
                    mod.payAmount ?? "",
                    mod.bank ?? "",
                    mod.payment_status ?? "",
                    mod.transactionId ?? "",
                    mod.remarks ?? "".Replace("\n", " ").Replace("\t", " ").Replace("'", "´"),
                    mod.campaignId ?? "",
                    mod.crtObjectId ?? "",
                    mod.userCrtObjectId ?? "",
                    mod.customerId ?? "",
                    mod.dialerSessionId ?? "",
                    mod.maskingEnabled ?? "",
                    mod.lead_name ?? "",
                    mod.leadId ?? "",
                    mod.callType ?? "",
                    mod.ameyo_userId ?? "",
                    mod.Escalation_remarks ?? "".Replace("\n", " ").Replace("\t", " ").Replace("'", "´"),
                    mod.Inb_status ?? "",
                    mod.call_transfer ?? "",
                    mod.If_yes ?? "",
                    _userdetails.userID,
                    _userdetails.privilege.ToString(),
                    _userdetails.region.ToString()
                    );


            return Json(data, JsonRequestBehavior.AllowGet);

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }

    }



    [HttpPost]
    public JsonResult Dispose_Call(InboundModel mod)
    {
        Classes.SessionHandler.ValidateSession(ref _userdetails);
        try
        {
            Response obj = new Response();
            InboundModel _mod = new InboundModel();

            if (mod.campaignId != null)
            {
                Classes.Dispose_Call disp = new Classes.Dispose_Call();
                disp.DialerDisposition(mod.campaignId, mod.crtObjectId,
                mod.userCrtObjectId, mod.customerId, mod.dialerSessionId, mod.phoneNo,
                mod.dispositionName, "", "INB");

                obj.status = "success";
                obj.msg = "Call Disposed Successfully";

            }
            else
            {
                obj.status = "error";
                obj.msg = "Invalid Dialer Session";
            }

            return Json(obj, JsonRequestBehavior.AllowGet);

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }
    }


    [HttpGet]
    public JsonResult Payment_Tab(string id)
    {
        Classes.SessionHandler.ValidateSession(ref _userdetails);
        try
        {
            Response obj = new Response();
            DataTable dt = new DataTable();
            DBHandler _dbcontext = new DBHandler();
            dt = _dbcontext.Get_UI_Element("Payment_Tab_Availability", id, "", "", _userdetails.userID, _userdetails.privilege.ToString(), _userdetails.region.ToString());
                
            if (dt.Rows.Count>0)
            {
                obj.status = "success";
                obj.msg = "";

            }
            else
            {
                obj.status = "error";
                obj.msg = "";
            }

            return Json(obj, JsonRequestBehavior.AllowGet);

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }
    }





    public ActionResult Inbound_Data()
    {
        Classes.SessionHandler.ValidateSession(ref _userdetails);
        try
        {
            //if (_userdetails.privilege <= 8)
            //{
                string UserName = _userdetails.userID;
                DBHandler _dbcontext = new DBHandler();
                var list = _dbcontext.Get_Inbound_List("Get_Inbound_Details", "", "", "", _userdetails.userID, _userdetails.privilege.ToString(), _userdetails.region.ToString()).ToList();
                if (ModelState.IsValid)
                {
                    return View(list);
                }
                else
                {
                    return View();
                }
            //}
            //else
            //{
            //    return RedirectToAction("Login", "Login");
            //}
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }
    }

    public void Export_Inbound_Management()
    {
        Classes.SessionHandler.ValidateSession(ref _userdetails);
        try
        {
            Classes.ListToDataTable listDt = new Classes.ListToDataTable();
            Classes.Export Exp = new Classes.Export();
            DataTable dt = new DataTable();

            string UserName = _userdetails.userID;
            DBHandler _dbcontext = new DBHandler();
            var list = _dbcontext.Get_Inbound_Escalation_History("Get_Inbound_Details", "", "", "", _userdetails.userID, _userdetails.privilege.ToString(), _userdetails.region.ToString()).ToList();
            dt = listDt.ToDataTable(list);
           // dt.Columns.Remove("GUID");
            if (dt.Rows.Count > 0)
            {
                Exp.ExportExcel(dt, "Inbound_Escalation_Details" + DateTime.Now.ToString("mm_ss"));
            }

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
            }
        }
       
        public ActionResult SupervisorScreen(string fromDate = "", string toDate = "")
        {
            Classes.SessionHandler.ValidateSession(ref _userdetails);

            DBHandler _dbcontext = new DBHandler();

            var list = _dbcontext.Get_Inboundsupervisor_List(
                "Get_InboundSupervisor_Details",
                fromDate,
                toDate,
                "",
                _userdetails.userID,
                _userdetails.privilege.ToString(),
                _userdetails.region.ToString()
            ).ToList();


            if (list == null || list.Count == 0)
            {
                ViewBag.Message = "No data found.";
            }
            else
            {
                ViewBag.Message = "Data found.";
            }

            return View(list);
        }
        public JsonResult GetSupervisorDashboard()
        {
            Classes.SessionHandler.ValidateSession(ref _userdetails);

            DBHandler _dbcontext = new DBHandler();

            var dashboard = _dbcontext.Get_InboundSupervisor_Dashboard(
                "Get_InboundSupervisor_Dashboard",
                "",
                "",
                "",
                _userdetails.userID,
                _userdetails.privilege.ToString(),
                _userdetails.region.ToString()
            ).ToList();

            if (dashboard != null && dashboard.Count > 0)
            {
                return Json(new
                {
                    success = true,
                    monthName = dashboard[0].MonthName,
                    totalRequests = dashboard[0].TotalRequests,
                    openCases = dashboard[0].OpenCases,
                    closedCases = dashboard[0].ClosedCases
                }, JsonRequestBehavior.AllowGet);
            }

            return Json(new
            {
                success = true,
                monthName = DateTime.Now.ToString("MMM yyyy"),
                totalRequests = 0,
                openCases = 0,
                closedCases = 0
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult SaveSupervisorDetails(InboundModel model)
        {
            try
            {
                Classes.SessionHandler.ValidateSession(ref _userdetails);

                DBHandler _dbcontext = new DBHandler();

                //string closureDateTime = null;

                string closureDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");


                DataTable dt = _dbcontext.Save_Inbound_Supervisor_Action(
                    model.id,
                    model.ValidatedStatus,
                    model.ActionedBy,
                    model.ActionBySupervisor,
                    model.SupervisorStatus,
                    closureDateTime
                    //,
                    //model.ETAForClosure
                );


                if (dt != null && dt.Rows.Count > 0)
                {
                    return Json(new
                    {
                        success = true,
                        message = dt.Rows[0]["Message"].ToString()
                    });
                }
                else
                {
                    return Json(new
                    {
                        success = false,
                        message = "No response received"
                    });
                }

            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    message = ex.ToString()
                });
            }
        }
    }
}