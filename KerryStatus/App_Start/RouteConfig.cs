using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace KerryStatus
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("Index.cshtml");
            //routes.MapRoute(
            //    name: "billStatus",
            //    url: "them-trang-thai-don-hang",
            //    defaults: new { controller = "Status", action = "billStatus", id = UrlParameter.Optional }
            //);
            routes.MapRoute(
                name: "SearchStatus",
                url: "tra-cuu-trang-thai",
                defaults: new { controller = "Status", action = "SearchStatus", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "searchWaybillPMI",
                url: "searchWaybillPMI",
                defaults: new { controller = "Waybill", action = "searchWaybillPMI", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "ResultSearchStatus",
                url: "ket-qua-tra-cuu-trang-thai",
                defaults: new { controller = "Status", action = "ResultSearchStatus", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "UpdateStatus",
                url: "cap-nhap-trang-thai",
                defaults: new { controller = "Status", action = "updateStatus", id = UrlParameter.Optional, so_bill = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "updateBillStatus",
                url: "updateBillStatus",
                defaults: new { controller = "Status", action = "updateBillStatus", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Status", action = "SearchStatus", id = UrlParameter.Optional }
            );
        }
    }
}
