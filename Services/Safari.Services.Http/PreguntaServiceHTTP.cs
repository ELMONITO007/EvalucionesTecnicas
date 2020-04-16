
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
    [RoutePrefix("api/Pregunta")]
   public class PreguntaServiceHTTP : ApiController, IServiceHttp<PreguntaResponse, PreguntaRequest>
    {
        [HttpPost]
        [Route("Actualizar")]
        public void Actualizar(PreguntaRequest agregarRequest)
        {
            try
            {

                var bc = new PreguntaComponent();
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
        public void Crear(PreguntaRequest agregarRequest)
        {
            try
            {

                var bc = new PreguntaComponent();
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
        public void Eliminar(int id)
        {
            try
            {

                var bc = new PreguntaComponent();
                bc.Delete(id);


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
        public PreguntaResponse ListarTodos()
        {
            try
            {
                var response = new PreguntaResponse();
                var bc = new PreguntaComponent();
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
        public PreguntaResponse ObtenerUno(int id)
        {
            try
            {
                var response = new PreguntaResponse();
                var bc = new PreguntaComponent();
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
