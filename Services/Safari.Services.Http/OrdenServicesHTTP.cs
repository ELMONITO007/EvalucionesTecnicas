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
    [RoutePrefix("api/Orden")]
    public  class OrdenServicesHTTP : ApiController, IServiceHttp<OrdenResponse, RequestOrden>
    {
        [HttpPost]
        [Route("Actualizar")]
        public void Actualizar(RequestOrden agregarRequest)
        {
            try
            {

                var bc = new OrdenComponent();
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
        public void Crear(RequestOrden agregarRequest)
        {
            try
            {

                var bc = new OrdenComponent();
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

                var bc = new OrdenComponent();
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
        public OrdenResponse ListarTodos()
        {
            try
            {
                var response = new OrdenResponse();
                var bc = new OrdenComponent();
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
        public OrdenResponse ObtenerUno(int id)
        {
            try
            {
                var response = new OrdenResponse();
                var bc = new OrdenComponent();
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
        [Route("listaRespuestaOrdenAlAzar")]
        public OrdenResponse listaRespuestaMultipleChoiceAlAzar(int id_pregunta)
        {

            try
            {
                var response = new OrdenResponse();


                var bc = new OrdenComponent();
                response.ObtenerTodo = bc.listaRespuestaOrdenAlAzar(id_pregunta);
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
        public OrdenResponse ObtenerRespuestaCorrecta(int id_pregunta)
        {

            try
            {
                var response = new OrdenResponse();


                var bc = new OrdenComponent();
                response.ObtenerTodo = bc.listaRespuestaCorrecta(id_pregunta);
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
