using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Services.Contracts
{
 public   interface Contracts <T>
    {
      T Create(T objeto);
     List<T> Read();
     T ReadBy(int id);
       void Update(T objeto);

         void Delete(int id);
    }
}
