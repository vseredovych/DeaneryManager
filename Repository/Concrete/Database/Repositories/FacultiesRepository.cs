using System;
using System.Collections.Generic;
using System.Text;
using Repository.Concrete.Database.Core;
using Repository.Abstract;
using System.Data.Common;
using System.Data;
using Models.Entities.Concrete;
using Models.Entities.Abstract;

namespace Repository.Concrete.Database.Repositories
{
    public class FacultiesRepository : IRepository
    {
        string databaseTable = "Faculties";
        DbHelper dbManager = new DbHelper();
        //CRUD
        public bool Insert(IEntity faculty)
        {
            string commandText = "Insert into " + databaseTable + " (Id, Name, Description) " +
                                 "values (@Id, @Name, @Description);";
            var parameters = GetParametrs((Faculty)faculty);
            dbManager.CommandExecuteNonQuery(commandText, parameters);
            return true;
        }
        public bool Update(IEntity faculty)
        {
            string commandText = "Update " + databaseTable + " Set Name = @Name, " +
                "Description = @Description " +
                "Where Id = @Id;";
            var parameters = GetParametrs((Faculty)faculty);
            dbManager.CommandExecuteNonQuery(commandText, parameters);
            return true;

        }
        public bool Delete(long id)
        {
            string commandText = "Delete from " + databaseTable + " where Id = @Id";
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(dbManager.CreateParameter("@Id", id, DbType.UInt32));
            dbManager.CommandExecuteNonQuery(commandText, parameters);
            return true;
        }
        public List<IEntity> GetAll()
        {
            string commandText = "Select * from " + databaseTable + ";";
            List<IEntity> faculties = new List<IEntity>();

            using (var connection = dbManager.CreateConnection())
            {
                connection.Open();
                var command = dbManager.CreateDbCommand(connection, commandText);
                DbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Faculty faculty = new Faculty();
                    faculty.Id = Convert.ToInt32(reader["Id"]);
                    faculty.Name = Convert.ToString(reader["Name"]);
                    faculty.Description = Convert.ToString(reader["Description"]);
                    faculties.Add(faculty);
                }
                return faculties;
            }
        }

        public IEntity GetByID(long id)
        {
            var parameters = new List<IDbDataParameter>();
            parameters.Add(dbManager.CreateParameter("@Id", id, DbType.Int64));

            string commandText = "select * from " + databaseTable + " where Id = @Id;";
            var dataReader = dbManager.GetDataReader(commandText, parameters);
            try
            {
                var faculty = new Faculty();
                while (dataReader.Read())
                {
                    faculty.Id = Convert.ToInt64(dataReader["Id"]);
                    faculty.Name = Convert.ToString(dataReader["Name"]);
                    faculty.Description = Convert.ToString(dataReader["Description"]);
                }
                return faculty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dataReader.Close();
            }
        }
        public long GetScalarValue(string commandText)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            object scalarValue = dbManager.GetScalarValue(commandText, parameters);
            return Convert.ToInt64(scalarValue);
        }
        public List<DbParameter> GetParametrs(Faculty faculty)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(dbManager.CreateParameter("@Id", faculty.Id, DbType.Int64));
            parameters.Add(dbManager.CreateParameter("@Name", 50, faculty.Name, DbType.String));
            parameters.Add(dbManager.CreateParameter("@Description", 50, faculty.Description, DbType.String));
            return parameters;
        }
    }
}
