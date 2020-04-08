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
    public class CitaProcess : ProcessComponent, IProcess<Cita, CitaRequest>
    {
        public void Actualizar(CitaRequest request)
        {
            var response = HttpPost("api/Cita/Actualizar", request, MediaType.Json);
        }

        public void Agregar(CitaRequest request)
        {
            var response = HttpPost("api/Cita/Agregar", request, MediaType.Json);
        }

        public void Eliminar(int id)
        {
            var response = HttpPost("api/Cita/Eliminar", id, MediaType.Json);
        }

        public Cita ObtenerUno(int id)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("id", id);
            var response = HttpGet<CitaResponse>("api/Cita/ObtenerUno", parameters, MediaType.Json);
            return response.obtenerUno;
        }

        public IList<Cita> ToList()
        {
            var response = HttpGet<CitaResponse>("api/Cita/ListarTodos", new Dictionary<string, object>(), MediaType.Json);
            return response.obtenerTodos;
        }
    }
}
