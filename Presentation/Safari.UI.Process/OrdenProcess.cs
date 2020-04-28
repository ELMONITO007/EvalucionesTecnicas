using Safari.Entities;
using Safari.Services.Contracts;
using Safari.Services.Contracts.Request;
using Safari.Services.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Safari.UI.Process
{
   public class OrdenProcess : ProcessComponent, IProcess<Orden, RequestOrden>
    {
        public void Actualizar(RequestOrden request)
        {
            var response = HttpPost("api/Orden/Actualizar", request, MediaType.Json);
        }

        public void Agregar(RequestOrden request)
        {
            var response = HttpPost("api/Orden/Agregar", request, MediaType.Json);
        }
    

        public void Eliminar(RequestOrden request)
        {
            var response = HttpPost("api/Orden/Eliminar", request, MediaType.Json);
        }

        public Orden ObtenerUno(int id)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("id", id);
            var response = HttpGet<OrdenResponse>("api/Orden/ObtenerUno", parameters, MediaType.Json);
            return response.obtenerUno;
        }

        public IList<Orden> ToList()
        {
            var response = HttpGet<OrdenResponse>("api/Orden/ListarTodos", new Dictionary<string, object>(), MediaType.Json);
            return response.ObtenerTodo;
        }
        public IList<Orden> listaRespuestaOrdenAlAzar(int id)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("id", id);
            var response = HttpGet<OrdenResponse>("api/Orden/listaRespuestaOrdenAlAzar", parameters, MediaType.Json);
            return response.ObtenerTodo;
        }


    }
}
