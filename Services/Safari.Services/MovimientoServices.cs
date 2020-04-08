using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Safari.Business;
using Safari.Entities;
using Safari.Services.Contracts;

namespace Safari.Services
{
   public class MovimientoServices : IMovimiento
    {
        public Movimiento Create(Movimiento objeto)
        {
            var bc = new MovimientoComponent();
            return bc.Create(objeto);
        }

        public void Delete(int id)
        {
            var bc = new MovimientoComponent();
            bc.Delete(id);
        }

        public List<Movimiento> Read()
        {

            var bc = new MovimientoComponent();
            return bc.Read();
        }

        public Movimiento ReadBy(int id)
        {
            var bc = new MovimientoComponent();
            return bc.ReadBy(id);
        }

        public void Update(Movimiento objeto)
        {
            var bc = new MovimientoComponent();
            bc.Update(objeto);
        }

    }
}
