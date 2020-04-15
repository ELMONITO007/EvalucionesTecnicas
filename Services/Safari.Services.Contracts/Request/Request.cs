using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Services.Contracts.Request
{
    interface Request <T>
    {
         T Objeto { get; set; }

     


    }
}
