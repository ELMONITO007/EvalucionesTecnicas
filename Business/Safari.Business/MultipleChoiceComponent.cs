using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Safari.Data;
using Safari.Entities;

namespace Safari.Business
{
  public  class MultipleChoiceComponent : Component<MultipleChoice>
    {
        public override MultipleChoice Create(MultipleChoice objeto)
        {

            MultipleChoice result = default(MultipleChoice);
            var multipleChoiceDAC = new MultipleChoiceDAC();

            result = multipleChoiceDAC.Create(objeto);
            return result;
        }

        public override void Delete(int id)
        {
            var multipleChoiceDAC = new MultipleChoiceDAC();
            multipleChoiceDAC.Delete(id);
        }

        public override List<MultipleChoice> Read()
        {
            List<MultipleChoice> result = default(List<MultipleChoice>);
            var multipleChoiceDAC = new MultipleChoiceDAC();
            result = multipleChoiceDAC.Read();
            return result;
        }


        public override MultipleChoice ReadBy(int id)
        {
            MultipleChoice result = default(MultipleChoice);
            var multipleChoiceDAC = new MultipleChoiceDAC();
            result = multipleChoiceDAC.ReadBy(id);
            return result;
        }

        public override void Update(MultipleChoice objeto)
        {
            var multipleChoiceDAC = new MultipleChoiceDAC();
            multipleChoiceDAC.Update(objeto);


        }
        public List<MultipleChoice> listaRespuestaMultipleChoiceAlAzar(int id_pregunta)
        {


            List<MultipleChoice> result = default(List<MultipleChoice>);
            var multipleChoiceDAC = new MultipleChoiceDAC();
            result = multipleChoiceDAC.listaRespuestaMultipleChoiceAlAzar(id_pregunta);
            return result;
        }


        public List<MultipleChoice> ObtenerRespuestaCorrecta(int id_pregunta)
        {


            List<MultipleChoice> result = default(List<MultipleChoice>);
            var multipleChoiceDAC = new MultipleChoiceDAC();
            result = multipleChoiceDAC.ObtenerRespuestaCorrecta(id_pregunta);
            return result;
        }



    }
}
