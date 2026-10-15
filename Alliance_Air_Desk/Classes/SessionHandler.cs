using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alliance_Air_Desk.Classes
{
    [Serializable]
    public class SessionHandler
    {
        public static void ValidateSession()
        {
            if (System.Web.HttpContext.Current.Session["userID"] == null)
            {
                System.Web.HttpContext.Current.Response.Redirect("~/Login/Login");
            }
        }
        public static void ClearSessions()
        {
            System.Web.HttpContext.Current.Session["userID"] = null;
            System.Web.HttpContext.Current.Session["privilege"] = null;
            ValidateSession();
        }
        public static void ValidateSession(ref UserDetails _UserDetails)
        {
            if (HttpContext.Current.Session["UserDetails"] == null)
            {
                System.Web.HttpContext.Current.Response.Redirect("~/Login/Login");

            }
            else
            {
                _UserDetails = (UserDetails)HttpContext.Current.Session["UserDetails"];
            }
        }
    }
}