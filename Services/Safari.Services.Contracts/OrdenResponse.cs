using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Services.Contracts
{
    public class OrdenResponse : Response<Orden>
    {
        [DataMember]
        public List<Orden> ObtenerTodo { get; set; }
        [DataMember]
        public Orden obtenerUno { get; set; }
        [DataMember]
        public Orden agregar { get; set; }

        [DataMember]
        public List<int> OrdenDiponible { get; set; }
    }
}
