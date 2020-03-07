using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDAO
{
    public class StudentDao
    {
        private readonly Connection connection = new Connection();
        public void Create(Student student)
        {
            CommandSql command = new CommandSql(Resources.createQuery, connection);
            command.Command.Parameters.AddWithValue(Resources.nameQueryParam, student.Name);
            command.Command.Parameters.AddWithValue(Resources.surnameQueryParam, student.Surname);
            command.Command.Parameters.AddWithValue(Resources.birthDateQueryParam, student.Birthdate);
            connection.OpenConnection();
            var result = command.Command.ExecuteNonQuery();
            connection.CloseConnection();
        }
        public Student SelectStudentById(int id)
        {
            Student result = new Student();
            connection.OpenConnection();
            CommandSql command = new CommandSql(Resources.selectByIdQuery, connection);
            command.Command.Parameters.AddWithValue(Resources.idQueryParam, id);
            using (SqlDataReader reader = command.Command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Id = int.Parse(reader[0].ToString());
                    result.Name = reader[1].ToString();
                    result.Surname = reader[2].ToString();
                    result.Birthdate = DateTime.Parse(reader[3].ToString());
                }
            }
            connection.CloseConnection();
            return result;
        }
    }
}
