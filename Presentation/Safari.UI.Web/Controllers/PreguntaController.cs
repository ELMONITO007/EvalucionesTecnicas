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
using System.Web;
using GoogleMapsApi.StaticMaps.Entities;
using System.IO;

namespace Safari.UI.Web.Controllers
{
    [Authorize(Roles = "Administrador")]//para entrar en admin debe estar logueado y  asignarle el rol
    public class PreguntaController : Controller
    {
        [Route("Pregunta", Name = "PreguntaControllerRouteIndex")]
        // GET: Pregunta
        public ActionResult Index(string categoria)
        {
            #region Categoria
            CategoriaProcess categoriaProcess = new CategoriaProcess();
            var listaCategoria = categoriaProcess.ToList();
            listaCategoria.Select(y =>
                                new
                                {
                                    Id = y.Id,
                                    LaCategoria = y.LaCategoria
                                });
            ViewBag.categoriaLista = new SelectList(listaCategoria, "LaCategoria", "LaCategoria");

            #endregion

            #region PReguntas
            PreguntaProcess preguntaProcess = new PreguntaProcess();
            var listaPreguntas = preguntaProcess.ToList();
            if (!string.IsNullOrEmpty(categoria))
            {
                List<Pregunta> listaPreguntasFiltrada = new List<Pregunta>();
                foreach (var item in listaPreguntas)
                {
                    if (item.categoria.LaCategoria == categoria)
                    {
                        listaPreguntasFiltrada.Add(item);
                    }
                }
                return View(listaPreguntasFiltrada);
            }
            else
            {
                return View(listaPreguntas);
            }
            #endregion

        }

        // GET: Pregunta/Details/5
        public ActionResult Details(int id)
        {
            PreguntaProcess preguntaProcess = new PreguntaProcess();


            return View(preguntaProcess.ObtenerUno(id));
        }
        [HttpPost]
        public ActionResult Details(HttpPostedFileBase file)
        {

            if (file != null)
            {
                string ruta = Server.MapPath("~/ImagenesPregunta/");
                ruta += file.FileName;
                file.SaveAs(ruta);
            }
            return View();
        }
        // GET: Pregunta/Create
        public ActionResult Create()
        {
            #region Categoria
            CategoriaProcess categoriaProcess = new CategoriaProcess();
            var listaCategoria = categoriaProcess.ToList();
            listaCategoria.Select(y =>
                                new
                                {
                                    Id = y.Id,
                                    LaCategoria = y.LaCategoria
                                });
            ViewBag.categoriaLista = new SelectList(listaCategoria, "Id", "LaCategoria");

            #endregion
            #region Nivel
            NivelProcess nivelProcess = new NivelProcess();
            var listaNivel = nivelProcess.ToList();
            listaNivel.Select(y =>
                                new
                                {
                                    Id = y.Id,
                                    ElNivel = y.ElNivel
                                });
            ViewBag.categoriaNivel = new SelectList(listaNivel, "Id", "ElNivel");
            #endregion
            #region TipoPregunta
            TipoPreguntaProcess tipoPreguntaProcess = new TipoPreguntaProcess();
            var listaTipoPregunta = tipoPreguntaProcess.ToList();
            listaTipoPregunta.Select(y =>
                                new
                                {
                                    Id = y.Id,
                                    TipoDePregunta = y.TipoDePregunta
                                });
            ViewBag.categoriaTipoPregunta = new SelectList(listaTipoPregunta, "Id", "TipoDePregunta");
            #endregion
            return View();
        }

        // POST: Pregunta/Create
        [HttpPost]
        public ActionResult Create(HttpPostedFileBase file, string LaPregunta, string Categoria, string TipoPregunta, string Nivel)
        {

            ; try
            {
                string ruta = "";
                if (file != null)
                {

                    ruta = @"C:\Imagenes\";
                    ruta += file.FileName;
                    file.SaveAs(ruta);
                }

                PreguntaProcess preguntaProcess = new PreguntaProcess();
                PreguntaRequest preguntaRequest = new PreguntaRequest();
                preguntaRequest.Objeto.Imagen = ruta;

                preguntaRequest.Objeto.categoria.Id = int.Parse(Categoria);
                preguntaRequest.Objeto.LaPregunta = LaPregunta;
                preguntaRequest.Objeto.tipoPregunta.Id = int.Parse(TipoPregunta);
                preguntaRequest.Objeto.nivel.Id = int.Parse(Nivel);
                preguntaProcess.Agregar(preguntaRequest);


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pregunta/Edit/5
        public ActionResult Edit(int id)
        {
            #region Categoria
            CategoriaProcess categoriaProcess = new CategoriaProcess();
            var listaCategoria = categoriaProcess.ToList();
            listaCategoria.Select(y =>
                                new
                                {
                                    Id = y.Id,
                                    LaCategoria = y.LaCategoria
                                });
            ViewBag.categoriaLista = new SelectList(listaCategoria, "Id", "LaCategoria");

            #endregion
            #region Nivel
            NivelProcess nivelProcess = new NivelProcess();
            var listaNivel = nivelProcess.ToList();
            listaNivel.Select(y =>
                                new
                                {
                                    Id = y.Id,
                                    ElNivel = y.ElNivel
                                });
            ViewBag.categoriaNivel = new SelectList(listaNivel, "Id", "ElNivel");
            #endregion
            #region TipoPregunta
            TipoPreguntaProcess tipoPreguntaProcess = new TipoPreguntaProcess();
            var listaTipoPregunta = tipoPreguntaProcess.ToList();
            listaTipoPregunta.Select(y =>
                                new
                                {
                                    Id = y.Id,
                                    TipoDePregunta = y.TipoDePregunta
                                });
            ViewBag.categoriaTipoPregunta = new SelectList(listaTipoPregunta, "Id", "TipoDePregunta");
            #endregion
            PreguntaProcess preguntaProcess = new PreguntaProcess();
            return View(preguntaProcess.ObtenerUno(id));
        }

        // POST: Pregunta/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, HttpPostedFileBase file, string LaPregunta, string Categoria, string TipoPregunta, string Nivel)
        {
            try
            {

                PreguntaProcess preguntaProcess = new PreguntaProcess();
                PreguntaRequest preguntaRequest = new PreguntaRequest();

                preguntaProcess.Actualizar(preguntaRequest);
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pregunta/Delete/5
        public ActionResult Delete(int id)
        {
            PreguntaProcess preguntaProcess = new PreguntaProcess();
            return View(preguntaProcess.ObtenerUno(id));
        }

        // POST: Pregunta/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                PreguntaProcess preguntaProcess = new PreguntaProcess();
                PreguntaRequest preguntaRequest = new PreguntaRequest();
                preguntaRequest.Objeto.Id = id;
                preguntaProcess.Eliminar(preguntaRequest);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


    }
}
