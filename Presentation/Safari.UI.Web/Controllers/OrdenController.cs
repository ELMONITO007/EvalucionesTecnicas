using Safari.Services.Contracts;
using Safari.Services.Contracts.Request;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Safari.UI.Process;
using System.Net.Http.Headers;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

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
            PreguntaProcess preguntaProcess = new PreguntaProcess();
            var Preguntas = preguntaProcess.ToList().Select(x =>
                                 new
                                 {
                                     Id = x.Id,
                                     LaPregunta = x.LaPregunta

                                 });

            CategoriaProcess categoriaProcess = new CategoriaProcess();
            var categoria=categoriaProcess.ToList().Select(x =>
                                 new
                                 {
                                     Id = x.Id,
                                     LaCategoria = x.LaCategoria

                                 });

            ViewBag.preguntaLista = new SelectList(Preguntas, "Id", "LaPregunta");
            ViewBag.categoriaLista = new SelectList(categoria, "Id", "LaCategoria");



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
                request.Objeto.LaRespuesta= collection.Get("LaRespuesta");
                request.Objeto.NumeroOrden=int.Parse(collection.Get("NumeroOrden"));
                request.Objeto.pregunta.Id= int.Parse(collection.Get("pregunta.Id"));
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
            PreguntaProcess preguntaProcess = new PreguntaProcess();
            var Preguntas = preguntaProcess.ToList().Select(x =>
                                   new {
                                       Id = x.Id,
                                       Pregunta = x.LaPregunta
                                   });
            ViewBag.Pregunta = new SelectList(Preguntas, "Id", "Pregunta");
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
                request.Objeto.pregunta.Id = int.Parse(collection.Get("Id"));

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
            PreguntaProcess preguntaProcess = new PreguntaProcess();
            var Preguntas = preguntaProcess.ToList().Select(x =>
                                   new {
                                       Id = x.Id,
                                       Pregunta = x.LaPregunta
                                   });
            ViewBag.Pregunta = new SelectList(Preguntas, "Id", "Pregunta");
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
