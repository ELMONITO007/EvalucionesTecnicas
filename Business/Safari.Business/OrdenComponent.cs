using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Safari.Data;
using Safari.Entities;

namespace Safari.Business
{
  public  class OrdenComponent : Component<Orden>
    {
        public override Orden Create(Orden objeto)
        {

            Orden result = default(Orden);
            var orden = new OrdenDAC();

            result = orden.Create(objeto);
            return result;
        }

        public override void Delete(int id)
        {
            var orden = new OrdenDAC();
            orden.Delete(id);
        }

        public override List<Orden> Read()
        {
            List<Orden> result = default(List<Orden>);
            var orden = new OrdenDAC();
            result = orden.Read();
            return result;
        }


        public override Orden ReadBy(int id)
        {
            Orden result = default(Orden);
            var orden = new OrdenDAC();
            result = orden.ReadBy(id);
            return result;
        }

        public override void Update(Orden objeto)
        {
            var orden = new OrdenDAC();
            orden.Update(objeto);


        }
        public List<Orden> listaRespuestaCorrecta(int id_pregunta)
        {


            List<Orden> result = default(List<Orden>);
            var orden = new OrdenDAC();
            result = orden.listaRespuestaCorrecta(id_pregunta);
     
            return result;
        }
        public List<Orden> listaRespuestaOrdenAlAzar(int id_pregunta)
        {


            List<Orden> result = default(List<Orden>);
            var orden = new OrdenDAC();
            result = orden.listaRespuestaOrdenAlAzar(id_pregunta);

            return result;
        }
    }
}
