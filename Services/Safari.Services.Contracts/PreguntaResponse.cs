using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Services.Contracts
{
    [DataContract]
    public class PreguntaResponse : Response<Pregunta>
    {
        [DataMember]
        public List<Pregunta> ObtenerTodo { get; set; }
        [DataMember]
        public Pregunta obtenerUno { get; set; }
        [DataMember]
        public Pregunta agregar { get; set; }
    }
}
