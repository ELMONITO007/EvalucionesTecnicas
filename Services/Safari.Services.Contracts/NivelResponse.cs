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
    public class NivelResponse : Response<Nivel>
    {
        [DataMember]
        public List<Nivel> ObtenerTodo { get; set; }
        [DataMember]
        public Nivel obtenerUno { get; set; }
        [DataMember]
        public Nivel agregar { get; set; }
    }
}
