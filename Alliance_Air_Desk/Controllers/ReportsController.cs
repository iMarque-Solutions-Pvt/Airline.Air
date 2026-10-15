using Alliance_Air_Desk.Models.DBHandler;
using Alliance_Air_Desk.Models.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Alliance_Air_Desk.Controllers
{
    [HandleError]
    public class ReportsController : Controller
    {
        Classes.UserDetails _userdetails = new Classes.UserDetails();
        // GET: Reports
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Downloads()
        {
            Classes.SessionHandler.ValidateSession(ref _userdetails);
            try
            {
                if (_userdetails.privilege <= 6)
                {
                    DBHandler _dbcontext = new DBHandler();
                    ReportModel RM = new ReportModel();
                    RM.reporNametList = _dbcontext.Get_UI_Element_List("ReportName", "", "", "", _userdetails.userID, _userdetails.privilege.ToString(), _userdetails.region.ToString()).ToList();
                    return View(RM);
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


        [HttpPost]
        public ActionResult Downloads(ReportModel mod, FormCollection fc)
        {
            Classes.SessionHandler.ValidateSession(ref _userdetails);
            try
            {

                if (_userdetails.privilege <= 6)
                {
                    string ReportName;

                    if (Request.Form["hdReportName"] != null)
                    {
                        ReportName = Request.Form["hdReportName"].Replace(" ", "_") + "_" + DateTime.Now.ToString("mm_ss");
                    }
                    else
                    {
                        ReportName = "Report" + DateTime.Now.ToString("mm_ss");
                    }

                    DBHandler _dbcontext = new DBHandler();

                    DataTable dt = _dbcontext.Downloads_Reports(
                        Convert.ToDateTime(mod.fromDate).ToString("dd/MM/yyyy"),
                        Convert.ToDateTime(mod.toDate).ToString("dd/MM/yyyy"),
                        mod.reportName.ToString(),
                        _userdetails.userID,
                        _userdetails.privilege.ToString(),
                        _userdetails.region.ToString()
                        );
                    if (dt.Rows.Count > 0)
                    {
                        Classes.Export Exp = new Classes.Export();
                        Exp.ExportExcel(dt, ReportName);

                        ViewBag.Message = "Download Completed";
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "No data Found";
                    }

                    ReportModel RM = new ReportModel();
                    RM.reporNametList = _dbcontext.Get_UI_Element_List("ReportName", "", "", "", _userdetails.userID, _userdetails.privilege.ToString(), _userdetails.region.ToString()).ToList();
                    return View(RM);
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
    }
}