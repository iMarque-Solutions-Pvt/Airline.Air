using Alliance_Air_Desk.Classes;
using Alliance_Air_Desk.Models.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Alliance_Air_Desk.Controllers
{
    public class PNRController : Controller
    {
        // GET: PNR
        public ActionResult Index()
        {
            return View();
        }

        //GET_ALL_BOOK_INFO_2
        public ActionResult All_Book_Info(string book_code)
        {
            All_Book_Info mod = new All_Book_Info();

            if (book_code!=null)
            {
                if (book_code.Length > 0)
                {

                    string api_url = ConfigurationManager.AppSettings["alliance_api_url"];
                    string rqid = ConfigurationManager.AppSettings["rqid"];
                    string airline_code = ConfigurationManager.AppSettings["airline_code"];                    
                    string app = "information";
                    string action = "get_all_book_info_2";
                    //http://ws.demo.awan.sqiva.com/?rqid=5EB9FE68-8915-11E0-BEA0-C9892766ECF2&airline_code=Q1&app=information&action=get_all_book_info_2&book_code=
                    Utilities uti = new Utilities();
                    string JSON_Response = uti.CallWebService(api_url+ "?rqid=" + rqid + "&airline_code=" + airline_code + "&app=" + app+ "&action=" + action + "&book_code=" + book_code + "");
                    mod = JsonConvert.DeserializeObject<All_Book_Info>(JSON_Response);
                    if(mod.err_code=="0")
                    {
                        ViewBag.Message = "Success Response Received";
                         
                    }
                    else
                    {
                        ViewBag.ErrorMessage = mod.err_msg.ToString();
                    }

                }
            }

            return View(mod);
        }

        [HttpPost]
        public ActionResult All_Book_Info(All_Book_Info mod)
        {
            if (mod.book_code != null)
            {
                if (mod.book_code.Length>0)
                {
                    return RedirectToAction("All_Book_Info", "PNR",new { book_code=mod.book_code});
                }
            }
            return RedirectToAction("All_Book_Info", "PNR");
        }
    }
}