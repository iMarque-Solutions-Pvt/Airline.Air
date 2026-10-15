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
    public class DashboardController : Controller
    {
        Classes.UserDetails _userdetails = new Classes.UserDetails();
        string fromDate, toDate, reportName, searchType;
        
        public ActionResult AgentReport(string from, string to, string reportId, string searchType)
        {
            Classes.SessionHandler.ValidateSession(ref _userdetails);
            try
            {
                DashboardModel _model = new DashboardModel();
                DataTable dt = new DataTable();
                DBHandler _dbcontext = new DBHandler();

                //if ((from != null) && (to != null))
                //{
                //    fromDate = Convert.ToDateTime(from).ToString("dd/MM/yyyy");
                //    toDate = Convert.ToDateTime(to).ToString("dd/MM/yyyy");
                //    reportName = reportId;
                //}
                //else
                //{
                //    fromDate = DateTime.Today.AddDays(0).ToString("dd/MM/yyyy");
                //    toDate = DateTime.Today.AddDays(0).ToString("dd/MM/yyyy");
                //    reportName = "5";
                //}

                Classes.Utilities uti = new Classes.Utilities();
                if ((searchType != null) && (searchType != ""))
                {
                    searchType = searchType.ToString();
                }
                else
                {
                    searchType = "Today";
                }
                if ((reportId != null) && (reportId != ""))
                {
                    reportName = reportId.ToString();
                }
                else
                {
                    reportName = "5";
                }
                if ((from != null && from != "") && (to != null && to != ""))
                {
                    fromDate = Convert.ToDateTime(from).ToString("dd/MM/yyyy");
                    toDate = Convert.ToDateTime(to).ToString("dd/MM/yyyy");
                }
                else
                {
                    fromDate = DateTime.Today.AddDays(0).ToString("dd/MM/yyyy");
                    toDate = DateTime.Today.AddDays(0).ToString("dd/MM/yyyy");
                }


                var result = uti.Get_Date_Range(searchType, fromDate, toDate);
                fromDate = result.fromDate;
                toDate = result.toDate;
                _model.reporNametList = _dbcontext.Get_UI_Element_List("ReportName", "Dashboard", "", "", _userdetails.userID, _userdetails.privilege.ToString(), _userdetails.region.ToString()).ToList();

                if (reportName == "5")
                {
                    _model.hourly_dashboard = _dbcontext.Hourly_Dashboard(fromDate, toDate, reportName, _userdetails.userID, _userdetails.privilege.ToString(), _userdetails.region.ToString()).ToList();
                }


                ViewBag.DateSelection = "Data Showing here date between " + fromDate + " and " + toDate;
                return View(_model);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }


        [HttpPost]
        public ActionResult AgentReport(DashboardModel mod)
        {
            //if (mod.fromDate != null && mod.toDate != null)
            //{
            //    fromDate = Convert.ToDateTime(mod.fromDate).ToString("dd/MM/yyyy");
            //    toDate = Convert.ToDateTime(mod.toDate).ToString("dd/MM/yyyy");
            //    reportName = mod.reportName.ToString();
            //}
            //else
            //{
            //    fromDate = "";
            //    toDate = "";
            //    reportName = "";
            //}
            Classes.Utilities uti = new Classes.Utilities();
            fromDate = Convert.ToDateTime(mod.fromDate).ToString("dd/MM/yyyy");
            toDate = Convert.ToDateTime(mod.toDate).ToString("dd/MM/yyyy");
            searchType = mod.SearchType.ToString();
            reportName = mod.reportName.ToString();

            var result = uti.Get_Date_Range(searchType, fromDate, toDate);
            fromDate = result.fromDate;
            toDate = result.toDate;

            return RedirectToAction("AgentReport", "Dashboard", new { from = fromDate, to = toDate, reportId = reportName, searchType = searchType });
        }
    }
}