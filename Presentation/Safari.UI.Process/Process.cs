using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.UI.Process
{
public   interface Process<T>
    {
          List<T> ListarTodos();
          T Agregar(T objeto);
       T Ver(int id);
        T Eliminar(int id);
        T Editar(int id, T objeto);



    }
}
