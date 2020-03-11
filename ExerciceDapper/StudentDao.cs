using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using Dapper;
using System.Data;
using System;

namespace ExerciceDapper
{
	public class StudentDao: IStudentDao<Student>
	{
		private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(typeof(StudentDao));

		/// <exception cref="ArgumentNullException">throw</exception>
		/// <exception cref="InvalidOperationException">throw</exception>
		public Student Create(Student student)
		{
			try
			{
				using (var connection = new SqlConnection(Resources.StringConnection))
				{
					var id = SqlMapper.Query<int>(connection,
						"INSERT INTO Student VALUES(@Name, @Surname, @DateOfBirth); SELECT CAST(SCOPE_IDENTITY() as int)",
						new { student.Name, student.Surname, student.DateOfBirth }).Single();

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

		/// <exception cref="ArgumentNullException"></exception>
		public List<Student> Read()
		{
			try
			{
				using (IDbConnection connection = new SqlConnection(Resources.StringConnection))
				{
					return SqlMapper.Query<Student>(connection, "SELECT * FROM Student").ToList();
				}
			}
			catch (ArgumentNullException ane)
			{
				logger.Error("Error: " + ane.Message);
				logger.Error("Trace: " + ane.StackTrace);
				throw;
			}
		}

		/// <exception cref="ArgumentNullException"></exception>
		/// <exception cref="InvalidOperationException"></exception>
		public Student Update(Student student)
		{
			try
			{
				using (IDbConnection connection = new SqlConnection(Resources.StringConnection))
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

		/// <exception cref="ArgumentNullException"></exception>
		/// <exception cref="InvalidOperationException"></exception>
		public bool Delete(Student student)
		{
			try
			{
				using (IDbConnection connection = new SqlConnection(Resources.StringConnection))
				{
					var result = SqlMapper.Query<Student>(connection, "SELECT * FROM Student WHERE Id = @id", new { student.Id }).SingleOrDefault();
					connection.Query<Student>("DELETE FROM Student WHERE Id = @Id", new { student.Id });
					return result != null;
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
