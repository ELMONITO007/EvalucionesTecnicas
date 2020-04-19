using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace Safari.Services.Contracts.Request
{
    [DataContract]
    public class PreguntaRequest : Request<Pregunta>
    {
        [DataMember]
        public Pregunta Objeto { get; set; }
        [DataMember]
        public List<Pregunta> Listapreguntas { get; set; }


     
        public PreguntaRequest()
        {
            Objeto = new Pregunta();
            Listapreguntas = new List<Pregunta>();
        }

        public List<Pregunta> ObtenerPreguntas(List<PreguntaRequest> preguntaRequests)
        {
            foreach (PreguntaRequest item in preguntaRequests)
            {
                Listapreguntas.Add(item.Objeto);
            }
            return Listapreguntas;
        }
    }
}
