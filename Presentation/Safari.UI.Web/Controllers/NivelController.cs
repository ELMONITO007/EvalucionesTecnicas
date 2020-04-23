using Safari.Services.Contracts;
using Safari.Services.Contracts.Request;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Safari.UI.Process;


namespace Safari.UI.Web.Controllers
{
    [Authorize(Roles = "Administrador")]//para entrar en admin debe estar logueado y  asignarle el rol
    public class NivelController : Controller
    {
        [Route("Nivel", Name = "NivelControllerRouteIndex")]
        // GET: Nivel
        public ActionResult Index()
        {

            NivelProcess nivel = new NivelProcess();
            var lista = nivel.ToList();
            return View(lista);

        }
       
        // GET: Nivel/Details/5
        public ActionResult Details(int id)
        {
            NivelProcess nivel = new NivelProcess();
            var lista = nivel.ObtenerUno(id);
            return View(lista);
        }
      
        // GET: Nivel/Create
        public ActionResult Create()
        {
            return View();
        }
      
        // POST: Nivel/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                NivelProcess nivel = new NivelProcess();
                NivelRequest nivelResquest = new NivelRequest();
                nivelResquest.Objeto.ElNivel = collection.Get("ElNivel");
                nivel.Agregar(nivelResquest);




                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Nivel/Edit/5
        public ActionResult Edit(int id)
        {
            NivelProcess nivel = new NivelProcess();
            var lista = nivel.ObtenerUno(id);
            return View(lista);
        }

        // POST: Nivel/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                NivelProcess nivel = new NivelProcess();
                NivelRequest nivelResquest = new NivelRequest();
                nivelResquest.Objeto.Id =int.Parse( collection.Get("Id"));
                nivelResquest.Objeto.ElNivel = collection.Get("ElNivel");
                nivel.Actualizar(nivelResquest);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Nivel/Delete/5
        public ActionResult Delete(int id)
        {
            NivelProcess nivel = new NivelProcess();
            var lista = nivel.ObtenerUno(id);
            return View(lista);
        }

        // POST: Nivel/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                NivelProcess nivel = new NivelProcess();
                nivel.Eliminar(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                return View(ex.Message);
            }
        }
    }
}
