using Safari.Entities;
using Safari.UI.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Safari.Services.Contracts;
using Safari.Services.Contracts.Request;
namespace Safari.UI.Web.Controllers
{
    [Authorize]
    public class MovimientoController : Controller
    {
        [Route("Movimiento", Name = "MovimientoControllerRouteIndex")]
        // GET: Movimiento
        public ActionResult Index()
        {
            MovimientoProcess ep = new MovimientoProcess();
            var lista = ep.ToList();
            return View(lista);
        }
        [Route("Detalle_Movimiento", Name = "MovimientoControllerRouteDetails")]
        // GET: Movimiento/Details/5
        public ActionResult Details(int id)
        {
            MovimientoProcess ep = new MovimientoProcess();
            var uno = ep.ObtenerUno(id);
            return View(uno);
        }
        [Route("Crear_Movimiento", Name = "MovimientoControllerRouteCreateGet")]
        // GET: Movimiento/Create
        public ActionResult Create()
        {
            /*Obtener Los clientes*/
            ClienteProcess cp = new ClienteProcess();
            var clientes = cp.ToList()
                     .Select(x =>
                             new
                             {
                                 Id = x.Id,
                                 Apellido = x.Apellido
                             }); ;
            ViewBag.Clientes = new SelectList(clientes, "Id", "Apellido");



            /*Obtener los Tipo de movimiento*/
            TipoMovimientoProcess tmp = new TipoMovimientoProcess();
            var tiposMovimiento = tmp.ToList()
                     .Select(x =>
                             new {
                                 Id = x.Id,
                                 Nombre = x.Nombre
                             });
            ViewBag.TiposMovimiento = new SelectList(tiposMovimiento, "Id", "Nombre");

            return View();
        }
        [Route("Crear_Movimiento", Name = "MovimientoControllerRouteCreatePost")]
        // POST: Movimiento/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                MovimientoProcess pp = new MovimientoProcess();
                MoviemientoRequest movimiento = new MoviemientoRequest();
                movimiento.movimiento.Fecha = Convert.ToDateTime(collection.Get("Fecha"));
                movimiento.movimiento.Cliente = Convert.ToInt32(collection.Get("Cliente"));
                movimiento.movimiento.tipoMovimiento = Convert.ToInt32(collection.Get("TipoMovimiento"));
                movimiento.movimiento.valor = Convert.ToInt32(collection.Get("valor"));
                pp.Agregar(movimiento);
                return RedirectToAction("Index"); 
            }
            catch
            {
                return View();
            }
        }
        [Route("Editar_Movimiento", Name = "MovimientoControllerRouteEditGet")]
        // GET: Movimiento/Edit/5
        public ActionResult Edit(int id)
        {
            return RedirectToAction("Index");
        }
        [Route("Editar_Movimiento", Name = "MovimientoControllerRouteEditPost")]
        // POST: Movimiento/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                MovimientoProcess pp = new MovimientoProcess();
                MoviemientoRequest movimiento = new MoviemientoRequest();
                movimiento.movimiento.Id= Convert.ToInt32(collection.Get("Id"));
                movimiento.movimiento.Fecha = Convert.ToDateTime(collection.Get("Fecha"));
                movimiento.movimiento.Cliente = Convert.ToInt32(collection.Get("Cliente"));
                movimiento.movimiento.tipoMovimiento = Convert.ToInt32(collection.Get("TipoMovimiento"));
                movimiento.movimiento.valor = Convert.ToInt32(collection.Get("valor"));
                pp.Agregar(movimiento);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [Route("Eliminar_Movimiento", Name = "MovimientoControllerRouteDeleteGet")]
        // GET: Movimiento/Delete/5
        public ActionResult Delete(int id)
        {
            MovimientoProcess ep = new MovimientoProcess();
            var lista = ep.ObtenerUno(id);
            return View(lista);
           
        }
        [Route("Eliminar_Movimiento", Name = "MovimientoControllerRouteDeletePost")]
        // POST: Movimiento/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                MovimientoProcess pp = new MovimientoProcess();
                pp.Eliminar(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
