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
    public class Cita : EntityBase
    {

        [DataType(DataType.Date, ErrorMessage = "Ingrese en formato fecha dd/mm/aaaa")]
        [Required]
        [DataMember]
        [DisplayName("Fecha de la cita")]
        
        public DateTime fecha { get; set; }


        [DataMember]
        [DisplayName("Medico")]
        public int medico { get; set; }

        [DataMember]
        [DisplayName("Paciente")]
        public int Paciente { get; set; }

        [DataMember]
        [DisplayName("Sala")]
        public int sala { get; set; }

        [DataMember]
        [DisplayName("Tipo de servicio")]
        public int tipoServicio { get; set; }

        [DataType(DataType.Text, ErrorMessage = "Ingrese texto")]
        [Required]
        [DataMember]
        [DisplayName("Estado")]
        public string estado { get; set; }

       
        public int createBy { get; set; }
      
        public DateTime createDate { get; set; }
       
        public int changeBy { get; set; }
       
        public DateTime changeDate { get; set; }
      
        public int deleteBy { get; set; }
       
        public DateTime deleteDate { get; set; }

      
        public int delete { get; set; }

        [DataMember]
        public override int Id { get; set; }
    }
}
