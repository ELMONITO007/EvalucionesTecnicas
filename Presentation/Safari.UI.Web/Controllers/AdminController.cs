using Safari.Services.Contracts;
using Safari.Services.Contracts.Request;
using Safari.UI.Process;
using System;
using System.Web.Mvc;


namespace Safari.UI.Web.Controllers
{
    [Authorize(Roles = "Administrador")]//para entrar en admin debe estar logueado y  asignarle el rol
    public class AdminController : Controller
    {
        [Route("Admin", Name = "AdminControllerRouteIndex")]
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
    }
}