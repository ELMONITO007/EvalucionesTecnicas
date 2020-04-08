using Safari.Services.Contracts;
using Safari.Services.Contracts.Request;
using Safari.UI.Process;
using System;
using System.Web.Mvc;

namespace Safari.UI.Web.Controllers
{
    [Authorize]
    public class ClienteController : Controller
    {

        // GET: Cliente
        [Route("Cliente", Name = "ClienteControllerRouteIndex")]
        public ActionResult Index()
        {

            ClienteProcess mc = new ClienteProcess();
            var lista = mc.ToList();
            return View(lista);
        }

        [Route("Detalle_Cliente", Name = "ClienteControllerRouteDetails")]
        // GET: Cliente/Details/5
        public ActionResult Details(int id)
        {
            ClienteProcess mc = new ClienteProcess();
            var lista = mc.ObtenerUno(id);
            return View(lista);
        }

        [Route("Crear_Cliente", Name = "ClienteControllerRouteCreateGet")]
        // GET: Cliente/Create
        public ActionResult Create()
        {
            EspeciesProcess ep = new EspeciesProcess();
            var lista = ep.ToList();
            return View();
        }

        [Route("Crear_Cliente", Name = "ClienteControllerRouteCreatePost")]
        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                ClienteProcess mc = new ClienteProcess();
                ClienteRequest clienteRequest = new ClienteRequest();
                clienteRequest.cliente.Nombre= collection.Get("Nombre");
                clienteRequest.cliente.Apellido = collection.Get("Apellido");
                clienteRequest.cliente.Email = collection.Get("Email");
                clienteRequest.cliente.Telefono = collection.Get("Telefono");
                clienteRequest.cliente.Url = collection.Get("Url");
                clienteRequest.cliente.FechaNacimiento =DateTime.Parse( collection.Get("FechaNacimiento"));
                clienteRequest.cliente.Domicilio = collection.Get("Domicilio");
              
                mc.Agregar(clienteRequest);


                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return View();
            }
        }

        [Route("Editar_Cliente", Name = "ClienteControllerRouteEditGet")]
        // GET: Cliente/Edit/5
        public ActionResult Edit(int id)
        {
            ClienteProcess cp = new ClienteProcess();
            var result = cp.ObtenerUno(id);
            return View();
        }

        [Route("Editar_Cliente", Name = "ClienteControllerRouteEditPost")]
        // POST: Cliente/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                ClienteProcess mc = new ClienteProcess();
                ClienteRequest clienteRequest = new ClienteRequest();
                clienteRequest.cliente.Nombre = collection.Get("Nombre");
                clienteRequest.cliente.Apellido = collection.Get("Apellido");
                clienteRequest.cliente.Email = collection.Get("Email");
                clienteRequest.cliente.Telefono = collection.Get("Telefono");
                clienteRequest.cliente.Url = collection.Get("Url");
                clienteRequest.cliente.FechaNacimiento = DateTime.Parse(collection.Get("Nombre"));
                clienteRequest.cliente.Domicilio = collection.Get("Domicilio");
                clienteRequest.cliente.Id = int.Parse(collection.Get("Id"));

                mc.Actualizar(clienteRequest);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Route("Eliminar_Cliente", Name = "ClienteControllerRouteDeleteGet")]
        // GET: Cliente/Delete/5
        public ActionResult Delete(int id)
        {
            ClienteProcess mc = new ClienteProcess();
            var lista = mc.ObtenerUno(id);
            return View(lista);
        }

        [Route("Eliminar_Cliente", Name = "ClienteControllerRouteDeletePost")]
        // POST: Cliente/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                ClienteProcess mc = new ClienteProcess();
                mc.Eliminar(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult ObtenerPacientes(int id)
        {
            try
            {
                PacienteProcess mc = new PacienteProcess();
               var lista= mc.ListarTodosDeCliente(id);

                return View(lista);
            }
            catch (Exception e)
            {
                return View();
            }
        }

    }
}
