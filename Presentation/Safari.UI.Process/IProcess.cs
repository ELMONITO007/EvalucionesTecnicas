using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.UI.Process
{
    interface IProcess<T1,T2>
    {
        IList<T1> ToList();
        void Agregar(T2 request);

        T1 ObtenerUno(int id);

        void Actualizar(T2 request);

        void Eliminar(int id);
    }
}
