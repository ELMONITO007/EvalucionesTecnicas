using Safari.Business;
using Safari.Services.Contracts;
using Safari.Services.Contracts.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Safari.Services.Http
{
    [RoutePrefix("api/Nivel")]
    public class NivelServicesHTTP : ApiController, IServiceHttp<NivelResponse, NivelRequest>
    {
        [HttpPost]
        [Route("Actualizar")]
        public void Actualizar(NivelRequest agregarRequest)
        {
            try
            {

                var bc = new NivelComponent();
                bc.Update(agregarRequest.Objeto);

            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422, // UNPROCESSABLE ENTITY
                    ReasonPhrase = ex.Message
                };
                throw new HttpResponseException(httpError);
            }
        }
        [HttpPost]
        [Route("Agregar")]
        public void Crear(NivelRequest agregarRequest)
        {
            try
            {

                var bc = new NivelComponent();
                bc.Create(agregarRequest.Objeto);

            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422, // UNPROCESSABLE ENTITY
                    ReasonPhrase = ex.Message
                };
                throw new HttpResponseException(httpError);
            }
        }
        [HttpPost]
        [Route("Eliminar")]
        public void Eliminar(NivelRequest agregarRequest)
        {
            try
            {

                var bc = new NivelComponent();
                bc.Delete(agregarRequest.Objeto.Id);


            }
            catch (Exception ex)
            {

                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    ReasonPhrase = ex.Message
                };
                throw new HttpResponseException(httpError);

            }
        }
        [HttpGet]
        [Route("ListarTodos")]
        public NivelResponse ListarTodos()
        {
            try
            {
                var response = new NivelResponse();
                var bc = new NivelComponent();
                response.ObtenerTodo = bc.Read();
                return response;

            }
            catch (Exception ex)
            {

                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    ReasonPhrase = ex.Message
                };
                throw new HttpResponseException(httpError);

            }
        }
        [HttpGet]
        [Route("ObtenerUno")]
        public NivelResponse ObtenerUno(int id)
        {
            try
            {
                var response = new NivelResponse();
                var bc = new NivelComponent();
                response.obtenerUno = bc.ReadBy(id);
                return response;

            }
            catch (Exception ex)
            {

                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    ReasonPhrase = ex.Message
                };
                throw new HttpResponseException(httpError);
            }
        }
    }
}
