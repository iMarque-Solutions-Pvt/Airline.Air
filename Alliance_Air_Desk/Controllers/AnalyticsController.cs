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
    public class AnalyticsController : Controller
    {
        string fromDate, toDate ,searchType;
        Classes.UserDetails _userdetails = new Classes.UserDetails();
        // GET: Analytics
        public ActionResult Index(string from, string to, string searchType)
        {
            Classes.SessionHandler.ValidateSession(ref _userdetails);
            try
            {
                AnalyticsModel _model = new AnalyticsModel();
                DataTable dt = new DataTable();
                DBHandler _dbcontext = new DBHandler();
                Classes.Utilities uti = new Classes.Utilities();
                if ((searchType != null) && (searchType != ""))
                {
                    searchType = searchType.ToString();
                }
                else
                {
                    searchType = "Today";
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

                //if ((from != null) && (to != null))
                //{
                //    fromDate = Convert.ToDateTime(from).ToString("dd/MM/yyyy");
                //    toDate = Convert.ToDateTime(to).ToString("dd/MM/yyyy");
                //}
                //else
                //{
                //    fromDate = DateTime.Today.AddDays(-59).ToString("dd/MM/yyyy");
                //    toDate = DateTime.Today.AddDays(0).ToString("dd/MM/yyyy");
                //}


                //var qrc_analytics = _dbcontext.get_Analytics(fromDate, toDate, "4", _userdetails.userID, _userdetails.privilege.ToString(), _userdetails.region.ToString()).ToList();
                //ViewBag.qrc_analytics = JsonConvert.SerializeObject(qrc_analytics);

                //var language_analytics = _dbcontext.get_Analytics(fromDate, toDate, "5", _userdetails.userID, _userdetails.privilege.ToString(), _userdetails.region.ToString()).ToList();
                //ViewBag.language_analytics = JsonConvert.SerializeObject(language_analytics);

                var QC_Status_analytics = _dbcontext.get_Analytics(fromDate, toDate, "9", _userdetails.userID, _userdetails.privilege.ToString(), _userdetails.region.ToString()).ToList();
                ViewBag.QC_Status_analytics = JsonConvert.SerializeObject(QC_Status_analytics);


                var maintype_analytics = _dbcontext.get_Analytics(fromDate, toDate, "4", _userdetails.userID, _userdetails.privilege.ToString(), _userdetails.region.ToString()).ToList();
                ViewBag.maintype_analytics = JsonConvert.SerializeObject(maintype_analytics);

                var Hourlychart_analytics = _dbcontext.get_Analytics(fromDate, toDate, "6", _userdetails.userID, _userdetails.privilege.ToString(), _userdetails.region.ToString()).ToList();
                ViewBag.Hourlychart_analytics = JsonConvert.SerializeObject(Hourlychart_analytics);


                ViewBag.DateSelection = "Data Showing here date between " + fromDate + " and " + toDate;
                return View(_model);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        [HttpPost]
        public ActionResult Index(AnalyticsModel mod)
        {
            //if (mod.fromDate != null && mod.toDate != null)
            //{
            //    fromDate = Convert.ToDateTime(mod.fromDate).ToString("dd/MM/yyyy");
            //    toDate = Convert.ToDateTime(mod.toDate).ToString("dd/MM/yyyy");
            //}
            //else
            //{
            //    fromDate = "";
            //    toDate = "";
            //}
            Classes.Utilities uti = new Classes.Utilities();
            fromDate = Convert.ToDateTime(mod.fromDate).ToString("dd/MM/yyyy");
            toDate = Convert.ToDateTime(mod.toDate).ToString("dd/MM/yyyy");
            searchType = mod.SearchType.ToString();


            var result = uti.Get_Date_Range(searchType, fromDate, toDate);
            fromDate = result.fromDate;
            toDate = result.toDate;

            return RedirectToAction("Index", "Analytics", new { from = fromDate, to = toDate, searchType = searchType });
        }

    }
}