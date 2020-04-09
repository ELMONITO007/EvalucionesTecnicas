﻿using Microsoft.Practices.EnterpriseLibrary.Data;
using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Safari.Data
{
    public class PreguntaDAC : DataAccessComponent, IRepository<Pregunta>
    {
        private Pregunta LoadPregunta(IDataReader dr)
        {
            Pregunta pregunta = new Pregunta();
            pregunta.Id = GetDataValue<int>(dr, "ID_Pregunta");
            pregunta.LaPregunta = GetDataValue<string>(dr, "Pregunta");
            pregunta.Imagen = GetDataValue<string>(dr, "Imagen");
            pregunta.nivel.Id = GetDataValue<int>(dr, "ID_Nivel");
            return pregunta;
        }

        public Pregunta Create(Pregunta entity)
        {
            const string SQL_STATEMENT = "insert into Pregunta (Pregunta,Imagen,ID_Nivel)values(@Pregunta,@Imagen,@ID_Nivel)";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Pregunta", DbType.String, entity.LaPregunta);
                db.AddInParameter(cmd, "@Imagen", DbType.String, entity.Imagen);
                db.AddInParameter(cmd, "@ID_Nivel", DbType.Int32, entity.nivel.Id);
                entity.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }


            return entity;
        }

        public void Delete(int id)
        {
            const string SQL_STATEMENT = "update Pregunta set Active=0 where Id=@Id";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public List<Pregunta> Read()
        {
            const string SQL_STATEMENT = "select ID_Pregunta,Imagen,ID_Nivel from Pregunta where activo=1";

            List<Pregunta> result = new List<Pregunta>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Pregunta pregunta = LoadPregunta(dr);
                        result.Add(pregunta);
                    }
                }
            }
            return result;
        }

        public Pregunta ReadBy(int id)
        {
            const string SQL_STATEMENT = "select ID_Pregunta,Pregunta,Imagen,ID_Nivel from Pregunta where activo=1 and ID_Pregunta=@id";
            Pregunta pregunta = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        pregunta = LoadPregunta(dr);
                    }
                }
            }
            return pregunta;
        }

        public void Update(Pregunta entity)
        {
            const string SQL_STATEMENT = "update Pregunta set Pregunta=@Pregunta, Imagen=@Imagen,ID_Nivel=@ID_Nivel where ID_Pregunta=@Id";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, entity.Id);
                db.AddInParameter(cmd, "@Pregunta", DbType.String, entity.LaPregunta);
                db.AddInParameter(cmd, "@Imagen", DbType.String, entity.Imagen);
                db.AddInParameter(cmd, "@ID_Nivel", DbType.Int32, entity.nivel.Id);
                db.ExecuteNonQuery(cmd);
            }
        }
    }
}
