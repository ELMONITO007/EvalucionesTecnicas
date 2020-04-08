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
    public class Nivel : EntityBase
    {
        public override int Id { get; set; }


        [DataMember]
        [DisplayName("Nivel")]
        [Required]
        public string ElNivel { get; set; }

    }
}
