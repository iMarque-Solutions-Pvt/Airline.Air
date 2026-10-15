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
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            Session.Clear();
            
            if (!((Request.QueryString["UName"] == null) && (Request.QueryString["UCode"] == null)))
            {
                string UserName = Classes.Cryptography.Decrypt(HttpUtility.UrlDecode(Request.QueryString["UName"]));
                string Password = Classes.Cryptography.Decrypt(HttpUtility.UrlDecode(Request.QueryString["UCode"]));


                if (UserName.Length > 0 && Password.Length > 0)
                {
                    LoginModel obj = new LoginModel();
                    {
                        obj.userId = UserName;
                        obj.password = Password;
                    }
                    return View(obj);
                }
                else
                {
                    return View(new LoginModel());
                }
            }
            else
            {
                return View(new LoginModel());
            }

        }

        [HttpPost]
        public ActionResult Login(LoginModel _mod)
        {
            try
            {                
                DBHandler _dbcontext = new DBHandler();
                Classes.Check_Device CD = new Classes.Check_Device();

                bool isMobile = CD.IsMobileDevice();

                _mod.isMobileDevice = isMobile ? 1 : 0;


                string ipaddress;

                ipaddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (ipaddress == "" || ipaddress == null)
                    ipaddress = Request.ServerVariables["REMOTE_ADDR"];

                _mod.sessionId = HttpContext.Session.SessionID;
                _mod.ipAddress = ipaddress;
                
                DataTable dt = _dbcontext.Login(_mod);
                if (dt.Rows[0]["MSG"].ToString().ToUpper().Equals("SUCCESS"))
                {
                    Session["userID"] = dt.Rows[0]["userId"].ToString();
                    Session["userName"] = dt.Rows[0]["userName"].ToString();
                    Session["privilege"] = dt.Rows[0]["privilege"].ToString();
                    Session["region"] = dt.Rows[0]["region"].ToString();
                    Session["sessionID"] = dt.Rows[0]["sessionID"].ToString();
                    Classes.UserDetails _UserDetails = new Classes.UserDetails();

                    _UserDetails.userID = dt.Rows[0]["userId"].ToString();
                    _UserDetails.userName = dt.Rows[0]["userName"].ToString();                    
                    _UserDetails.privilege = Convert.ToInt32(dt.Rows[0]["privilege"].ToString());                                        
                    _UserDetails.region = Convert.ToInt32(dt.Rows[0]["region"].ToString());                    
                    _UserDetails.isMobileDevice = dt.Rows[0]["isMobileDevice"].ToString() == "1" ? true : false;
                    _UserDetails.sessionID = dt.Rows[0]["sessionId"].ToString();

                    Session["UserDetails"] = _UserDetails;
                    return RedirectToAction("Index", "Home");
                   
                }
                else
                {
                    //ViewBag.ErrorMessage = "Login Failed: Invalid Username or Bad Password or Account Blocked";
                    ViewBag.ErrorMessage = dt.Rows[0]["MSG"].ToString();
                }
                return View();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }
    }
}