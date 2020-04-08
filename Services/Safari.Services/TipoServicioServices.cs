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
    public class TipoServicioServices : ITipoServicio
    {
        public TipoServicio Create(TipoServicio objeto)
        {
            var bc = new TipoServicioComponent();
            return bc.Create(objeto);
        }

        public void Delete(int id)
        {
            var bc = new TipoServicioComponent();
            bc.Delete(id);
        }

        public List<TipoServicio> Read()
        {

            var bc = new TipoServicioComponent();
            return bc.Read();
        }

        public TipoServicio ReadBy(int id)
        {
            var bc = new TipoServicioComponent();
            return bc.ReadBy(id);
        }

        public void Update(TipoServicio objeto)
        {
            var bc = new TipoServicioComponent();
            bc.Update(objeto);
        }
    }
}
