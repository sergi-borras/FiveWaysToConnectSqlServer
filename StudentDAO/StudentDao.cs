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
        public void Create(Student student)
        {
            using (SqlConnection connection = new SqlConnection(Resources.sqlConnection))
            {
                SqlCommand command = new SqlCommand(Resources.createQuery, connection);
                command.Parameters.AddWithValue(Resources.nameQueryParam, student.Name);
                command.Parameters.AddWithValue(Resources.surnameQueryParam, student.Surname);
                command.Parameters.AddWithValue(Resources.birthDateQueryParam, student.Birthdate);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public void Update(Student student, int id)
        {
            using (SqlConnection connection = new SqlConnection(Resources.sqlConnection))
            {
                SqlCommand command = new SqlCommand(Resources.updateQuery, connection);
                command.Parameters.AddWithValue(Resources.idQueryParam, id);
                command.Parameters.AddWithValue(Resources.nameQueryParam, student.Name);
                command.Parameters.AddWithValue(Resources.surnameQueryParam, student.Surname);
                command.Parameters.AddWithValue(Resources.birthDateQueryParam, student.Birthdate);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(Resources.sqlConnection))
            {
                SqlCommand command = new SqlCommand(Resources.deleteQuery, connection);
                command.Parameters.AddWithValue(Resources.idQueryParam, id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public List<Student> Read()
        {
            List<Student> result = new List<Student>();
            using (SqlConnection connection = new SqlConnection(Resources.sqlConnection))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(Resources.selectAllQuery, connection))
                {
                    var reader = command.ExecuteReader();

                    int ordId = reader.GetOrdinal("StudentId");
                    int ordName = reader.GetOrdinal("Name");
                    int ordSurname = reader.GetOrdinal("Surname");
                    int ordBirthdate = reader.GetOrdinal("Birthday");

                    while (reader.Read())
                    {
                        Student student = new Student
                        {
                            Id = reader.GetInt32(ordId),
                            Name = reader.GetString(ordName),
                            Surname = reader.GetString(ordSurname),
                            Birthdate = reader.GetDateTime(ordBirthdate)
                        };
                        result.Add(student);
                    }
                    return result;
                }
            }
        }
        public Student SelectStudentById(int id)
        {
            Student result = new Student();
            using (SqlConnection connection = new SqlConnection(Resources.sqlConnection))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(Resources.selectByIdQuery, connection))
                {
                    command.Parameters.AddWithValue(Resources.idQueryParam, id);

                    var reader = command.ExecuteReader();

                    int ordId = reader.GetOrdinal("StudentId");
                    int ordName = reader.GetOrdinal("Name");
                    int ordSurname = reader.GetOrdinal("Surname");
                    int ordBirthdate = reader.GetOrdinal("Birthday");

                    if (!reader.Read())
                        return null;

                    result.Id = reader.GetInt32(ordId);
                    result.Name = reader.GetString(ordName);
                    result.Surname = reader.GetString(ordSurname);
                    result.Birthdate = reader.GetDateTime(ordBirthdate);

                    return result;
                }
            }
        }
    }
}
