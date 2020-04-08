using Safari.Services.Contracts;
using Safari.Services.Contracts.Request;
using Safari.UI.Process;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Safari.UI.Web.Controllers
{
    [Authorize]
    public class CitaController : Controller
    {
      
        
            // GET: Cita
            [Route("cita", Name = "CitaControllerRouteIndex")]
           
            public ActionResult Index()
            {
                CitaProcess pp = new CitaProcess();
                return View(pp.ToList());
            }

        // GET: Cita/Details/5
        [Route("Detalles_Cita", Name = "CitaControllerRouteDetails")]
        public ActionResult Details(int id)
            {
                CitaProcess ep = new CitaProcess();
                return View(ep.ObtenerUno(id));
            }

        [Route("Crear_Cita", Name = "CitaControllerRouteCreateGet")]
        // GET: Cita/Create
        public ActionResult Create()
            {
                MedicoProcess mp = new MedicoProcess();
                var medicos = mp.ToList().Select(x =>
                                 new {
                                     Id = x.Id,
                                     Nombre = x.Apellido + ", " + x.Nombre + " (" + x.Especialidad + ")"
                                 });
                ViewBag.Medicos = new SelectList(medicos, "Id", "Nombre");

                PacienteProcess pp = new PacienteProcess();
                var pacientes = pp.ToList()
                         .Select(x =>
                                 new {
                                     Id = x.Id,
                                     Nombre = x.nombre
                                 });
                ViewBag.Pacientes = new SelectList(pacientes, "Id", "Nombre");

                SalaProcess sp = new SalaProcess();
                var salas = sp.ToList()
                         .Select(x =>
                                 new {
                                     Id = x.Id,
                                     Nombre = x.Nombre
                                 });
                ViewBag.Salas = new SelectList(salas, "Id", "Nombre");

                TipoServicioProcess tsp = new TipoServicioProcess();
                var tiposServicio = tsp.ToList()
                         .Select(x =>
                                 new {
                                     Id = x.Id,
                                     Nombre = x.Nombre
                                 });
                ViewBag.TiposServicio = new SelectList(tiposServicio, "Id", "Nombre");



                return View();
            }

        [Route("Crear_Cita", Name = "CitaControllerRouteCreatePost")]
        // POST: Cita/Create
        [HttpPost]
            public ActionResult Create(FormCollection collection)
            {
                try
                {
                    CitaProcess pp = new CitaProcess();
                    CitaRequest cita = new CitaRequest();
                   cita.cita.fecha = Convert.ToDateTime(collection.Get("fecha"));
                   cita.cita.medico = Convert.ToInt32(collection.Get("medico"));
                   cita.cita.Paciente = Convert.ToInt32(collection.Get("Paciente"));
                   cita.cita.sala = Convert.ToInt32(collection.Get("sala"));
                   cita.cita.tipoServicio = Convert.ToInt32(collection.Get("tipoServicio"));
                   cita.cita.estado = collection.Get("Estado");
                   cita.cita.createDate = DateTime.Now;
                  cita.cita.createBy = 1;
                    pp.Agregar(cita);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }

        [Route("Editar_Cita", Name = "CitaControllerRouteEditGet")]
        // GET: Cita/Edit/5
        public ActionResult Edit(int id)
            {
                MedicoProcess mp = new MedicoProcess();
                var medicos = mp.ToList().Select(x =>
                                 new {
                                     Id = x.Id,
                                     Nombre = x.Apellido + ", " + x.Nombre + " (" + x.Especialidad + ")"
                                 });
                ViewBag.Medicos = new SelectList(medicos, "Id", "Nombre");

                PacienteProcess pp = new PacienteProcess();
                var pacientes = pp.ToList()
                         .Select(x =>
                                 new {
                                     Id = x.Id,
                                     Nombre = x.nombre
                                 });
                ViewBag.Pacientes = new SelectList(pacientes, "Id", "Nombre");

                SalaProcess sp = new SalaProcess();
                var salas = sp.ToList()
                         .Select(x =>
                                 new {
                                     Id = x.Id,
                                     Nombre = x.Nombre
                                 });
                ViewBag.Salas = new SelectList(salas, "Id", "Nombre");

                TipoServicioProcess tsp = new TipoServicioProcess();
                var tiposServicio = tsp.ToList()
                         .Select(x =>
                                 new {
                                     Id = x.Id,
                                     Nombre = x.Nombre
                                 });
                ViewBag.TiposServicio = new SelectList(tiposServicio, "Id", "Nombre");


                CitaProcess cp = new CitaProcess();
                return View(cp.ObtenerUno(id));
            }

        [Route("Editar_Cita", Name = "CitaControllerRouteEditPost")]
        // POST: Cita/Edit/5
        [HttpPost]
            public ActionResult Edit(int id, FormCollection collection)
            {
            try
            {
                CitaProcess pp = new CitaProcess();
                CitaRequest cita = new CitaRequest();
                cita.cita.Id = Convert.ToInt32(collection.Get("Id"));
                cita.cita.fecha = Convert.ToDateTime(collection.Get("fecha"));
                cita.cita.medico = Convert.ToInt32(collection.Get("medico"));
                cita.cita.Paciente = Convert.ToInt32(collection.Get("Paciente"));
                cita.cita.sala = Convert.ToInt32(collection.Get("sala"));
                cita.cita.tipoServicio = Convert.ToInt32(collection.Get("tipoServicio"));
                cita.cita.estado = collection.Get("Estado");
                cita.cita.changeDate = DateTime.Now;
                cita.cita.changeBy = 1;
                pp.Actualizar(cita);
                return RedirectToAction("Index");
            }
                
                
                catch
                {
                    return View();
                }
            }
        [Route("ELiminar_Cita", Name = "CitaControllerDeleteGet")]
        // GET: Cita/Delete/5
        public ActionResult Delete(int id)
            {
                CitaProcess ep = new CitaProcess();
                return View(ep.ObtenerUno(id));
            }
        [Route("ELiminar_Cita", Name = "CitaControllerDeletePost")]
        // POST: Cita/Delete/5
        [HttpPost]
            public ActionResult Delete(int id, FormCollection collection)
            {
                try
                {
                    CitaProcess ep = new CitaProcess();
                    ep.Eliminar(id);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
        }
    }
