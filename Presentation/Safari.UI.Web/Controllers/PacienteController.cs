using Safari.Services.Contracts;
using Safari.Services.Contracts.Request;
using Safari.UI.Process;
using System;
using System.Linq;
using System.Web.Mvc;



namespace Safari.UI.Web.Controllers
{
    [Authorize]
    public class PacienteController : Controller
    {
        [Route("Paciente", Name = "PacienteControllerRouteIndex")]
        // GET: Paciente
        public ActionResult Index()
        {
            PacienteProcess pp = new PacienteProcess();
            var lista = pp.ToList();
            return View(lista);
        }
        [Route("ListarTodosDelCliente", Name = "ListarTodosDeClienteControllerRouteIndex")]
        // GET: Paciente
        public ActionResult ListarTodosDeCliente(int id)
        {
            PacienteProcess pp = new PacienteProcess();
            var lista = pp.ListarTodosDeCliente(id);
            return View(lista);
        }

        [Route("Detalle_Medico", Name = "PacienteControllerRouteDetails")]
        // GET: Paciente/Details/5
        public ActionResult Details(int id)
        {
            PacienteProcess pp = new PacienteProcess();
            var lista = pp.ObtenerUno(id);
            return View(lista);
        }


        [Route("Crear_Paciente", Name = "PacienteControllerRouteCreateGet")]
        // GET: Paciente/Create
        public ActionResult Create()
        {
            EspeciesProcess ep = new EspeciesProcess();
            ViewBag.Especies = new SelectList(ep.ToList(), "Id", "Nombre");
            ClienteProcess cp = new ClienteProcess();
            var lista = cp.ToList()
                     .Select(x =>
                             new {
                                 Id = x.Id,
                                 Nombre = x.Apellido + ", " + x.Nombre
                             });
            ViewBag.Clientes = new SelectList(lista, "Id", "Nombre");
            return View();
        }

        [Route("Crear_Paciente", Name = "PacienteControllerRouteCreatePost")]
        // POST: Paciente/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                PacienteProcess pp = new PacienteProcess();
                PacienteRequest paciente = new PacienteRequest();
                paciente.paciente.nombre = collection.Get("nombre");
                paciente.paciente.cliente = Convert.ToInt32(collection.Get("cliente"));
                paciente.paciente.Especie = Convert.ToInt32(collection.Get("Especie"));
                paciente.paciente.fechaNacimiento = Convert.ToDateTime(collection.Get("fechaNacimiento"));
                paciente.paciente.observacion = collection.Get("observacion");
                pp.Agregar(paciente);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Route("Editar_Paciente", Name = "PacienteControllerRouteEditGet")]
        // GET: Paciente/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }
        [Route("Editar_Paciente", Name = "PacienteControllerRouteEditPost")]
        // POST: Paciente/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                PacienteProcess pp = new PacienteProcess();
                PacienteRequest paciente = new PacienteRequest();
                paciente.paciente.Id = Convert.ToInt32(collection.Get("Id"));
                paciente.paciente.nombre = collection.Get("nombre");
                paciente.paciente.cliente = Convert.ToInt32(collection.Get("cliente"));
                paciente.paciente.Especie = Convert.ToInt32(collection.Get("Especie"));
                paciente.paciente.fechaNacimiento = Convert.ToDateTime(collection.Get("fechaNacimiento"));
                paciente.paciente.observacion = collection.Get("observacion");
                pp.Actualizar(paciente);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Route("Eliminar_Paciente", Name = "PacienteControllerRouteDeleteGet")]
        // GET: Paciente/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }


        [Route("Eliminar_Paciente", Name = "PacienteControllerRouteDeletePost")]

        // POST: Paciente/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                PacienteProcess pp = new PacienteProcess();
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
