
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

    namespace Safari.Services.Http
    {
        [RoutePrefix("api/TipoPregunta")]
 public       class TipoPreguntaServicesHTTP : ApiController, IServiceHttp<TipoPreguntaResponse, TipoPreguntaRequest>
        {
            [HttpPost]
            [Route("Actualizar")]
            public void Actualizar(TipoPreguntaRequest agregarRequest)
            {
                try
                {

                    var bc = new TipoPreguntaComponent();
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
            public void Crear(TipoPreguntaRequest agregarRequest)
            {
                try
                {

                    var bc = new TipoPreguntaComponent();
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
            [Route("Delete")]
            public void Eliminar(TipoPreguntaRequest agregarRequest)
            {
                try
                {

                    var bc = new TipoPreguntaComponent();
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
            public TipoPreguntaResponse ListarTodos()
            {
                try
                {
                    var response = new TipoPreguntaResponse();
                    var bc = new TipoPreguntaComponent();
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
            public TipoPreguntaResponse ObtenerUno(int id)
            {
                try
                {
                    var response = new TipoPreguntaResponse();
                    var bc = new TipoPreguntaComponent();
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

            public TipoPreguntaResponse ObtenerUno(TipoPreguntaRequest agregarRequest)
            {
                throw new NotImplementedException();
            }
        }
    }
    }

