using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Services.Http
{
   public  interface IServiceHttp<Tone,Ttwo>
    {
        Tone ListarTodos();
      void Actualizar(Ttwo agregarRequest);
        Tone ObtenerUno(int id);
        void Eliminar(int id);
       void Crear(Ttwo agregarRequest);

    }
}   
