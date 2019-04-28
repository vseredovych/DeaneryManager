using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using Models.Entities;
using Repository.Abstract;
using Repository.Core;

namespace Repository.Concrete.Operations
{
    class facultysRepository : IFacultiesRepository
    {
        string databaseTable = "faculties";
        DbHelper dbManager = new DbHelper();
        //CRUD
        public void Insert(Faculty faculty)
        {
            string commandText = "Insert into " + databaseTable + " (Id, Name, Description)" +
                                 "values (@Id, @Name, @Description);";
            var parameters = GetParametrs(faculty);
            dbManager.CommandExecuteNonQuery(commandText, parameters);
         
        }
        public void Update(Faculty faculty)
        {
            string commandText = "Update " + databaseTable + " Set Name = @Name, " +
                "Description = @Description, " +
                "Where Id = @Id;";
            var parameters = GetParametrs(faculty);
            dbManager.CommandExecuteNonQuery(commandText, parameters);
        }
        public void Delete(Faculty faculty)
        {
            string commandText = "Delete from " + databaseTable + " where Id = @Id";
            var parameters = GetParametrs(faculty);
            dbManager.CommandExecuteNonQuery(commandText, parameters);
        }

        public void Delete(long id)
        {
            string commandText = "Delete from " + databaseTable + " where Id = @Id";
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(dbManager.CreateParameter("@Id", id, DbType.UInt32));
            dbManager.CommandExecuteNonQuery(commandText, parameters);
        }

        public ObservableCollection<Faculty> GetAll()
        {
            string commandText = "Select * from " + databaseTable + ";";
            ObservableCollection<Faculty> facultys = new ObservableCollection<Faculty>();

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
                    facultys.Add(faculty);
                }
                return facultys;
            }
        }

        public Faculty GetByID(long id)
        {
            var parameters = new List<IDbDataParameter>();
            parameters.Add(dbManager.CreateParameter("@Id", id, DbType.Int64));

            string commandText = "select * from " + databaseTable + " where Id = @Id;";
            var dataReader = dbManager.GetDataReader(commandText);
            try
            {
                var faculty = new Faculty();
                while (dataReader.Read())
                {
                    faculty.Id = Convert.ToInt64(dataReader["Id"]);
                    
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