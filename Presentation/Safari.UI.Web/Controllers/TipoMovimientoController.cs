
using Safari.Services.Contracts;
using Safari.Services.Contracts.Request;
using Safari.UI.Process;
using System;
using System.Web.Mvc;

namespace Safari.UI.Web.Controllers
{
    [Authorize]
    public class TipoMovimientoController : Controller
    {
        [Route("TipoMovimiento", Name = "TipoMovimientoControllerRouteIndex")]
        // GET: TipoMovimiento
        public ActionResult Index()
        {
            TipoMovimientoProcess tp = new TipoMovimientoProcess();
            var lista = tp.ToList();
            return View(lista);
        }

        [Route("Detalle_TipoMovimiento", Name = "TipoMovimientoControllerRouteDetails")]
        // GET: TipoMovimiento/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [Route("Crear_TipoMovimiento", Name = "TipoMovimientoControllerRouteCreateGet")]
        // GET: TipoMovimiento/Create
        public ActionResult Create()
        {
            return View();
        }

        [Route("Crear_TipoMovimiento", Name = "TipoMovimientoControllerRouteCreatePost")]
        // POST: TipoMovimiento/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [Route("Editar_TipoMovimiento", Name = "TipoMovimientoControllerRouteEditGet")]
        // GET: TipoMovimiento/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        [Route("Editar_TipoMovimiento", Name = "TipoMovimientoControllerRouteEditPost")]
        // POST: TipoMovimiento/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Route("Eliminar_TipoMovimiento", Name = "TipoMovimientoControllerRouteDeleteGet")]
        // GET: TipoMovimiento/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        [Route("Eliminar_TipoMovimiento", Name = "TipoMovimientoControllerRouteDeletePost")]
        // POST: TipoMovimiento/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
