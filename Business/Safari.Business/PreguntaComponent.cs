using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Safari.Data;
using Safari.Entities;

namespace Safari.Business
{
    public class PreguntaComponent : Component<Pregunta>
    {
        public override Pregunta Create(Pregunta objeto)
        {

            Pregunta result = default(Pregunta);
            var preguntaNivel = new PreguntaDAC();

            result = preguntaNivel.Create(objeto);
            return result;
        }

        public override void Delete(int id)
        {
            var preguntaNivel = new PreguntaDAC();
            preguntaNivel.Delete(id);
        }

        public override List<Pregunta> Read()
        {
            List<Pregunta> result = default(List<Pregunta>);
            var preguntaNivel = new PreguntaDAC();
            result = preguntaNivel.Read();
            return result;
        }
        

        public override Pregunta ReadBy(int id)
        {
            Pregunta result = default(Pregunta);
            var preguntaNivel = new PreguntaDAC();
            result = preguntaNivel.ReadBy(id);
            return result;
        }

        public override void Update(Pregunta objeto)
        {
            var preguntaNivel = new PreguntaDAC();
            preguntaNivel.Update(objeto);


        }
        public  List<Pregunta> ObtenerPreguntasAlAzar()
        {


            List<Pregunta> result = default(List<Pregunta>);
            var preguntaNivel = new PreguntaDAC();
            result = preguntaNivel.Read();
            return result;
        }

    }
}
