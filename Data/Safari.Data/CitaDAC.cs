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
    public class CitaDAC : DataAccessComponent, IRepository<Cita>
    {
        public Cita Create(Cita entity)
        {
            const string SQL_STATEMENT = "insert into Cita (Fecha,MedicoId,PacienteId,SalaId,TipoServicioId,Estado)values(@fecha,@MedicoId,@PacienteId,@SalaId,@TipoServicioId,@Estado); SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@fecha", DbType.DateTime, entity.fecha);
                db.AddInParameter(cmd, "@MedicoId", DbType.Int32, entity.medico);
                db.AddInParameter(cmd, "@PacienteId", DbType.Int32, entity.Paciente);
                db.AddInParameter(cmd, "@SalaId", DbType.Int32, entity.sala);
                db.AddInParameter(cmd, "@TipoServicioId", DbType.Int32, entity.tipoServicio);
                db.AddInParameter(cmd, "@Estado", DbType.String, entity.estado);
                db.AddInParameter(cmd, "@CreatedBy", DbType.Int32, entity.createBy);
                db.AddInParameter(cmd, "@CreateDate", DbType.DateTime, entity.createDate);


                entity.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            return entity;
        }

        public void Delete(int id)
        {
            const string SQL_STATEMENT = "update cita set Deleted=1 where Id=1";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public List<Cita> Read()
        {
            const string SQL_STATEMENT = "select * from cita where Deleted=0";

            List<Cita> result = new List<Cita>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Cita cita = LoadCita(dr);
                        result.Add(cita);
                    }
                }
            }
            return result;
        }

        public Cita ReadBy(int id)
        {
            const string SQL_STATEMENT = "select * from cita ";
            Cita cita = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        cita = LoadCita(dr);
                    }
                }
            }
            return cita;
        }

        public void Update(Cita entity)
        {
            const string SQL_STATEMENT = "update Cita set Fecha=@Fecha , MedicoId=@MedicoIF,PacienteId=@PacienteId,SalaId=@SalaId,TipoServicioId=@TipoServicioId,Estado=@Estado,ChangedBy=@ChangeBy,ChangedDate=@ChangeDate  WHERE [Id]= @Id ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, entity.Id);
                db.AddInParameter(cmd, "@fecha", DbType.DateTime, entity.fecha);
                db.AddInParameter(cmd, "@MedicoId", DbType.Int32, entity.medico);
                db.AddInParameter(cmd, "@PacienteId", DbType.Int32, entity.Paciente);
                db.AddInParameter(cmd, "@SalaId", DbType.Int32, entity.sala);
                db.AddInParameter(cmd, "@TipoServicioId", DbType.Int32, entity.tipoServicio);
                db.AddInParameter(cmd, "@Estado", DbType.String, entity.estado);
                db.AddInParameter(cmd, "@ChangeBy", DbType.Int32,2);
                db.AddInParameter(cmd, "@ChangeDate", DbType.DateTime, DateTime.Now);
                db.ExecuteNonQuery(cmd);
            }
        }

        private Cita LoadCita(IDataReader dr)
        {
            Cita cita = new Cita();
            cita.Id = GetDataValue<int>(dr, "Id");
            cita.fecha = GetDataValue<DateTime>(dr, "Fecha");
            cita.medico = GetDataValue<int>(dr, "MedicoId");
            cita.Paciente = GetDataValue<int>(dr, "PacienteId");
            cita.sala = GetDataValue<int>(dr, "SalaId");
            cita.tipoServicio = GetDataValue<int>(dr, "TipoServicioId");
            cita.estado = GetDataValue<string>(dr, "Estado");
            return cita;
        }
    }
}
