
using Safari.Services.Contracts;
using Safari.Services.Contracts.Request;
using Safari.UI.Process;
using System;
using System.Web.Mvc;


namespace Safari.UI.Web.Controllers
{
    [Authorize]
    public class EspecieController : Controller

    {
        [Route("Especie", Name = "EspecieControllerRouteIndex")]
        public ActionResult Index()
        {
            EspeciesProcess ep = new EspeciesProcess();
            var lista = ep.ToList();
            return View(lista);
        }



        // GET: Especie/Details/5
        [Route("Detalles_Especie", Name = "EspecieControllerRouteDetails")]
        public ActionResult Details(int id)
        {
            EspeciesProcess ep = new EspeciesProcess();
            var lista = ep.ObtenerUno(id);
            return View(lista);
        }

        // GET: Especie/Create
        [Route("Crear_Especie", Name = "EspecieControllerRouteCreateGet")]
        public ActionResult Create()
        {
            return View();
        }
        [Route("Crear_Especie", Name = "EspecieControllerRouteCreatePost")]
        // POST: Especie/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                EspecieRequest especieResponse = new EspecieRequest();
                EspeciesProcess ep = new EspeciesProcess();
               
                especieResponse.especie.Nombre = collection.Get("Nombre");
              
                ep.Agregar(especieResponse);

                return RedirectToAction("index");
            }
                catch (Exception e)
            {
                return RedirectToAction("index");
                throw;
            }
        }

        // GET: Especie/Edit/5
        [Route("Editar_Especie", Name = "EspecieControllerRouteEditGet")]
        public ActionResult Edit(int id)
        {
            EspeciesProcess ep = new EspeciesProcess();
            return View();
        }
        [Route("Editar_Especie", Name = "EspecieControllerRoutePost")]
        // POST: Especie/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                EspecieRequest especieResponse = new EspecieRequest();
                EspeciesProcess ep = new EspeciesProcess();

                especieResponse.especie.Id = Convert.ToInt32(collection.Get("Id"));
                especieResponse.especie.Nombre = collection.Get("Nombre");
           
                ep.Actualizar(especieResponse);

                return RedirectToAction("index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Especie/Delete/5
        [Route("Eliminar_Especie", Name = "EspecieControllerRouteDeleteGet")]
        public ActionResult Delete(int id)
        {
            EspeciesProcess ep = new EspeciesProcess();
            return View();
        }
        [Route("Eliminar_Especie", Name = "EspecieControllerRouteDeletePost")]
        // POST: Especie/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                EspeciesProcess ep = new EspeciesProcess();
                ep.Eliminar(id);
               
                return RedirectToAction("index");
            }
            catch(Exception e)
            {
                return View();  
            }
        }
    }
}
