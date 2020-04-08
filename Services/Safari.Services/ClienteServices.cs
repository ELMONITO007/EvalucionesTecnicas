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
  public  class ClienteServices  : ICliente
    {

        public Cliente Create(Cliente objeto)
        {
            var bc = new ClienteComponent();
            return bc.Create(objeto);
        }

        public void Delete(int id)
        {
            var bc = new ClienteComponent();
            bc.Delete(id);
        }

        public List<Cliente> Read()
        {

            var bc = new ClienteComponent();
            return bc.Read();
        }

        public Cliente ReadBy(int id)
        {
            var bc = new ClienteComponent();
            return bc.ReadBy(id);
        }

        public void Update(Cliente objeto)
        {
            var bc = new ClienteComponent();
            bc.Update(objeto);
        }
    }
}
