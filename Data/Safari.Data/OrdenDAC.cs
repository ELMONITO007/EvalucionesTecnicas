using Microsoft.Practices.EnterpriseLibrary.Data;
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
    public class OrdenDAC : DataAccessComponent, IRepository<Orden>
    {
        private Orden LoadOrden(IDataReader dr)
        {
            Orden orden = new Orden();
            orden.Id = GetDataValue<int>(dr, "ID_Respuesta");
            orden.NumeroOrden = GetDataValue<int>(dr, "Orden");
            orden.LaRespuesta = GetDataValue<string>(dr, "Respuesta");
            orden.pregunta.Id = GetDataValue<int>(dr, "ID_Pregunta");
            return orden;
        }


        public Orden Create(Orden entity)
        {
            const string SQL_STATEMENT = "insert into Respuesta(Respuesta,Orden,ID_Pregunta,Activo)values(@Respuesta,@Orden,@ID_Pregunta,1)";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {

                db.AddInParameter(cmd, "@Respuesta", DbType.String, entity.LaRespuesta);
                db.AddInParameter(cmd, "@Orden", DbType.Int32, entity.NumeroOrden);
                db.AddInParameter(cmd, "@ID_Pregunta", DbType.Int32, entity.pregunta.Id);
                
                entity.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }


            return entity;
        }

        public void Delete(int id)
        {
            const string SQL_STATEMENT = "update Respuesta set Active=0 where Id=@Id";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public List<Orden> Read()
        {
            const string SQL_STATEMENT = "lect ID_Respuesta,Respuesta,Orden,ID_Pregunta from Respuesta where Activo=1 and orden is not Null";

            List<Orden> result = new List<Orden>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Orden orden = LoadOrden(dr);
                        result.Add(orden);
                    }
                }
            }
            return result;
        }

        public Orden ReadBy(int id)
        {
            const string SQL_STATEMENT = "select ID_Respuesta,Respuesta,Orden,ID_Pregunta from Respuesta where Activo=1 and ID_Pregunta=@id and orden is not Null";
            Orden   orden = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        orden = LoadOrden(dr);
                    }
                }
            }
            return orden;
        }

        public List<Orden> listaRespuestaOrdenAlAzar(int id_pregunta)
        {
            const string SQL_STATEMENT = "select ID_Respuesta,Respuesta,Orden,ID_Pregunta from Respuesta where Activo=1 and ID_Pregunta=@ and orden is not Null order by NEWID()";

            List<Orden> result = new List<Orden>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id_pregunta);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Orden orden = LoadOrden(dr);
                        result.Add(orden);
                    }
                }
            }
            return result;
        }

        public void Update(Orden entity)
        {
            const string SQL_STATEMENT = "update Respuesta set Respuesta=@Respuesta,Orden=@Orden,ID_Pregunta=@ID_Pregunta where ID_Respuesta=@Id ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, entity.Id);
                db.AddInParameter(cmd, "@Respuesta", DbType.String, entity.LaRespuesta);
                db.AddInParameter(cmd, "@Orden", DbType.Int32, entity.NumeroOrden);
                db.AddInParameter(cmd, "@ID_Pregunta", DbType.Int32, entity.pregunta.Id);
                db.ExecuteNonQuery(cmd);
            }
        }
    }
}
