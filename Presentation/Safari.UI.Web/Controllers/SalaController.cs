using Safari.Services.Contracts;
using Safari.Services.Contracts.Request;
using Safari.UI.Process;
using System;
using System.Web.Mvc;

namespace Safari.UI.Web.Controllers
{
    [Authorize]
    public class SalaController : Controller
    {
        [Route("Sala", Name = "SalaControllerRouteIndex")]
        // GET: Sala
        public ActionResult Index()
        {
            SalaProcess sp = new SalaProcess();
            var lista = sp.ToList();

            return View(lista);
        }

        [Route("Detalles_Sala", Name = "SalaControllerRouteDetails")]
        // GET: Sala/Details/5
        public ActionResult Details(int id)
        {
            SalaProcess sp = new SalaProcess();
            var lista = sp.ObtenerUno(id);

            return View(lista);
        }

        [Route("Crear_Sala", Name = "SalaControllerRouteCreateGet")]
        // GET: Sala/Create
        public ActionResult Create()
        {
            return View();
        }
        [Route("Crear_Sala", Name = "SalaControllerRouteCreatePost")]
        // POST: Sala/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                SalaProcess sp = new SalaProcess();
                SalaRequest salaRequest = new SalaRequest();
                salaRequest.tipoMovimiento.Nombre= collection.Get("Nombre");
                salaRequest.tipoMovimiento.TipoSala = collection.Get("TipoSala");
                sp.Agregar(salaRequest);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Route("Editar_Sala", Name = "SalaControllerRouteEditGet")]
        // GET: Sala/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }
        [Route("Editar_Sala", Name = "SalaControllerRouteEditPost")]
        // POST: Sala/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                SalaProcess sp = new SalaProcess();
                SalaRequest salaRequest = new SalaRequest();
                salaRequest.tipoMovimiento.Id = int.Parse(collection.Get("Id"));
                salaRequest.tipoMovimiento.Nombre = collection.Get("Nombre");
                salaRequest.tipoMovimiento.TipoSala = collection.Get("TipoSala");
                sp.Actualizar(salaRequest);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [Route("Eliminar_Sala", Name = "SalaControllerRouteDeleteGet")]
        // GET: Sala/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }
        [Route("Eliminar_Sala", Name = "SalaControllerRouteDeletePost")]
        // POST: Sala/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                SalaProcess sp = new SalaProcess();
                sp.Eliminar(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
