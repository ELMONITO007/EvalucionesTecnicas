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
    public class NivelProcess : ProcessComponent, IProcess<Nivel, NivelRequest>
    {
        public void Actualizar(NivelRequest request)
        {
            var response = HttpPost("api/Nivel/Actualizar", request, MediaType.Json);
        }


        public void Agregar(NivelRequest request)
        {
            var response = HttpPost("api/Nivel/Agregar", request, MediaType.Json);
        }

        public void Eliminar(int id)
        {
            var response = HttpPost("api/Nivel/Eliminar", id, MediaType.Json);
        }

        public Nivel ObtenerUno(int id)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("id", id);
            var response = HttpGet<NivelResponse>("api/Nivel/ObtenerUno", parameters, MediaType.Json);
            return response.obtenerUno;
        }

        public IList<Nivel> ToList()
        {
            var response = HttpGet<NivelResponse>("api/Nivel/ListarTodos", new Dictionary<string, object>(), MediaType.Json);
            return response.ObtenerTodo;
        }
    }

}
