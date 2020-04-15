
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
    public class CategoriaResponse : Response<Categoria>
    {
        [DataMember]
        public List<Categoria> ObtenerTodo { get; set; }
        [DataMember]
        public Categoria obtenerUno { get; set; }
        [DataMember]
        public Categoria agregar { get; set; }
    }
}
