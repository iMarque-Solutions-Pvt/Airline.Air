using Alliance_Air_Desk.Classes;
using Alliance_Air_Desk.Models.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Alliance_Air_Desk.Controllers
{
    public class WSController : Controller
    {
        // GET: WS
        public ActionResult Index()
        {
            Utilities uti = new Utilities();
            string JSON_Response = uti.CallWebService("http://ws.demo.awan.sqiva.com/?rqid=5EB9FE68-8915-11E0-BEA0-C9892766ECF2&airline_code=Q1&app=information&action=get_all_book_info_2&book_code=SP8VWX");
            All_Book_Info myDeserializedClass = JsonConvert.DeserializeObject<All_Book_Info>(JSON_Response);

            return View(myDeserializedClass);
        }



        //GET_ALL_BOOK_INFO_2
        public ActionResult All_Book_Info()
        {
            Utilities uti = new Utilities();
            string JSON_Response = uti.CallWebService("http://ws.demo.awan.sqiva.com/?rqid=5EB9FE68-8915-11E0-BEA0-C9892766ECF2&airline_code=Q1&app=information&action=get_all_book_info_2&book_code=SP8VWX");
            All_Book_Info myDeserializedClass = JsonConvert.DeserializeObject<All_Book_Info>(JSON_Response);
            
            return View(myDeserializedClass);
        }


       
    }
}