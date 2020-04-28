using Safari.Services.Contracts;
using Safari.Services.Contracts.Request;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Safari.UI.Process;


namespace Safari.UI.Web.Controllers
{
    [Authorize(Roles = "Administrador")]//para entrar en admin debe estar logueado y  asignarle el rol
    public class CategoriaController : Controller
    {
        [Route("CategoriaPregunta", Name = "CategoriaPreguntaControllerRouteIndex")]
        // GET: Categoria
        public ActionResult Index()
        {
            CategoriaProcess categoriaProcess = new CategoriaProcess();
            var lista = categoriaProcess.ToList();
            return View(lista);
        }

        // GET: Categoria/Details/5
        public ActionResult Details(int id)
        {
            CategoriaProcess categoriaProcess = new CategoriaProcess();
            var lista = categoriaProcess.ObtenerUno(id);
            return View(lista);
        }

        // GET: Categoria/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categoria/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {

                // TODO: Add insert logic here
                CategoriaProcess categoriaProcess = new CategoriaProcess();
                CategoriaRequest categoriaRequest = new CategoriaRequest();
                categoriaRequest.Objeto.LaCategoria = collection.Get("LaCategoria");
                categoriaRequest.Objeto.Descripcion = collection.Get("Descripcion");
                categoriaProcess.Agregar(categoriaRequest);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Categoria/Edit/5
        public ActionResult Edit(int id)
        {
            CategoriaProcess categoriaProcess = new CategoriaProcess();
            var lista = categoriaProcess.ObtenerUno(id);
            return View(lista);
        }

        // POST: Categoria/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                CategoriaProcess categoriaProcess = new CategoriaProcess();
                CategoriaRequest categoriaRequest = new CategoriaRequest();
                categoriaRequest.Objeto.LaCategoria = collection.Get("LaCategoria");
                categoriaRequest.Objeto.Descripcion = collection.Get("Descripcion");
                categoriaRequest.Objeto.Id = int.Parse(collection.Get("Id"));
                categoriaProcess.Actualizar(categoriaRequest);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Categoria/Delete/5
        public ActionResult Delete(int id)
        {
            CategoriaProcess categoriaProcess = new CategoriaProcess();
            var lista = categoriaProcess.ObtenerUno(id);
            return View(lista);
        }

        // POST: Categoria/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                CategoriaProcess categoriaProcess = new CategoriaProcess();
                CategoriaRequest categoriaRequest = new CategoriaRequest();
          
                categoriaRequest.Objeto.Id = int.Parse(collection.Get("Id"));
                categoriaProcess.Eliminar(categoriaRequest);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
