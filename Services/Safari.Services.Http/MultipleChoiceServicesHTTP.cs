
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
    [RoutePrefix("api/MultipleChoice")]
   public class MultipleChoiceServicesHTTP : ApiController, IServiceHttp<MultipleChoiceResponse, MultipleChoiceRequest>
    {
        [HttpPost]
        [Route("Actualizar")]
        public void Actualizar(MultipleChoiceRequest agregarRequest)
        {
            try
            {

                var bc = new MultipleChoiceComponent();
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
        public void Crear(MultipleChoiceRequest agregarRequest)
        {
            try
            {

                var bc = new MultipleChoiceComponent();
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
        public void Eliminar(MultipleChoiceRequest agregarRequest)
        {
            try
            {

                var bc = new MultipleChoiceComponent();
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
        public MultipleChoiceResponse ListarTodos()
        {
            try
            {
                var response = new MultipleChoiceResponse();
                var bc = new MultipleChoiceComponent();
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
        public MultipleChoiceResponse ObtenerUno(int id)
        {
            try
            {
                var response = new MultipleChoiceResponse();
                var bc = new MultipleChoiceComponent();
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
        [HttpPost]
        [Route("listaRespuestaMultipleChoiceAlAzar")]
        public MultipleChoiceResponse listaRespuestaMultipleChoiceAlAzar(int id_pregunta)
        {

            try
            {
                var response = new MultipleChoiceResponse();


                var bc = new MultipleChoiceComponent();
                response.ObtenerTodo = bc.listaRespuestaMultipleChoiceAlAzar(id_pregunta);
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
        [HttpPost]
        [Route("ObtenerRespuestaCorrecta")]
        public MultipleChoiceResponse ObtenerRespuestaCorrecta(int id_pregunta)
        {

            try
            {
                var response = new MultipleChoiceResponse();


                var bc = new MultipleChoiceComponent();
                response.ObtenerTodo = bc.ObtenerRespuestaCorrecta(id_pregunta);
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
