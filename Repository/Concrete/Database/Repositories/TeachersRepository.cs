using System;
using System.Collections.Generic;
using System.Text;
using Models.Entities.Concrete;
using Repository.Concrete.Database.Core;
using Repository.Abstract;
using System.Data;
using System.Data.Common;
using Models.Entities.Abstract;

namespace Repository.Concrete.Database.Repositories
{
    public class TeachersRepository : IRepository
    {
        string databaseTable = "Teachers";
        DbHelper dbManager = new DbHelper();
        //CRUD
        public bool Insert(IEntity teacher)
        {
            string commandText = "Insert into " + databaseTable + " (Id, FirstName, LastName, Faculty, Specialty, Salary, Dob) " +
                                 "values (@Id, @FirstName, @LastName, @Faculty, @Specialty, @Salary, @Dob);";
            var parameters = GetParametrs((Teacher)teacher);
            dbManager.CommandExecuteNonQuery(commandText, parameters);
            return true;
        }
        public bool Update(IEntity teacher)
        {
            string commandText = "Update " + databaseTable + " Set FirstName = @FirstName, " +
                "LastName = @LastName, " +
                "Faculty = @Faculty, " +
                "Specialty = @Specialty, " +
                "Salary = @Salary, " +
                "Dob = @Dob " +
                "Where Id = @Id;";
            var parameters = GetParametrs((Teacher)teacher);
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
            List<IEntity> teachers = new List<IEntity>();

            using (var connection = dbManager.CreateConnection())
            {
                connection.Open();
                var command = dbManager.CreateDbCommand(connection, commandText);
                DbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Teacher teacher = new Teacher();
                    teacher.Id = Convert.ToInt32(reader["Id"]);
                    teacher.FirstName = reader["FirstName"].ToString();
                    teacher.LastName = reader["LastName"].ToString();
                    teacher.Faculty = Convert.ToString(reader["Faculty"]);
                    teacher.Specialty = Convert.ToString(reader["Specialty"]);
                    teacher.Salary = Convert.ToDouble(reader["Salary"]);
                    teacher.Dob = Convert.ToDateTime(reader["Dob"]);
                    teachers.Add(teacher);
                }
                return teachers;
            }
        }

        public IEntity GetByID(long id)
        {
            var parameters = new List<IDbDataParameter>();
            parameters.Add(dbManager.CreateParameter("@Id", id, DbType.Int64));

            string commandText = "select * from " + databaseTable + " where Id = @Id;";
            var dataReader = dbManager.GetDataReader(commandText);
            try
            {
                var teacher = new Teacher();
                while (dataReader.Read())
                {
                    teacher.Id = Convert.ToInt64(dataReader["Id"]);

                }
                return teacher;
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
        public List<DbParameter> GetParametrs(Teacher teacher)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(dbManager.CreateParameter("@Id", teacher.Id, DbType.Int64));
            parameters.Add(dbManager.CreateParameter("@FirstName", 50, teacher.FirstName, DbType.String));
            parameters.Add(dbManager.CreateParameter("@LastName", 50, teacher.LastName, DbType.String));
            parameters.Add(dbManager.CreateParameter("@Faculty", 50, teacher.Faculty, DbType.String));
            parameters.Add(dbManager.CreateParameter("@Specialty", 50, teacher.Specialty, DbType.String));
            parameters.Add(dbManager.CreateParameter("@Salary", teacher.Salary, DbType.Double));
            parameters.Add(dbManager.CreateParameter("@Dob", teacher.Dob, DbType.DateTime));
            return parameters;
        }
    }
}
