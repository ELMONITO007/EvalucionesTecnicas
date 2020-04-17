using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Safari.Data;
using Safari.Entities;

namespace Safari.Business
{
 public   class RespuestaComponent
    {

        public void hola()
        {
            List<Respuesta> respuestas = new List<Respuesta>();

            MultipleChoice mc = new MultipleChoice();
            respuestas.Add(mc);
        }
       

    }
}
