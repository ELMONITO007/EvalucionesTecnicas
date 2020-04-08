using Safari.Services.Contracts;
using Safari.Services.Contracts.Request;
using Safari.UI.Process;
using System;
using System.Web.Mvc;


namespace Safari.UI.Web.Controllers
{
    [Authorize]
    public class MedicoController : Controller
    {
        // GET: Medico
        [Route("Medico", Name = "MedicoControllerRouteIndex")]
        public ActionResult Index()
        {
            MedicoProcess mc = new MedicoProcess();
            var lista = mc.ToList();
            return View(lista);
        }

        // GET: Medico/Details/5
        [Route("Detalle_Medico", Name = "MedicoControllerRouteDetails")]
        public ActionResult Details(int id)
        {
            MedicoProcess mc = new MedicoProcess();
            var lista = mc.ObtenerUno(id);
            return View(lista);
        }

        // GET: Medico/Create
        [Route("Crear_Medico", Name = "MedicoControllerRouteCreateGet")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Medico/Create
        [Route("Crear_Medico", Name = "MedicoControllerRouteCreatePost")]
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                MedicoRequest medicoRequest = new MedicoRequest();
                MedicoProcess medicoProcess = new MedicoProcess();

               medicoRequest.medico.Nombre = collection.Get("Nombre");
               medicoRequest.medico.Apellido = collection.Get("Apellido");
               medicoRequest.medico.Email = collection.Get("Email");
               medicoRequest.medico.Especialidad = collection.Get("Especialidad");
               medicoRequest.medico.FechaNacimiento =DateTime.Parse( collection.Get("FechaNacimiento"));
               medicoRequest.medico.NumeroMatricula=int.Parse(collection.Get("NumeroMatricula"));
               medicoRequest.medico.Telefono=collection.Get("Telefono");
               medicoRequest.medico.TipoMatricula= collection.Get("TipoMatricula");

                medicoProcess.Agregar(medicoRequest);

               
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return View();
            }
        }

        // GET: Medico/Edit/5
        [Route("Editar_Medico", Name = "MedicoControllerRouteEditGet")]
        public ActionResult Edit(int id)
        {
          
            return View();
        }

        // POST: Medico/Edit/5
        [Route("Editar_Medico", Name = "MedicoControllerRouteEditPost")]
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
            
            
                
                MedicoRequest medicoRequest = new MedicoRequest();
                MedicoProcess medicoProcess = new MedicoProcess();

                medicoRequest.medico.Id = id;
                medicoRequest.medico.Nombre = collection.Get("Nombre");
                medicoRequest.medico.Apellido = collection.Get("Apellido");
                medicoRequest.medico.Email = collection.Get("Email");
                medicoRequest.medico.Especialidad = collection.Get("Especialidad");
                medicoRequest.medico.FechaNacimiento = DateTime.Parse(collection.Get("FechaNacimiento"));
                medicoRequest.medico.NumeroMatricula = int.Parse(collection.Get("NumeroMatricula"));
                medicoRequest.medico.Telefono = collection.Get("Telefono");
                medicoRequest.medico.TipoMatricula = collection.Get("TipoMatricula");
                medicoProcess.Actualizar(medicoRequest);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }
        }

        // GET: Medico/Delete/5
        [Route("Eliminar_Medico", Name = "MedicoControllerRouteDeleteGet")]
        public ActionResult Delete(int id)
        {
            
            return View();
        }

        // POST: Medico/Delete/5
        [Route("Eliminar_Medico", Name = "MedicoControllerRouteDeletePost")]
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                
                MedicoProcess medicoProcess = new MedicoProcess();
                medicoProcess.Eliminar(id);
                return RedirectToAction("Index");
              
            }
            catch
            {
                return View();
            }
        }
    }
}
