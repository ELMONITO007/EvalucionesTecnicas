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
 public   class MultipleChoiceResponse : Response<MultipleChoice>
    {
        [DataMember]
        public List<MultipleChoice> ObtenerTodo { get; set; }
        [DataMember]
        public MultipleChoice obtenerUno { get; set; }
        [DataMember]
        public MultipleChoice agregar { get; set; }
    }
}
