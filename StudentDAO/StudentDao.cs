using System;
using System.IO;
using System.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;

namespace StudentDAO
{
    public class StudentDao
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(StudentDao));
        private static readonly string connectionString =
            ConfigurationManager.ConnectionStrings["SQLServerConnectionString"].ConnectionString;
        private static readonly Stopwatch stopWatch = new Stopwatch();
        public Student Create(Student student)
        {
            stopWatch.Start();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(Resources.createQuery, connection);
                command.Parameters.AddWithValue(Resources.nameQueryParam, student.Name);
                command.Parameters.AddWithValue(Resources.surnameQueryParam, student.Surname);
                command.Parameters.AddWithValue(Resources.birthDateQueryParam, student.Birthdate);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();

                    stopWatch.Stop();
                    log.Info("Run Time: " + stopWatch.Elapsed);
                    return student;
                }
                catch (InvalidOperationException ex)
                {
                    log.Error(ex);
                    throw;
                }
                catch (SqlException ex)
                {
                    log.Error(ex);
                    throw;
                }
                catch (ConfigurationErrorsException ex)
                {
                    log.Error(ex);
                    throw;
                }
                catch (InvalidCastException ex)
                {
                    log.Error(ex);
                    throw;
                }
                catch (IOException ex)
                {
                    log.Error(ex);
                    throw;
                }
            }
        }
        public Student Update(Student student, int id)
        {
            stopWatch.Start();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(Resources.updateQuery, connection);
                command.Parameters.AddWithValue(Resources.idQueryParam, id);
                command.Parameters.AddWithValue(Resources.nameQueryParam, student.Name);
                command.Parameters.AddWithValue(Resources.surnameQueryParam, student.Surname);
                command.Parameters.AddWithValue(Resources.birthDateQueryParam, student.Birthdate);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();

                    stopWatch.Stop();
                    log.Info("Run Time: " + stopWatch.Elapsed);
                    return student;
                }
                catch (InvalidOperationException ex)
                {
                    log.Error(ex);
                    throw;
                }
                catch (SqlException ex)
                {
                    log.Error(ex);
                    throw;
                }
                catch (ConfigurationErrorsException ex)
                {
                    log.Error(ex);
                    throw;
                }
                catch (InvalidCastException ex)
                {
                    log.Error(ex);
                    throw;
                }
                catch (IOException ex)
                {
                    log.Error(ex);
                    throw;
                }
            }
        }
        public void Delete(int id)
        {
            stopWatch.Start();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(Resources.deleteQuery, connection);
                command.Parameters.AddWithValue(Resources.idQueryParam, id);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();

                    stopWatch.Stop();
                    log.Info("Run Time: " + stopWatch.Elapsed);
                }
                catch (InvalidOperationException ex)
                {
                    log.Error(ex);
                    throw;
                }
                catch (SqlException ex)
                {
                    log.Error(ex);
                    throw;
                }
                catch (ConfigurationErrorsException ex)
                {
                    log.Error(ex);
                    throw;
                }
                catch (InvalidCastException ex)
                {
                    log.Error(ex);
                    throw;
                }
                catch (IOException ex)
                {
                    log.Error(ex);
                    throw;
                }
            }
        }
        public List<Student> Read()
        {
            stopWatch.Start();
            List<Student> result = new List<Student>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
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

                        stopWatch.Stop();
                        log.Info("Run Time: " + stopWatch.Elapsed);

                        return result;
                    }
                }
                catch (InvalidOperationException ex)
                {
                    log.Error(ex);
                    throw;
                }
                catch (SqlException ex)
                {
                    log.Error(ex);
                    throw;
                }
                catch (ConfigurationErrorsException ex)
                {
                    log.Error(ex);
                    throw;
                }
                catch (InvalidCastException ex)
                {
                    log.Error(ex);
                    throw;
                }
                catch (IOException ex)
                {
                    log.Error(ex);
                    throw;
                }
            }
        }
        public Student SelectStudentById(int id)
        {
            stopWatch.Start();
            Student result = new Student();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
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

                        stopWatch.Stop();
                        log.Info("Run Time: " + stopWatch.Elapsed);

                        return result;
                    }
                }
                catch (InvalidOperationException ex)
                {
                    log.Error(ex);
                    throw;
                }
                catch (SqlException ex)
                {
                    log.Error(ex);
                    throw;
                }
                catch (ConfigurationErrorsException ex)
                {
                    log.Error(ex);
                    throw;
                }
                catch (InvalidCastException ex)
                {
                    log.Error(ex);
                    throw;
                }
                catch (IOException ex)
                {
                    log.Error(ex);
                    throw;
                }
            }
        }
        public void DeleteAll()
        {
            stopWatch.Start();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(Resources.deleteAllQuery, connection);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();

                    stopWatch.Stop();
                    log.Info("Run Time: " + stopWatch.Elapsed);
                }
                catch (InvalidOperationException ex)
                {
                    log.Error(ex);
                    throw;
                }
                catch (SqlException ex)
                {
                    log.Error(ex);
                    throw;
                }
                catch (ConfigurationErrorsException ex)
                {
                    log.Error(ex);
                    throw;
                }
                catch (InvalidCastException ex)
                {
                    log.Error(ex);
                    throw;
                }
                catch (IOException ex)
                {
                    log.Error(ex);
                    throw;
                }
            }
        }
    }
}
