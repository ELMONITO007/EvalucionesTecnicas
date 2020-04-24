using Safari.Services.Contracts;
using Safari.Services.Contracts.Request;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Safari.UI.Process;

namespace Safari.UI.Web.Controllers
{
    [Authorize(Roles = "Administrador")]//para entrar en admin debe estar logueado y  asignarle el rol
    public class TipoPreguntaController : Controller
    {
       
        // GET: TipoPregunta
        [Route("TipoPregunta", Name = "TipoPreguntaControllerRouteIndex")]
        public ActionResult Index()
        {
            TipoPreguntaProcess tipoPreguntaProcess = new TipoPreguntaProcess();
            var lista = tipoPreguntaProcess.ToList();
            return View(lista);
        }

        // GET: TipoPregunta/Details/5
        public ActionResult Details(int id)
        {
            TipoPreguntaProcess tipoPreguntaProcess = new TipoPreguntaProcess();
            var lista = tipoPreguntaProcess.ObtenerUno(id);
            return View(lista);
        }

        // GET: TipoPregunta/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoPregunta/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                TipoPreguntaProcess tipoPreguntaProcess = new TipoPreguntaProcess();
                TipoPreguntaRequest tipoPreguntaRequest = new TipoPreguntaRequest();
                tipoPreguntaRequest.Objeto.TipoDePregunta = collection.Get("TipoDePregunta");
                tipoPreguntaProcess.Agregar(tipoPreguntaRequest);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TipoPregunta/Edit/5
        public ActionResult Edit(int id)
        {
            TipoPreguntaProcess tipoPreguntaProcess = new TipoPreguntaProcess();
            var lista = tipoPreguntaProcess.ObtenerUno(id);
            return View(lista);
            
        }

        // POST: TipoPregunta/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                TipoPreguntaProcess tipoPreguntaProcess = new TipoPreguntaProcess();
                TipoPreguntaRequest tipoPreguntaRequest = new TipoPreguntaRequest();
                tipoPreguntaRequest.Objeto.TipoDePregunta = collection.Get("TipoDePregunta");
                tipoPreguntaRequest.Objeto.Id = int.Parse(collection.Get("Id"));
                tipoPreguntaProcess.Actualizar(tipoPreguntaRequest);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TipoPregunta/Delete/5
        public ActionResult Delete(int id)
        {
            TipoPreguntaProcess tipoPreguntaProcess = new TipoPreguntaProcess();
            var lista = tipoPreguntaProcess.ObtenerUno(id);
            return View(lista);
        }

        // POST: TipoPregunta/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                TipoPreguntaProcess tipoPreguntaProcess = new TipoPreguntaProcess();
                TipoPreguntaRequest tipoPreguntaRequest = new TipoPreguntaRequest();
                tipoPreguntaRequest.Objeto.Id = id;
               tipoPreguntaProcess.Eliminar(tipoPreguntaRequest);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
