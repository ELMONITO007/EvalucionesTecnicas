﻿using System;
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
        public List<Pregunta> ObtenerPreguntasAlAzar(Pregunta pregunta, int cantidad)
        {


            List<Pregunta> result = default(List<Pregunta>);
            var preguntaNivel = new PreguntaDAC();
            result = preguntaNivel.ObtenerPreguntarAlAzarPorNivelYCategoria(pregunta, cantidad);
            return result;
        }



        public List<Pregunta> obtenerpregunta(Nivel nivel, int Cantidad, Categoria categoria)
        {
            List<Pregunta> result = default(List<Pregunta>);
            Pregunta temp = new Pregunta();
            temp.nivel = nivel;
            temp.categoria = categoria;

            result = ObtenerPreguntasAlAzar(temp, Cantidad);


            return result;
        }


        public List<Pregunta> obtenerLaspreguntas(List<Pregunta> preguntas, int CantidadFacil, int CantidadMedio, int CantidadDificil)
        {
            List<Pregunta> result = new List<Pregunta>();
            Pregunta temp = new Pregunta();
            foreach (var item in preguntas)
            {
                List<Pregunta> listaTemp = default(List<Pregunta>);
                if (item.nivel.ElNivel=="Facil")
                {
                    listaTemp = obtenerpregunta(item.nivel, CantidadFacil, item.categoria);
                    foreach (Pregunta item2 in listaTemp)
                    {
                        result.Add(item2);
                    }
                }
                else if (item.nivel.ElNivel == "Medio")
                {

                    listaTemp = obtenerpregunta(item.nivel, CantidadMedio, item.categoria);
                    foreach (Pregunta item2 in listaTemp)
                    {
                        result.Add(item2);
                    }
                }
                else if (item.nivel.ElNivel == "Dificil")
                {
                    listaTemp = obtenerpregunta(item.nivel, CantidadDificil, item.categoria);
                    foreach (Pregunta item2 in listaTemp)
                    {
                        result.Add(item2);
                    }
                }

            }
            return result;
        }
        public List<Pregunta> LeerPorTipoDePregunta(TipoPregunta tipoPregunta)
        {
            List<Pregunta> result = new List<Pregunta>();
            PreguntaDAC preguntaDAC = new PreguntaDAC();
            result = preguntaDAC.LeerPorTipoDePregunta(tipoPregunta.Id);

            return result;
        }
    }
}
