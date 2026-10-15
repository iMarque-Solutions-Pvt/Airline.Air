using Alliance_Air_Desk.Models.DBHandler;
using Alliance_Air_Desk.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Mvc;

namespace Alliance_Air_Desk.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        Classes.UserDetails _userdetails = new Classes.UserDetails();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult getMarquee()
        {
            try
            {
                Marquee mod = new Marquee();
                Classes.SessionHandler.ValidateSession(ref _userdetails);
                string UserName = _userdetails.userID;
                DBHandler _dbcontext = new DBHandler();
                DataTable dt = new DataTable();
                dt = _dbcontext.Get_UI_Element("Marquee", "", "", "", _userdetails.userID, _userdetails.privilege.ToString(), _userdetails.region.ToString());
                if (dt.Rows.Count > 0)
                {
                    mod.message = dt.Rows[0]["message"].ToString();
                    mod.bgcolor = dt.Rows[0]["bgcolor"].ToString();
                    mod.color = dt.Rows[0]["color"].ToString();
                    mod.scrollamount = Convert.ToInt32(dt.Rows[0]["scrollamount"].ToString());
                }


                return PartialView("_Marquee", mod);
            }
            catch (Exception ex)
            {
                var error = ex.Message.ToString();
                return Content("Error");
            }
        }
    }
}