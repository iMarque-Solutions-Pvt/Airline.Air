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
    public class QC_DisruptionController : Controller
    {
        string mailDate,travelDate;
        Classes.UserDetails _userdetails = new Classes.UserDetails();
        // GET: QC_Disruption
        public ActionResult Index()
        { 
            
            Classes.SessionHandler.ValidateSession(ref _userdetails);
            try
            {
                DataTable dt = new DataTable();
                QC_DisruptionModel _mod = new QC_DisruptionModel();
                DBHandler _dbcontext = new DBHandler();
                ViewBag.scenario_list = _dbcontext.Get_UI_Element_List("Disruption_Type", "", "", "", _userdetails.userID, _userdetails.privilege.ToString(), _userdetails.region.ToString()).ToList();
                ViewBag.crm_Tagging_list = new List<SelectListItem>() { new SelectListItem() { Value = "Y", Text = "Yes" }, new SelectListItem() { Value = "N", Text = "No" } };
                ViewBag.sms_Sent_list = new List<SelectListItem>() { new SelectListItem() { Value = "Y", Text = "Yes" }, new SelectListItem() { Value = "N", Text = "No" } };
                ViewBag.mail_Sent_list = new List<SelectListItem>() { new SelectListItem() { Value = "Y", Text = "Yes" }, new SelectListItem() { Value = "N", Text = "No" } };
                return View(_mod);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }


        }
        [HttpPost]
        public JsonResult PostData(QC_DisruptionModel mod)
        {
            Classes.SessionHandler.ValidateSession(ref _userdetails);
            try
            {
                DBHandler _dbcontext = new DBHandler();

                if (mod.mailDate != null)
                {
                    mailDate = Convert.ToDateTime(mod.mailDate).ToString("dd/MM/yyyy HH:mm:ss");
                }
                 if (mod.travelDate != null)
                {
                    travelDate = Convert.ToDateTime(mod.travelDate).ToString("dd/MM/yyyy HH:mm:ss");
                }

                var data = _dbcontext.Add_QCDisruption_Managment(
                        mod.rowid.ToString() ?? "",
                        mod.guid ?? "",
                        mod.resk ?? "",
                        mailDate ?? "",
                        mod.subject  ?? "",
                        travelDate ?? "",
                        mod.flightNo ?? "",
                        mod.scenario ?? "",
                        mod.crm_Tagging ?? "",
                        mod.sms_Sent ?? "",
                        mod.mail_Sent ?? "",
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
    }
}