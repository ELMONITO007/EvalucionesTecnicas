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
    public class CategoriaDAC : DataAccessComponent, IRepository<Categoria>
    {
        public Categoria Create(Categoria entity)
        {
            const string SQL_STATEMENT = "insert into categoria(Categoria,Descripcion,Activo)values(@Categoria,@Descripcion,1) ";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Categoria", DbType.String, entity.LaCategoria);
                db.AddInParameter(cmd, "@Descripcion", DbType.String, entity.Descripcion);
                entity.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }


            return entity;
        }

        public void Delete(int id)
        {
            const string SQL_STATEMENT = "update Categoria set Active=0 where Id=@Id";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public List<Categoria> Read()
        {
            throw new NotImplementedException();
        }

        public Categoria ReadBy(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Categoria entity)
        {
            throw new NotImplementedException();
        }
    }
}
