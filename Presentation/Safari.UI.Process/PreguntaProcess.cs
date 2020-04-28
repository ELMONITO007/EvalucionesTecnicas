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
    public class PreguntaProcess : ProcessComponent, IProcess<Pregunta, PreguntaRequest>
    {
        public void Actualizar(PreguntaRequest request)
        {
            var response = HttpPost("api/Pregunta/Actualizar", request, MediaType.Json);
        }

        public void Agregar(PreguntaRequest request)
        {
            var response = HttpPost("api/Pregunta/Agregar", request, MediaType.Json);
        }

        public void Eliminar(PreguntaRequest request)
        {
            var response = HttpPost("api/Pregunta/Eliminar", request, MediaType.Json);
        }

        public Pregunta ObtenerUno(int id)
        {    var parameters = new Dictionary<string, object>();
            parameters.Add("id", id);
            var response = HttpGet<PreguntaReponse>("api/Pregunta/ObtenerUno", parameters, MediaType.Json);
            return response.obtenerUno;
           
        }

        public IList<Pregunta> ToList()
        {
            var response = HttpGet<PreguntaReponse>("api/Pregunta/ListarTodos", new Dictionary<string, object>(), MediaType.Json);
            return response.ObtenerTodo;
        }
        public IList<Pregunta> LeerPorTipoDePregunta(int id)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("id", id);

            var response = HttpGet<PreguntaReponse>("api/Pregunta/LeerPorTipoDePregunta", parameters, MediaType.Json);
            return response.ObtenerTodo;
        }

    }
}
