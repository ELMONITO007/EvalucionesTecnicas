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
    [RoutePrefix("api/Cita")]
    public class CitaServicesHTTP : ApiController, IServiceHttp<CitaResponse, CitaRequest>
    {
        [HttpPost]
        [Route("Actualizar")]
        public void Actualizar(CitaRequest agregarRequest)
        {
            try
            {

                var bc = new CitaComponent();
                bc.Update(agregarRequest.cita);

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
        public void Crear(CitaRequest agregarRequest)
        {

            try
            {

                var bc = new CitaComponent();
                bc.Create(agregarRequest.cita);

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

                var bc = new CitaComponent();
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
        public CitaResponse ListarTodos()
        {
            try
            {
                var response = new CitaResponse();
                var bc = new CitaComponent();
                response.obtenerTodos = bc.Read();
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
        public CitaResponse ObtenerUno(int id)
        {
            try
            {
                var response = new CitaResponse();
                var bc = new CitaComponent();
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
