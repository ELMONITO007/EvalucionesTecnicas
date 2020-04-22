using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Web;
using System.Web.Mvc;
using GoogleMapsApi;

namespace Safari.UI.Web.Controllers
{
    public class HomeController : Controller
    {
       [Route("",Name ="HomeControllerRouteIndex")]
        public ActionResult Index()
        {
            return View();
        }
       
    }
}