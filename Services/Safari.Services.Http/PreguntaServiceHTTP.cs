﻿
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
        public void Eliminar(PreguntaRequest agregarRequest)
        {
            try
            {

                var bc = new PreguntaComponent();
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
        [HttpPost]
        [Route("ObtenerAlAzar")]
        public PreguntaResponse ObtenerAlAzar(PreguntaRequest agregarRequest,int cantidad)
        {

            try
            {
                var response = new PreguntaResponse();
               

                var bc = new PreguntaComponent();
                response.ObtenerTodo = bc.ObtenerPreguntasAlAzar(agregarRequest.Objeto,cantidad);
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
        [Route("obtenerpreguntaFacil")]
        public PreguntaResponse obtenerLaspreguntas(List<PreguntaRequest>preguntaRequests, int CantidadFacil, int CantidadMedio, int CantidadDificil)
        {

            try
            {
                var response = new PreguntaResponse();
                var preguntar = new PreguntaRequest();
            
                var bc = new PreguntaComponent();
                response.ObtenerTodo = bc.obtenerLaspreguntas(preguntar.ObtenerPreguntas(preguntaRequests),CantidadFacil,CantidadMedio,CantidadDificil);

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
        [Route("LeerPorTipoDePregunta")]
        public PreguntaResponse LeerPorTipoDePregunta(int id)
        {

            try
            {
                var response = new PreguntaResponse();

                TipoPreguntaRequest tipoPreguntaRequest = new TipoPreguntaRequest();
                tipoPreguntaRequest.Objeto.Id = id;
                var bc = new PreguntaComponent();
                response.ObtenerTodo = bc.LeerPorTipoDePregunta(tipoPreguntaRequest.Objeto);

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
