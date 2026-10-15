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
    public class ContentController : Controller
    {
        // GET: Content
        Classes.UserDetails _userdetails = new Classes.UserDetails();
        public ActionResult Index()
        {
            Classes.SessionHandler.ValidateSession(ref _userdetails);
            try
            {
                ContentModel _model = new ContentModel();

                if (_userdetails.privilege <= 4)
                {
                    string UserName = _userdetails.userID;
                    DBHandler _dbcontext = new DBHandler();
                    ViewBag.disruption_type_list = _dbcontext.Get_UI_Element_List("Disruption_Type", "", "", "", _userdetails.userID, _userdetails.privilege.ToString(), _userdetails.region.ToString()).ToList();
                    _model._Content_Template = _dbcontext.Get_Content_Template_List("Get_Content_Template", "", "", "", _userdetails.userID, _userdetails.privilege.ToString(), _userdetails.region.ToString()).ToList();
                    if (ModelState.IsValid)
                    {
                        return View(_model);
                    }
                    else
                    {
                        return View(_model);
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

        public JsonResult Add_Template(ContentModel model)
        {
            Classes.SessionHandler.ValidateSession(ref _userdetails);
            try
            {
                DBHandler _dbcontext = new DBHandler();
                //var list = _dbcontext.Template_Management(model, _userdetails.userID, _userdetails.privilege.ToString(), _userdetails.region.ToString());
                var data = _dbcontext.Template_Management(model, _userdetails.userID, _userdetails.privilege.ToString(), _userdetails.region.ToString());
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public JsonResult GeTemplateById(string id)
        {
            Classes.SessionHandler.ValidateSession(ref _userdetails);
            try
            {
                DBHandler _dbcontext = new DBHandler();
                var list = _dbcontext.Get_Content_Template_List("Get_Content_Template", id??"0", "", "", _userdetails.userID, _userdetails.privilege.ToString(), _userdetails.region.ToString()).ToList();
                Content_Template model = list.FirstOrDefault();
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
        public JsonResult DeleteTemplateByID(string id)
        {
            Classes.SessionHandler.ValidateSession(ref _userdetails);
            try
            {
                DataTable dt = new DataTable();
                DBHandler _dbcontext = new DBHandler();
                dt = _dbcontext.Get_UI_Element("Delete_Content_template", id ?? "0", "", "", _userdetails.userID, _userdetails.privilege.ToString(), _userdetails.region.ToString());
                Response result = new Response();
                if (dt.Rows[0]["MSG"].ToString().ToUpper().Equals("DELETED"))
                {
                    result.status = "success";
                    result.msg = "Template Deleted Successfully";
                }              
                else
                {
                    result.status = "error";
                    result.msg = dt.Rows[0]["MSG"].ToString();
                }
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}