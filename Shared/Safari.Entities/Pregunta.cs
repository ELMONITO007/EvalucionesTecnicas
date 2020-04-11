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
  public  class Pregunta : EntityBase
    {
        public override int Id { get; set; }

        [DataMember]
        [DisplayName("Pregunta")]
        [Required]
        public string LaPregunta { get; set; }

        [DataMember]
        [Required]
        public Nivel nivel { get; set; }

        [DataMember]
        [DisplayName("Imagen")]
        public string Imagen { get; set; }

        [DataMember]
        public List<Respuesta> ListaRespuesta{ get; set; }

        public Categoria categoria { get; set; }

        public Pregunta ()
        {
            ListaRespuesta = new List<Respuesta>();
            nivel = new Nivel();
            categoria = new Categoria();
        }
}
}
