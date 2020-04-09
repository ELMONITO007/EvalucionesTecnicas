using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace Safari.Entities
{
    [Serializable]
    [DataContract]
    public   class Orden : Respuesta
    {
        [DataMember]
        [DisplayName("Orden")]
        [Required]
       
        public int NumeroOrden { get; set; }

        public Orden(Pregunta pr)
        {
            pregunta =new Pregunta();
            pregunta = pr;
        }
        public Orden()
        {
          
        }
    }
}
