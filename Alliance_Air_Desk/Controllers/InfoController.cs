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
    public class InfoController : Controller
    {
        Classes.UserDetails _userdetails = new Classes.UserDetails();
        // GET: Info
        public ActionResult Marquee()
        {
            Classes.SessionHandler.ValidateSession(ref _userdetails);
            try
            {
                if (_userdetails.privilege <= 5)
                {
                    return View();
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
        public ActionResult Marquee(Marquee mod, FormCollection formCollection)
        {
            Classes.SessionHandler.ValidateSession(ref _userdetails);
            try
            {
                if (_userdetails.privilege <= 5)
                {
                    //mod.bgcolor = formCollection["bgcolor"];
                    //mod.color = formCollection["color"];
                    DataTable dt = new DataTable();
                    DBHandler _dbcontext = new DBHandler();

                    dt = _dbcontext.Add_Marquee(

                        mod.message ?? "", mod.bgcolor ?? "#000080",
                        mod.color ?? "#ffffff", mod.scrollamount.ToString(),
                        _userdetails.userID, _userdetails.privilege.ToString(), _userdetails.region.ToString());
                    if (dt.Rows.Count > 0)
                    {
                        ModelState.Clear();
                        TempData["Message"] = "Marquee Added Successfully";
                    }
                    else
                    {
                        ModelState.Clear();
                        TempData["ErrorMessage"] = "Marquee Not Added";
                    }
                    return View();
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