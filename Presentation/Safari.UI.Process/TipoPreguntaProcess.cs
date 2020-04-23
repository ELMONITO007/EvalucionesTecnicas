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
    public class TipoPreguntaProcess : ProcessComponent, IProcess<TipoPregunta, TipoPreguntaRequest>
    {
        public void Actualizar(TipoPreguntaRequest request)
        {
            var response = HttpPost("api/TipoPregunta/Actualizar", request, MediaType.Json);
        }

        public void Agregar(TipoPreguntaRequest request)
        {
            var response = HttpPost("api/TipoPregunta/Agregar", request, MediaType.Json);
        }

        public void Eliminar(TipoPreguntaRequest request)
        {
            var response = HttpPost("api/TipoPregunta/Delete", request, MediaType.Json);
        }

   

        public TipoPregunta ObtenerUno(int id)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("id", id);
            var response = HttpGet<TipoPreguntaResponse>("api/TipoPregunta/ObtenerUno", parameters, MediaType.Json);
            return response.obtenerUno;
        }

        public IList<TipoPregunta> ToList()
        {
            var response = HttpGet<TipoPreguntaResponse>("api/TipoPregunta/ListarTodos", new Dictionary<string, object>(), MediaType.Json);
            return response.ObtenerTodo;
        }
    }
}
