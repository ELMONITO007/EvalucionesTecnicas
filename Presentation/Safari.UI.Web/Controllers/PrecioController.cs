using Safari.Entities;
using Safari.Services.Contracts.Request;
using Safari.UI.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Safari.UI.Web.Controllers
{
    [Authorize]
    public class PrecioController : Controller
    {
        
      [Route("Precio", Name = "PrecioControllerRouteIndex")]
        public ActionResult Index()
        {
            PrecioProcess ep = new PrecioProcess();
            
            var lista = ep.ToList();
            return View(lista);
        }

        [Route("Detalle_Precio", Name = "PrecioControllerRouteDetails")]
        // GET: Precio/Details/5
        public ActionResult Details(int id)
        {
            PrecioProcess ep = new PrecioProcess();

            var lista = ep.ObtenerUno(id);
            return View(lista);
        }

        [Route("Crear_Precio", Name = "PrecioControllerRouteCreateGet")]
        // GET: Precio/Create
        public ActionResult Create()
        {
            try
            {
                TipoServicioProcess ep = new TipoServicioProcess();
                ViewBag.TipoServicio = new SelectList(ep.ToList(), "Id", "Nombre");
                return View();
            }
            catch (Exception e)
            {

                throw;
            }
           
        }

        [Route("Crear_Precio", Name = "PrecioControllerRouteCreatePost")]
        // POST: Precio/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                PrecioProcess ep = new PrecioProcess();
                PrecioRequest precio = new PrecioRequest();
                precio.Precio.fechaDesde =DateTime.Parse( collection.Get("fechaDesde"));
                precio.Precio.fechaHasta = DateTime.Parse(collection.Get("fechaHasta"));
                precio.Precio.tipoServicioID = int.Parse(collection.Get("tipoServicioID"));
                precio.Precio.valor = int.Parse(collection.Get("valor"));
                
                ep.Agregar(precio);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }
        }
        [Route("Editar_Precio", Name = "PrecioControllerRouteEditGet")]
        // GET: Precio/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }
        [Route("Editar_Precio", Name = "PrecioControllerRouteEditPost")]
        // POST: Precio/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                PrecioProcess ep = new PrecioProcess();
                PrecioRequest precio = new PrecioRequest();
                precio.Precio.fechaDesde = DateTime.Parse(collection.Get("fechaDesde"));
                precio.Precio.fechaHasta = DateTime.Parse(collection.Get("fechaHasta"));
                precio.Precio.tipoServicioID = int.Parse(collection.Get("tipoServicioID"));
                precio.Precio.valor = int.Parse(collection.Get("valor"));
                precio.Precio.Id = int.Parse(collection.Get("Id"));

                ep.Agregar(precio);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Route("Eliminar_Precio", Name = "PrecioControllerRouteDeleteGet")]
        // GET: Precio/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        [Route("Eliminar_Precio", Name = "PrecioControllerRouteDeletePost")]
        [HttpPost]
        // POST: Precio/Delete/5
       
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                PrecioProcess ep = new PrecioProcess();
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
