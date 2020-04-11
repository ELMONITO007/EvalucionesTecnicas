﻿using System;
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
    public class Categoria : EntityBase
    {
        public override int Id { get; set; }

        [DataMember]
        [DisplayName("Categoria")]
        [Required]
        public string LaCategoria { get; set; }

        [DataMember]
        [DisplayName("Descripción")]
        [Required]
        public string Descripcion { get; set; }


    }
}
