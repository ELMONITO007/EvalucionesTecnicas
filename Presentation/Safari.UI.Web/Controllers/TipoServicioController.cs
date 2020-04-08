
using Safari.Services.Contracts;
using Safari.Services.Contracts.Request;
using Safari.UI.Process;
using System;
using System.Web.Mvc;

namespace Safari.UI.Web.Controllers
{
    public class TipoServicioController : Controller
    {

        [Route("TipoServicio", Name = "TipoServicioControllerRouteIndex")]
        // GET: TipoServicio
        public ActionResult Index()
        {
            TipoServicioProcess ep = new TipoServicioProcess();
            var lista = ep.ToList();
            return View(lista);
        }


        [Route("Detalle_TipoServicio", Name = "TipoServicioControllerRouteDetails")]
        // GET: TipoServicio/Details/5
        public ActionResult Details(int id)
        {
            TipoServicioProcess ep = new TipoServicioProcess();
            var lista = ep.ObtenerUno(id);
            return View(lista);
        }

        [Route("Crear_TipoServicio", Name = "TipoServicioControllerRouteCreateGet")]
        // GET: TipoServicio/Create
        public ActionResult Create()
        {
            return View();
        }
        [Route("Crear_TipoServicio", Name = "TipoServicioControllerRouteCreatePost")]
        // POST: TipoServicio/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                TipoServicioProcess ep = new TipoServicioProcess();
                TipoDeServicioRequest tipoDeServicioRequest = new TipoDeServicioRequest();

                tipoDeServicioRequest.tipoServicio.Nombre = collection.Get("Nombre");
                ep.Agregar(tipoDeServicioRequest);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Route("Editar_TipoServicio", Name = "TipoServicioControllerRouteEditGet")]
        // GET: TipoServicio/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        [Route("Editar_TipoServicio", Name = "TipoServicioControllerRouteEditPost")]
        // POST: TipoServicio/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                TipoServicioProcess ep = new TipoServicioProcess();
                TipoDeServicioRequest tipoDeServicioRequest = new TipoDeServicioRequest();

                tipoDeServicioRequest.tipoServicio.Nombre = collection.Get("Nombre");
                tipoDeServicioRequest.tipoServicio.Id =int.Parse( collection.Get("Id"));
                ep.Actualizar(tipoDeServicioRequest);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [Route("Eliminar_TipoServicio", Name = "TipoServicioControllerRouteDeleteGet")]

        // GET: TipoServicio/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }


        [Route("Eliminar_TipoServicio", Name = "TipoServicioControllerRouteDeletePost")]
        // POST: TipoServicio/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                TipoServicioProcess ep = new TipoServicioProcess();
                ep.Eliminar(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
