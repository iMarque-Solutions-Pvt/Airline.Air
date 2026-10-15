using Alliance_Air_Desk.Models.DBHandler;
using Alliance_Air_Desk.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Data;
using System.Text;
using System.Web.Mvc;


namespace Alliance_Air_Desk.Controllers
{
    public class MailActionController : Controller
    {
        string Mail_date;
       Classes.UserDetails _userdetails = new Classes.UserDetails();
        // GET: MailAction
        public ActionResult Index()
        {
            //string searchType, Email = "";
            Classes.SessionHandler.ValidateSession(ref _userdetails);
            try
            {
                DataTable dt = new DataTable();
                MailActionModel _mod = new MailActionModel();
                DBHandler _dbcontext = new DBHandler();

                _mod.QRC_List = _dbcontext.Get_UI_Element_List("QRC", "", "", "", _userdetails.userID, _userdetails.privilege.ToString(), _userdetails.region.ToString()).ToList();
                _mod.type_of_mail_List = _dbcontext.Get_UI_Element_List("MainType", "", "", "", _userdetails.userID, _userdetails.privilege.ToString(), _userdetails.region.ToString()).ToList();
                _mod.subType_List = _dbcontext.Get_UI_Element_List("SubType", "", "", "", _userdetails.userID, _userdetails.privilege.ToString(), _userdetails.region.ToString()).ToList();
                _mod.resolution_List = _dbcontext.Get_UI_Element_List("Resolution", "", "", "", _userdetails.userID, _userdetails.privilege.ToString(), _userdetails.region.ToString()).ToList();
                _mod.resolution2_List = _dbcontext.Get_UI_Element_List("Resolution2", "", "", "", _userdetails.userID, _userdetails.privilege.ToString(), _userdetails.region.ToString()).ToList();

                //_mod.type_of_mail_List = _dbcontext.Get_UI_Element_List("MailType", "", "", "", _userdetails.userID, _userdetails.privilege.ToString(), _userdetails.region.ToString()).ToList();
                //_mod.subType_List = _dbcontext.Get_UI_Element_List("Mail_SubType", "", "", "", _userdetails.userID, _userdetails.privilege.ToString(), _userdetails.region.ToString()).ToList();
                //_mod.resolution_List = _dbcontext.Get_UI_Element_List("Mail_Resolution", "", "", "", _userdetails.userID, _userdetails.privilege.ToString(), _userdetails.region.ToString()).ToList();

                return View(_mod);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
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
            var list = _dbcontext.Get_UI_Element_List("Mail_SubType", id, "", "", _userdetails.userID, _userdetails.privilege.ToString(), _userdetails.region.ToString()).ToList();
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
            var list = _dbcontext.Get_UI_Element_List("Mail_Resolution", id, "", "", _userdetails.userID, _userdetails.privilege.ToString(), _userdetails.region.ToString()).ToList();
            return list;
        }

        public JsonResult Get_Mail_History(string searchno, string searchtype)
        {
            Classes.SessionHandler.ValidateSession(ref _userdetails);
            InboundModel _mod = new InboundModel();
            DBHandler _dbcontext = new DBHandler();
            var list = _dbcontext.Get_Mail_History("MailAction_History", searchno ?? "", searchtype ?? "", "", _userdetails.userID, _userdetails.privilege.ToString(), _userdetails.region.ToString()).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPreviousMailInfoById(string id)
        {
            Classes.SessionHandler.ValidateSession(ref _userdetails);
            try
            {

                DBHandler _dbcontext = new DBHandler();
                var list = _dbcontext.Get_Previous_Mail_Details("Get_Previous_Mail_Details", id ?? "0", "", "", _userdetails.userID, _userdetails.privilege.ToString(), _userdetails.region.ToString()).ToList();

                MailActionModel model = list.FirstOrDefault();
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

        [HttpPost]
        public JsonResult PostData(MailActionModel mod)
        {
            Classes.SessionHandler.ValidateSession(ref _userdetails);
            try
            {
                DBHandler _dbcontext = new DBHandler();
                MailActionModel _mod = new MailActionModel();
                if (mod.date_of_mail != null)
                {
                    Mail_date = Convert.ToDateTime(mod.date_of_mail).ToString("dd/MM/yyyy HH:mm:ss");
                }

                var data = _dbcontext.Add_MailAction_Details(
                        // mod.registerId,
                        mod.rowid.ToString() ?? "",
                        mod.guid ?? "",
                        mod.fromEmail ?? "",
                        Mail_date ?? "",
                        mod.pnr ?? "",
                        mod.phoneNo ?? "",
                        mod.referenceId ?? "",
                        mod.mailSubject ?? "".Replace("\n", " ").Replace("\t", " ").Replace("'", "´"),
                        mod.mailContent ?? "".Replace("\n", " ").Replace("\t", " ").Replace("'", "´"),
                        mod.QRC ?? "",
                        mod.type_of_mail ?? "",
                        mod.subType ?? "",
                        mod.resolution ?? "",
                        mod.resolution2 ?? "",
                        mod.content_template ?? "".Replace("\n", " ").Replace("\t", " ").Replace("'", "´"),
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

        //public ActionResult Index(string id)
        //{
        //    Classes.SessionHandler.ValidateSession(ref _userdetails);
        //    try
        //    {
        //        if (_userdetails.privilege <= 4)
        //        {
        //            DataTable dt = new DataTable();
        //            DBHandler _dbcontext = new DBHandler();
        //            MailActionModel _model = new MailActionModel();
        //            ViewBag.type_of_mail_List = _dbcontext.Get_UI_Element_List("MailType", "", "", "", _userdetails.userID, _userdetails.privilege.ToString(), _userdetails.region.ToString()).ToList();
        //            ViewBag.subType_List = _dbcontext.Get_UI_Element_List("Mail_SubType", "", "", "", _userdetails.userID, _userdetails.privilege.ToString(), _userdetails.region.ToString()).ToList();
        //            ViewBag.resolution_List = _dbcontext.Get_UI_Element_List("Mail_Resolution", "", "", "", _userdetails.userID, _userdetails.privilege.ToString(), _userdetails.region.ToString()).ToList();


        //            if (id != null)
        //            {
        //                if (id.Length > 0)
        //                {
        //                    dt = _dbcontext.Get_UI_Element("Get_MailAction_Details_Edit", id ?? "", "", "", _userdetails.userID, _userdetails.privilege.ToString(), _userdetails.region.ToString());
        //                    if (dt.Rows.Count > 0)
        //                    {
        //                        _model.rowid = Convert.ToInt32(dt.Rows[0]["id"].ToString());
        //                        _model.guid = dt.Rows[0]["guid"].ToString();
        //                        _model.fromEmail = dt.Rows[0]["EmailID"].ToString();
        //                        _model.date_of_mail = dt.Rows[0]["Email_Date"].ToString();
        //                        _model.phoneNo = dt.Rows[0]["phoneNo"].ToString();
        //                        _model.pnr = dt.Rows[0]["pnr"].ToString();
        //                        _model.referenceId = dt.Rows[0]["referenceId"].ToString();
        //                        _model.mailSubject = dt.Rows[0]["mailSubject"].ToString();
        //                        _model.mailContent = dt.Rows[0]["mailContent"].ToString();
        //                        _model.type_of_mail = dt.Rows[0]["mailType"].ToString();
        //                        _model.subType = dt.Rows[0]["subType"].ToString();
        //                        _model.resolution = dt.Rows[0]["resolution"].ToString();
        //                        _model.content_template = dt.Rows[0]["content_template"].ToString();
        //                        _model.remarks = dt.Rows[0]["remarks"].ToString();


        //                        //"2021-01-01T00:00:00";

        //                        if (dt.Rows[0]["EmailID"].ToString().Length > 0)
        //                        {
        //                            ViewBag.date_of_mail = Convert.ToDateTime(dt.Rows[0]["Email_Date"].ToString()).ToString("yyyy-MM-ddTHH:mm:ss");
        //                        }


        //                    }
        //                }
        //            }
        //            return View(_model);
        //        }
        //        else
        //        {
        //            return RedirectToAction("Index", "Login");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message.ToString());
        //    }
        //}



    }
}
