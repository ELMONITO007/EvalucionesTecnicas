using Safari.Services.Contracts;
using Safari.Services.Contracts.Request;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Safari.UI.Process;
using System.Net.Http.Headers;

namespace Safari.UI.Web.Controllers
{
    [Authorize(Roles = "Administrador")]//para entrar en admin debe estar logueado y  asignarle el rol
    public class OrdenController : Controller
    {
        [Route("Orden", Name = "OrdenControllerRouteIndex")]
        // GET: Orden
        public ActionResult Index()
        {
            OrdenProcess ordenProcess = new OrdenProcess();
            var lista = ordenProcess.ToList();
            return View(lista);
        }

        // GET: Orden/Details/5
        public ActionResult Details(int id)
        {
            OrdenProcess ordenProcess = new OrdenProcess();
            var lista = ordenProcess.ObtenerUno(id);
            return View(lista);
        }

        // GET: Orden/Create
        public ActionResult Create()
        {
           
            
            return View();
        }

        // POST: Orden/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                OrdenProcess ordenProcess = new OrdenProcess();
                RequestOrden request = new RequestOrden();
                request.Objeto.LaRespuesta= collection.Get("TipoDePregunta");
                request.Objeto.NumeroOrden=int.Parse(collection.Get("NumeroOrden"));
                request.Objeto.pregunta.Id= int.Parse(collection.Get("ID_Pregunta"));
                ordenProcess.Agregar(request);
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Orden/Edit/5
        public ActionResult Edit(int id)
        {
            OrdenProcess ordenProcess = new OrdenProcess();

            return View(ordenProcess.ObtenerUno(id));
        }

        // POST: Orden/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                OrdenProcess ordenProcess = new OrdenProcess();
                RequestOrden request = new RequestOrden();
                request.Objeto.Id = int.Parse(collection.Get("Id"));
                request.Objeto.LaRespuesta = collection.Get("TipoDePregunta");
                request.Objeto.NumeroOrden = int.Parse(collection.Get("NumeroOrden"));
                request.Objeto.pregunta.Id = int.Parse(collection.Get("ID_Pregunta"));
                ordenProcess.Actualizar(request);

                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Orden/Delete/5
        public ActionResult Delete(int id)
        {
            OrdenProcess ordenProcess = new OrdenProcess();

            return View(ordenProcess.ObtenerUno(id));
        }

        // POST: Orden/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                OrdenProcess ordenProcess = new OrdenProcess();
                RequestOrden request = new RequestOrden();
                request.Objeto.Id = int.Parse(collection.Get("Id"));
                ordenProcess.Eliminar(request);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
