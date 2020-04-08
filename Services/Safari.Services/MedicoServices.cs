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
    public class MedicoServices : Imedico
    {
        public Medico Create(Medico objeto)
        {
            var bc = new MedicoComponent();
            return bc.Create(objeto);
        }

        public void Delete(int id)
        {
            var bc = new MedicoComponent();
            bc.Delete(id);
        }

        public List<Medico> Read()
        {

            var bc = new MedicoComponent();
            return bc.Read();
        }

        public Medico ReadBy(int id)
        {
            var bc = new MedicoComponent();
            return bc.ReadBy(id);
        }

        public void Update(Medico objeto)
        {
            var bc = new MedicoComponent();
             bc.Update(objeto);
        }
    }
}
