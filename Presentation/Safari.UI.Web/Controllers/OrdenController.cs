using Safari.Services.Contracts;
using Safari.Services.Contracts.Request;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Safari.UI.Process;
using System.Net.Http.Headers;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Safari.UI.Web.Models;
using Safari.Entities;

namespace Safari.UI.Web.Controllers
{
    [Authorize(Roles = "Administrador")]//para entrar en admin debe estar logueado y  asignarle el rol
    public class OrdenController : Controller
    {
        [Route("Orden", Name = "OrdenControllerRouteIndex")]
        // GET: Orden
        public ActionResult Index(String pregunta,string categoria)
        {
            #region Categorias

           
            CategoriaProcess categoriaProcess = new CategoriaProcess();
            var listaCategoria = categoriaProcess.ToList();
            listaCategoria.Select(y =>
                                new
                                {
                                    Id = y.Id,
                                    LaCategoria=y.LaCategoria
                                }) ;
            ViewBag.categoriaLista = new SelectList(listaCategoria, "LaCategoria", "LaCategoria");

            #endregion


            #region Preguntas
            //Obtengo las Preguntas


            PreguntaProcess preguntaProcess = new PreguntaProcess();

            var listaPreguntaParaFiltrar = preguntaProcess.LeerPorTipoDePregunta(2);
            if (!String.IsNullOrEmpty(categoria))
            {
                List<Pregunta> FiltroPregunta = new List<Pregunta>();
                foreach (var item3 in listaPreguntaParaFiltrar)
                {
                  
                    if (item3.categoria.LaCategoria==categoria)
                    {
                        FiltroPregunta.Add(item3);
                    }

                }

                FiltroPregunta.Select(x =>
                                 new
                                 {
                                     Id = x.Id,
                                     LaPregunta = x.LaPregunta

                                 });
                ViewBag.preguntaLista = new SelectList(FiltroPregunta, "LaPregunta", "LaPregunta");
            }
            else
            {
                var preguntas = preguntaProcess.LeerPorTipoDePregunta(2).Select(x =>
                                 new
                                 {
                                     Id = x.Id,
                                     LaPregunta = x.LaPregunta

                                 });
                ViewBag.preguntaLista = new SelectList(preguntas, "LaPregunta", "LaPregunta");
            }
            
           
            #endregion



            #region Preguntas por Orden y filtro
            //Obtengo Respuesta con o sin Filtro
            OrdenProcess ordenProcess = new OrdenProcess();
           
            var lista = ordenProcess.ToList();
            
            
            if (!String.IsNullOrEmpty(pregunta))
            {
                List<Orden> listaFiltrado = new List<Orden>();
                foreach (Orden item in lista)
                {
                    if (item.pregunta.LaPregunta==pregunta)
                    {
                        listaFiltrado.Add(item);

                    }
                   
                }
                return View(listaFiltrado.ToList());
            }
            else
            {
                return View(lista);
            }

            #endregion



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

            var Preguntas = preguntaProcess.LeerPorTipoDePregunta(2).Select(x =>
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
        //Get Error Al crear

            [HttpGet]
            public ActionResult ErrorOrden()
        {

            return View();
        }

        public bool verificarNumeroOrden(int pregunta,int orden)
        {
            OrdenProcess ordenProcess2 = new OrdenProcess();
            OrdenResponse ordenResponse = new OrdenResponse();
            ordenResponse.OrdenDiponible = ordenProcess2.OrdenDiponible(pregunta);
            int aux = 0;
            foreach (int item in ordenResponse.OrdenDiponible)
            {
                if (item == orden)
                {
                    aux = 1;
                }
            }


            if (aux==1)
            {
                return false;
            }
            else
            {
                return true;
            }


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
                //obtener orden disponible

             
                    ordenProcess.Agregar(request);
                    return RedirectToAction("Index");
           


                // TODO: Add insert logic here


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
                request.Objeto.LaRespuesta = collection.Get("LaRespuesta");
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
                request.Objeto.Id =id;
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
