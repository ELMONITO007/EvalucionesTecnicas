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
    public class PreguntaDAC : DataAccessComponent, IRepository<Pregunta>
    {
        private Pregunta LoadPregunta(IDataReader dr)
        {
            Pregunta pregunta = new Pregunta();
            pregunta.Id = GetDataValue<int>(dr, "ID_Pregunta");
            pregunta.LaPregunta = GetDataValue<string>(dr, "Pregunta");
            pregunta.Imagen = GetDataValue<string>(dr, "Imagen");
            pregunta.nivel.Id = GetDataValue<int>(dr, "ID_Nivel");
            pregunta.categoria.Id= GetDataValue<int>(dr, "ID_Categoria");
            pregunta.tipoPregunta.Id = GetDataValue<int>(dr, "ID_TipoPregunta");
            return pregunta;
        }

        public Pregunta Create(Pregunta entity)
        {
            const string SQL_STATEMENT = "insert into Pregunta (Pregunta,Imagen,ID_Nivel,ID_TipoPregunta)values(@Pregunta,@Imagen,@ID_Nivel,@ID_TipoPregunta)  insert into PreguntaCategoria(ID_Pregunta,ID_Categoria)values ((select ID_Pregunta from Pregunta where Pregunta=@Pregunta),@ID_Categoria)";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Pregunta", DbType.String, entity.LaPregunta);
                db.AddInParameter(cmd, "@Imagen", DbType.String, entity.Imagen);
                db.AddInParameter(cmd, "@ID_Nivel", DbType.Int32, entity.nivel.Id);
                db.AddInParameter(cmd, "@ID_Categoria", DbType.Int32, entity.categoria.Id);
                db.AddInParameter(cmd, "@Imagen", DbType.String, entity.Imagen);
                db.AddInParameter(cmd, "@ID_TipoPregunta", DbType.String, entity.tipoPregunta.Id);
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
            const string SQL_STATEMENT = "select p.ID_Pregunta,p.Pregunta,p.Imagen,p.ID_Nivel,p.ID_TipoPregunta,c.ID_Categoria from pregunta as p inner join PreguntaCategoria as pc on p.ID_Pregunta=pc.ID_Pregunta inner join Categoria as c on c.ID_Categoria=pc.ID_Categoria where activo=1";

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
            const string SQL_STATEMENT = "select p.ID_Pregunta,p.Pregunta,p.Imagen,p.ID_Nivel,p.ID_TipoPregunta,c.ID_Categoria from pregunta as p inner join PreguntaCategoria as pc on p.ID_Pregunta=pc.ID_Pregunta inner join Categoria as c on c.ID_Categoria=pc.ID_Categoria where activo=1 and ID_Pregunta=@id";
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
            const string SQL_STATEMENT = "update Pregunta set Pregunta=@Pregunta, Imagen=@Imagen,ID_Nivel=@ID_Nivel,ID_TipoPregunta=@ID_TipoPregunta  where ID_Pregunta=@Id  update PreguntaCategoria set ID_Categoria=@ID_Categoria";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Pregunta", DbType.String, entity.LaPregunta);
                db.AddInParameter(cmd, "@Imagen", DbType.String, entity.Imagen);
                db.AddInParameter(cmd, "@ID_Nivel", DbType.Int32, entity.nivel.Id);
                db.AddInParameter(cmd, "@ID_Categoria", DbType.Int32, entity.categoria.Id);
                db.AddInParameter(cmd, "@Imagen", DbType.String, entity.Imagen);
                db.AddInParameter(cmd, "@ID_TipoPregunta", DbType.String, entity.tipoPregunta.Id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public List<Pregunta> ObtenerPreguntarAlAzarPorNivelYCategoria(Pregunta pregunta, int cantidad)
        {
           
             string SQL_STATEMENT = "select top " + cantidad + " p.ID_Pregunta,p.Pregunta,p.Imagen,p.ID_Nivel,p.ID_TipoPregunta,c.ID_Categoria from Pregunta as p inner join PreguntaCategoria as pc on p.ID_Pregunta=pc.ID_Pregunta where ID_Nivel=@Id_Nivel and Activo=1 and pc.ID_Categoria=@ID_categoria order by NEWID() ";

            List<Pregunta> result = new List<Pregunta>();
           
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id_Nivel", DbType.Int32, pregunta.nivel.Id);
                db.AddInParameter(cmd, "@Cantidad", DbType.Int32, cantidad);
                db.AddInParameter(cmd, "@ID_categoria", DbType.Int32, pregunta.categoria.Id);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Pregunta pr = LoadPregunta(dr);
                        result.Add(pr);
                    }
                }
            }
            return result;

        }

    }
}
