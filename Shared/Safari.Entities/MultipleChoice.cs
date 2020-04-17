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
    public  class MultipleChoice : Respuesta
    {
        [Required]
        [DataMember]
        [DisplayName("Respuesta Correcta")]

        public bool Correcta { get; set; }
        public MultipleChoice(Pregunta pr)
        {
            pregunta = new Pregunta();
            pregunta = pr;
        }
        public MultipleChoice()
        {
            pregunta = new Pregunta();
        }
    }
}
