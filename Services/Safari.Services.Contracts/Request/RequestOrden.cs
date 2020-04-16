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
 public   class RequestOrden : Request<Orden>
    {
        [DataMember]
        public Orden Objeto { get; set; }

        public RequestOrden()
        {
            Objeto = new Orden();
        }
    }
}
