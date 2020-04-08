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
  public  class SalaServices : ISala
    {
        public Sala Create(Sala objeto)
        {
            var bc = new SalaComponent();
            return bc.Create(objeto);
        }

        public void Delete(int id)
        {
            var bc = new SalaComponent();
            bc.Delete(id);
        }

        public List<Sala> Read()
        {

            var bc = new SalaComponent();
            return bc.Read();
        }

        public Sala ReadBy(int id)
        {
            var bc = new SalaComponent();
            return bc.ReadBy(id);
        }

        public void Update(Sala objeto)
        {
            var bc = new SalaComponent();
            bc.Update(objeto);
        }

    }
}
