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
    public class StudentsRepository : IRepository
    {
        string databaseTable = "Students";
        DbHelper dbManager = new DbHelper();
        //CRUD
        public bool Insert(IEntity student)
        {
            string commandText = "Insert into " + databaseTable + " (Id, FirstName, LastName, Faculty, Scholarship, Dob) " +
                                 "values (@Id, @FirstName, @LastName, @Faculty, @Scholarship, @Dob);";
            var parameters = GetParametrs((Student)student);
            dbManager.CommandExecuteNonQuery(commandText, parameters);
            return true;
        }
        public bool Update(IEntity student)
        {
            string commandText = "Update " + databaseTable + " Set FirstName = @FirstName, " +
                "LastName = @LastName, " +
                "Faculty = @Faculty, " +
                "Scholarship = @Scholarship, " +
                "Dob = @Dob " +
                "Where Id = @Id;";
            var parameters = GetParametrs((Student)student);
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
            List<IEntity> students = new List<IEntity>();

            using (var connection = dbManager.CreateConnection())
            {
                connection.Open();
                var command = dbManager.CreateDbCommand(connection, commandText);
                DbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Student student = new Student();
                    student.Id = Convert.ToInt32(reader["Id"]);
                    student.FirstName = reader["FirstName"].ToString();
                    student.LastName = reader["LastName"].ToString();
                    student.Faculty = Convert.ToString(reader["Faculty"]);
                    student.Scholarship = Convert.ToDouble(reader["Scholarship"]);
                    student.Dob = Convert.ToDateTime(reader["Dob"]);
                    students.Add(student);
                }
                return students;
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
                var student = new Student();
                while (dataReader.Read())
                {
                    student.Id = Convert.ToInt64(dataReader["Id"]);
                    student.FirstName = dataReader["FirstName"].ToString();
                    student.LastName = dataReader["LastName"].ToString();
                    student.Faculty = Convert.ToString(dataReader["Faculty"]);
                    student.Scholarship = Convert.ToDouble(dataReader["Scholarship"]);
                    student.Dob = Convert.ToDateTime(dataReader["Dob"]);
                }
                return student;
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
        public List<DbParameter> GetParametrs(Student student)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(dbManager.CreateParameter("@Id", student.Id, DbType.Int64));
            parameters.Add(dbManager.CreateParameter("@FirstName", 50, student.FirstName, DbType.String));
            parameters.Add(dbManager.CreateParameter("@LastName", 50, student.LastName, DbType.String));
            parameters.Add(dbManager.CreateParameter("@Faculty", 50, student.Faculty, DbType.String));
            parameters.Add(dbManager.CreateParameter("@Scholarship", student.Scholarship, DbType.Double));
            parameters.Add(dbManager.CreateParameter("@Dob", student.Dob, DbType.DateTime));
            return parameters;
        }
    }
}
