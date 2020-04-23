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
 public   class MultipleChoiceProcess : ProcessComponent, IProcess<MultipleChoice, MultipleChoiceRequest>
    {
        public void Actualizar(MultipleChoiceRequest request)
        {
            var response = HttpPost("api/MultipleChoice/Actualizar", request, MediaType.Json);
        }

        public void Agregar(MultipleChoiceRequest request)
        {
            var response = HttpPost("api/MultipleChoice/Agregar", request, MediaType.Json);
        }

        public void Eliminar(MultipleChoiceRequest request)
        {
            var response = HttpPost("api/MultipleChoice/Eliminar", request, MediaType.Json);
        }

        public MultipleChoice ObtenerUno(int id)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("id", id);
            var response = HttpGet<MultipleChoiceResponse>("api/MultipleChoice/ObtenerUno", parameters, MediaType.Json);
            return response.obtenerUno;
        }

        public IList<MultipleChoice> ToList()
        {
            var response = HttpGet<MultipleChoiceResponse>("api/Nivel/ListarTodos", new Dictionary<string, object>(), MediaType.Json);
            return response.ObtenerTodo;
        }
    }
}
