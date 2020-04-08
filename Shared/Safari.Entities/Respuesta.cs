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
    public abstract class Respuesta : EntityBase
    {
        [Required]
        [DataMember]
        [DisplayName("Respuesta")]
        public string LaRespuesta { get; set; }


    }
}
