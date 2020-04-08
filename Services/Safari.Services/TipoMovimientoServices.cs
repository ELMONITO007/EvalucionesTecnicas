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
   public class TipoMovimientoServices : ITipoMovimiento
    {
        public TipoMovimiento Create(TipoMovimiento objeto)
        {
            var bc = new TipoMovimientoComponent();
            return bc.Create(objeto);
        }

        public void Delete(int id)
        {
            var bc = new TipoMovimientoComponent();
            bc.Delete(id);
        }

        public List<TipoMovimiento> Read()
        {

            var bc = new TipoMovimientoComponent();
            return bc.Read();
        }

        public TipoMovimiento ReadBy(int id)
        {
            var bc = new TipoMovimientoComponent();
            return bc.ReadBy(id);
        }

        public void Update(TipoMovimiento objeto)
        {
            var bc = new TipoMovimientoComponent();
            bc.Update(objeto);
        }
    }
}
