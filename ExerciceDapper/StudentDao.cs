using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using Dapper;
using System.Data;
using System;

namespace ExerciceDapper
{
	public class StudentDao
	{
		private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(typeof(StudentDao));

		public Student Create(Student studentToCreate)
		{
			try
			{
				using (var connection = new SqlConnection("Server=localhost,1433;Database=Vueling;User Id=sa;Password=yourStrong(!)Password"))
				{
					var id = SqlMapper.Query<int>(connection,
						"INSERT INTO Student VALUES(@Name, @Surname, @DateOfBirth); SELECT CAST(SCOPE_IDENTITY() as int)",
						new { studentToCreate.Name, studentToCreate.Surname, studentToCreate.DateOfBirth }).Single();

					return SqlMapper.Query<Student>(connection, "SELECT * FROM Student WHERE Id = @Id", new { id }).Single();
				}
			}
			catch (ArgumentNullException ane)
			{
				logger.Error("Error: " + ane.Message);
				logger.Error("Trace: " + ane.StackTrace);
				throw;
			}
			catch (InvalidOperationException ioe)
			{
				logger.Error("Error: " + ioe.Message);
				logger.Error("Trace: " + ioe.StackTrace);
				throw;
			}
		}

		public List<Student> Read()
		{
			try
			{
				using (IDbConnection connection = new SqlConnection("Server=localhost,1433;Database=Vueling;User Id=sa;Password=yourStrong(!)Password"))
				{
					return SqlMapper.Query<Student>(connection, "SELECT * FROM Student").ToList();
				}
			}
			catch (System.ArgumentNullException ane)
			{
				logger.Error("Error: " + ane.Message);
				logger.Error("Trace: " + ane.StackTrace);
				throw;
			}
		}

		public Student Update(Student student)
		{
			try
			{
				using (IDbConnection connection = new SqlConnection("Server=localhost,1433;Database=Vueling;User Id=sa;Password=yourStrong(!)Password"))
				{
					connection.Query<Student>("UPDATE Student set Name = @Name , Surname = @Surname, DateOfBirth = @DateOfBirth WHERE Id = @Id",
						new { student.Name, student.Surname, student.DateOfBirth, student.Id });

					return SqlMapper.Query<Student>(connection, "SELECT * FROM Student WHERE id = @id", new { student.Id }).Single();
				}
			}
			catch (ArgumentNullException ane)
			{
				logger.Error("Error: " + ane.Message);
				logger.Error("Trace: " + ane.StackTrace);
				throw;
			}
			catch (InvalidOperationException ioe)
			{
				logger.Error("Error: " + ioe.Message);
				logger.Error("Trace: " + ioe.StackTrace);
				throw;
			}
		}

		public bool Delete(Student student)
		{
			try
			{
				using (IDbConnection connection = new SqlConnection("Server=localhost,1433;Database=Vueling;User Id=sa;Password=yourStrong(!)Password"))
				{
					connection.Query<Student>("DELETE FROM Student WHERE Id = @Id", new { student.Id });
					var result = SqlMapper.Query<Student>(connection, "SELECT * FROM Student WHERE Id = @id", new { student.Id }).SingleOrDefault();
					return result == null;
				}
			}
			catch (ArgumentNullException ane)
			{
				logger.Error("Error: " + ane.Message);
				logger.Error("Trace: " + ane.StackTrace);
				throw;
			}
			catch (InvalidOperationException ioe)
			{
				logger.Error("Error: " + ioe.Message);
				logger.Error("Trace: " + ioe.StackTrace);
				throw;
			}

		}

	}
}
