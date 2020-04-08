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
  public  class PacienteServices : IPaciente
    {
        public Paciente Create(Paciente objeto)
        {
            var bc = new PacienteComponent();
            return bc.Create(objeto);
        }

        public void Delete(int id)
        {
            var bc = new PacienteComponent();
            bc.Delete(id);
        }

        public List<Paciente> Read()
        {

            var bc = new PacienteComponent();
            return bc.Read();
        }

        public Paciente ReadBy(int id)
        {
            var bc = new PacienteComponent();
            return bc.ReadBy(id);
        }

        public void Update(Paciente objeto)
        {
            var bc = new PacienteComponent();
            bc.Update(objeto);
        }

    }
}
