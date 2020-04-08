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
   public class CitaServices : ICita
    {

        public Cita Create(Cita objeto)
        {
            var bc = new CitaComponent();
            return bc.Create(objeto);
        }

        public void Delete(int id)
        {
            var bc = new CitaComponent();
            bc.Delete(id);
        }

        public List<Cita> Read()
        {

            var bc = new CitaComponent();
            return bc.Read();
        }

        public Cita ReadBy(int id)
        {
            var bc = new CitaComponent();
            return bc.ReadBy(id);
        }

        public void Update(Cita objeto)
        {
            var bc = new CitaComponent();
            bc.Update(objeto);
        }


    }
}
