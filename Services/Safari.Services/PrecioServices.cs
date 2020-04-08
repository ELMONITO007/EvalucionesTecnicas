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
  public  class PrecioServices : IPrecio
    {
        public Precio Create(Precio objeto)
        {
            var bc = new PrecioServices();
            return bc.Create(objeto);
        }

        public void Delete(int id)
        {
            var bc = new PrecioComponent();
            bc.Delete(id);
        }

        public List<Precio> Read()
        {

            var bc = new PrecioComponent();
            return bc.Read();
        }

        public Precio ReadBy(int id)
        {
            var bc = new PrecioComponent();
            return bc.ReadBy(id);
        }

        public void Update(Precio objeto)
        {
            var bc = new PrecioComponent();
            bc.Update(objeto);
        }
    }
}
