using Alliance_Air_Desk.Models.DBHandler;
using Alliance_Air_Desk.Models.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Alliance_Air_Desk.Controllers
{
    [HandleError]
    public class DisruptionController : Controller
    {
        string actual_departure_time, actual_arrival_time, revised_departure_time, revised_arrival_time, mailreceived_time;

        Classes.UserDetails _userdetails = new Classes.UserDetails();
        // GET: Disruption
        public ActionResult Index()
        {
            Classes.SessionHandler.ValidateSession(ref _userdetails);
            try
            {
                if (_userdetails.privilege <= 6 || _userdetails.privilege == 8)
                {
                    
                    string UserName = _userdetails.userID;
                    DBHandler _dbcontext = new DBHandler();
                    var list = _dbcontext.Get_Disruption_Flight_List("Get_Disruption_Details", "", "", "", _userdetails.userID, _userdetails.privilege.ToString(), _userdetails.region.ToString()).ToList();
                    if (ModelState.IsValid)
                    {
                        return View(list);
                    }
                    else
                    {
                        return View();
                    }
                }
                else
                {
                    return RedirectToAction("Login", "Login");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }


        public void Export_Disruption_Management()
        {
            Classes.SessionHandler.ValidateSession(ref _userdetails);
            try
            {
                Classes.ListToDataTable listDt = new Classes.ListToDataTable();
                Classes.Export Exp = new Classes.Export();
                DataTable dt = new DataTable();

                string UserName = _userdetails.userID;
                DBHandler _dbcontext = new DBHandler();
                var list = _dbcontext.Get_Disruption_Flight_List("Get_Disruption_Details", "", "", "", _userdetails.userID, _userdetails.privilege.ToString(), _userdetails.region.ToString()).ToList();
                dt = listDt.ToDataTable(list);
                dt.Columns.Remove("GUID");
                if (dt.Rows.Count > 0)
                {
                    Exp.ExportExcel(dt, "Disruption_Details" + DateTime.Now.ToString("mm_ss"));
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public ActionResult Management(string id)
        {
            Classes.SessionHandler.ValidateSession(ref _userdetails);
            try
            {
                if (_userdetails.privilege <= 6 || _userdetails.privilege == 8)
                {
                    DataTable dt = new DataTable();
                    DBHandler _dbcontext = new DBHandler();
                    DisruptionModel _model = new DisruptionModel();
                    ViewBag.origin_list = _dbcontext.Get_UI_Element_List("Origin", "", "", "", _userdetails.userID, _userdetails.privilege.ToString(), _userdetails.region.ToString()).ToList();
                    ViewBag.destination_list = _dbcontext.Get_UI_Element_List("Destination", "", "", "", _userdetails.userID, _userdetails.privilege.ToString(), _userdetails.region.ToString()).ToList();
                    ViewBag.revised_origin_list = _dbcontext.Get_UI_Element_List("Revised_Origin", "", "", "", _userdetails.userID, _userdetails.privilege.ToString(), _userdetails.region.ToString()).ToList();
                    ViewBag.revised_destination_list = _dbcontext.Get_UI_Element_List("Revised_Destination", "", "", "", _userdetails.userID, _userdetails.privilege.ToString(), _userdetails.region.ToString()).ToList();
                    ViewBag.disruption_type_list = _dbcontext.Get_UI_Element_List("Disruption_Type", "", "", "", _userdetails.userID, _userdetails.privilege.ToString(), _userdetails.region.ToString()).ToList();
                    ViewBag.status_list = _dbcontext.Get_UI_Element_List("Status", "", "", "", _userdetails.userID, _userdetails.privilege.ToString(), _userdetails.region.ToString()).ToList();

                    ViewBag.sms_action = _dbcontext.Get_UI_Element_List("Disruption_Action", "", "", "", _userdetails.userID, _userdetails.privilege.ToString(), _userdetails.region.ToString()).ToList();
                    ViewBag.email_action = _dbcontext.Get_UI_Element_List("Disruption_Action", "", "", "", _userdetails.userID, _userdetails.privilege.ToString(), _userdetails.region.ToString()).ToList();
                    ViewBag.out_calling_action = _dbcontext.Get_UI_Element_List("Disruption_Action", "", "", "", _userdetails.userID, _userdetails.privilege.ToString(), _userdetails.region.ToString()).ToList();
                    ViewBag.QC_status_list = _dbcontext.Get_UI_Element_List("QC_Status", "", "", "", _userdetails.userID, _userdetails.privilege.ToString(), _userdetails.region.ToString()).ToList();



                    //var dts = new DateTime(DateTime.Now.Ticks, DateTimeKind.Unspecified);
                    ViewBag.isoDateString = "2021-01-01T00:00:00";
                    //_model.actual_departure = dts.ToString("O");
                    //ViewBag.Test = DateTime.Now.ToString();

                    if (id != null)
                    {
                        if (id.Length > 0)
                        {
                            dt = _dbcontext.Get_UI_Element("Get_Disruption_Details_Edit", id ?? "", "", "", _userdetails.userID, _userdetails.privilege.ToString(), _userdetails.region.ToString());
                            if (dt.Rows.Count > 0)
                            {                               
                                _model.rowid = Convert.ToInt32(dt.Rows[0]["id"].ToString());
                                _model.guid = dt.Rows[0]["guid"].ToString();
                                _model.flight_number = dt.Rows[0]["flight_number"].ToString();
                                _model.intimation_refno = dt.Rows[0]["intimation_refno"].ToString();
                                _model.origin = dt.Rows[0]["origin"].ToString();
                                _model.destination = dt.Rows[0]["destination"].ToString();
                                _model.revised_origin = dt.Rows[0]["revised_origin"].ToString();
                                _model.revised_destination = dt.Rows[0]["revised_destination"].ToString(); 
                                _model.disruption_type = dt.Rows[0]["disruption_type"].ToString();
                                _model.sms = dt.Rows[0]["sms"].ToString();
                                _model.email = dt.Rows[0]["email"].ToString();
                                _model.out_calling = dt.Rows[0]["out_calling"].ToString();
                                _model.remarks = dt.Rows[0]["remarks"].ToString();
                                _model.status = dt.Rows[0]["status"].ToString();
                                _model.QC_status = dt.Rows[0]["QC_status"].ToString();
                                _model.QC_Doneby = dt.Rows[0]["QC_Doneby"].ToString();

                                //"2021-01-01T00:00:00";

                                if (dt.Rows[0]["actual_departure"].ToString().Length>0)
                                {
                                    ViewBag.actual_departure = Convert.ToDateTime(dt.Rows[0]["actual_departure"].ToString()).ToString("yyyy-MM-ddTHH:mm:ss");
                                }

                                if (dt.Rows[0]["actual_arrival"].ToString().Length > 0)
                                {
                                    ViewBag.actual_arrival = Convert.ToDateTime(dt.Rows[0]["actual_arrival"].ToString()).ToString("yyyy-MM-ddTHH:mm:ss");
                                }

                                if (dt.Rows[0]["revised_departure"].ToString().Length > 0)
                                {
                                    ViewBag.revised_departure = Convert.ToDateTime(dt.Rows[0]["revised_departure"].ToString()).ToString("yyyy-MM-ddTHH:mm:ss");
                                }

                                if (dt.Rows[0]["revised_arrival"].ToString().Length > 0)
                                {
                                    ViewBag.revised_arrival = Convert.ToDateTime(dt.Rows[0]["revised_arrival"].ToString()).ToString("yyyy-MM-ddTHH:mm:ss");
                                }
                                if (dt.Rows[0]["mail_received_time"].ToString().Length > 0)
                                {
                                    ViewBag.mail_received_time = Convert.ToDateTime(dt.Rows[0]["mail_received_time"].ToString()).ToString("yyyy-MM-ddTHH:mm:ss");
                                }
                            }
                        }
                    }
                    return View(_model);
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        [HttpPost]
        public ActionResult Management(DisruptionModel mod)
        {
            Classes.SessionHandler.ValidateSession(ref _userdetails);
            try
            {
                DBHandler _dbcontext = new DBHandler();
                if(mod.actual_departure!=null)
                {
                    actual_departure_time = Convert.ToDateTime(mod.actual_departure).ToString("dd/MM/yyyy HH:mm:ss");
                }
                if (mod.actual_arrival != null)
                {
                    actual_arrival_time = Convert.ToDateTime(mod.actual_arrival).ToString("dd/MM/yyyy HH:mm:ss");
                }

                if (mod.revised_departure != null)
                {
                    revised_departure_time = Convert.ToDateTime(mod.revised_departure).ToString("dd/MM/yyyy HH:mm:ss");
                }
                 
                if (mod.revised_arrival != null)
                {
                    revised_arrival_time = Convert.ToDateTime(mod.revised_arrival).ToString("dd/MM/yyyy HH:mm:ss");
                }
                if (mod.mail_received_time != null)
                {
                    mailreceived_time = Convert.ToDateTime(mod.mail_received_time).ToString("dd/MM/yyyy HH:mm:ss");
                }


                var data = _dbcontext.Add_Disruption_Managment(
                    mod.rowid.ToString()??"",
                     mod.guid ?? "",
                     mod.flight_number ?? "",
                     mod.intimation_refno ?? "",
                     mod.origin ?? "",
                     mod.destination ?? "",
                     actual_departure_time ?? "",
                     actual_arrival_time ?? "",
                     mod.revised_origin ?? "",
                     mod.revised_destination ?? "",
                     revised_departure_time ?? "",
                     revised_arrival_time ?? "",
                     mod.disruption_type ?? "",
                     mod.sms ?? "",
                     mod.email ?? "",
                     mod.out_calling ?? "",
                     mailreceived_time ?? "",
                     mod.status??"",
                     mod.QC_status ?? "",
                     mod.remarks ?? "".Replace("\n", " ").Replace("\t", " ").Replace("'", "´"),
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



        public ActionResult Details()
        {
            Classes.SessionHandler.ValidateSession(ref _userdetails);
            try
            {

                //string value = "John";
                //string value2 = "Peter";
                //string result = string.Format("My name is {0}{1}", value, value2);
                


                string UserName = _userdetails.userID;
                    DBHandler _dbcontext = new DBHandler();
                    var list = _dbcontext.Get_Disruption_Flight_List("Get_Disruption_Details_View", "", "", "", _userdetails.userID, _userdetails.privilege.ToString(), _userdetails.region.ToString()).ToList();
                    if (ModelState.IsValid)
                    {
                        return View(list);
                    }
                    else
                    {
                        return View();
                    }
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public JsonResult GetDisruptionById(string id)
        {
            Classes.SessionHandler.ValidateSession(ref _userdetails);
            try
            {

                DBHandler _dbcontext = new DBHandler();
                var list = _dbcontext.Get_Disruption_Flight_List("Get_Disruption_Details_View", id ?? "0", "", "", _userdetails.userID, _userdetails.privilege.ToString(), _userdetails.region.ToString()).ToList();

                DisruptionModel model = list.FirstOrDefault();
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
    }
}