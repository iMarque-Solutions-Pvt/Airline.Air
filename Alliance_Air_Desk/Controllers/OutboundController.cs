using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Alliance_Air_Desk.Controllers
{
    [HandleError]
    public class OutboundController : Controller
    {
        // GET: Outbound
        public ActionResult Index()
        {
            //ViewBag.Message = Notification.Show("Hello World", position: Position.BottomCenter, type: ToastType.Error, timeOut: 7000);

            TempData["message"] = "Added";
            return View();
        }
    }
}