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
    public class TipoPreguntaResponse : Response<TipoPregunta>
    {
        [DataMember]
        public List<TipoPregunta> ObtenerTodo { get; set; }
        [DataMember]
        public TipoPregunta obtenerUno { get; set; }
        [DataMember]
        public TipoPregunta agregar { get; set; }
    }
}
