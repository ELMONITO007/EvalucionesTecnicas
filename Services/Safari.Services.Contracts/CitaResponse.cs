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
   public class CitaResponse
    {
        [DataMember]
        public List<Cita> obtenerTodos { get; set; }

        [DataMember]
        public Cita obtenerUno { get; set; }

        [DataMember]
        public Cita agregar { get; set; }

    }
}
