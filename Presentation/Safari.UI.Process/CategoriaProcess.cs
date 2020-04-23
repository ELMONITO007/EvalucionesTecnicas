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
    public class CategoriaProcess : ProcessComponent, IProcess<Categoria, CategoriaRequest>
    {
        public void Actualizar(CategoriaRequest request)
        {
            var response = HttpPost("api/Categoria/Actualizar", request, MediaType.Json);
        }

        public void Agregar(CategoriaRequest request)
        {
            var response = HttpPost("api/Categoria/Agregar", request, MediaType.Json);
        }

        public void Eliminar(CategoriaRequest request)
        {
            var response = HttpPost("api/Categoria/Eliminar", request, MediaType.Json);
        }

        public Categoria ObtenerUno(int id)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("id", id);
            var response = HttpGet<CategoriaResponse>("api/Categoria/ObtenerUno", parameters, MediaType.Json);
            return response.obtenerUno;
        }

        public IList<Categoria> ToList()
        {
            var response = HttpGet<CategoriaResponse>("api/Categoria/ListarTodos", new Dictionary<string, object>(), MediaType.Json);
            return response.ObtenerTodo;
        }
    }
}
