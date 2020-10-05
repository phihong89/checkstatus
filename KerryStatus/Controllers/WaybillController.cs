using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KerryStatus.Controllers
{
    public class WaybillController : Controller
    {
        // GET: Waybill
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult searchWaybillPMI()
        {
            return View();
        }
    }
}