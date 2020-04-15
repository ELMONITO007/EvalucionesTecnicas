using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Services.Contracts
{
    interface Response<T>
    {
         List<T> ObtenerTodo { get; set; }
        T obtenerUno { get; set; }
        T agregar { get; set; }
    }
}
