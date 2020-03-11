using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace ExerciceDapper.Tests
{
	[TestClass()]
	public class StudentDaoIntegrationTests
	{		
		public static StudentDao studentDao;

		[TestInitialize]
		public void Setup()
		{
			studentDao = new StudentDao();
			Student student1 = new Student("Name1", "Surname1", DateTime.Now);
			Student student2 = new Student("Name2", "Surname2", DateTime.Now);
			studentDao.Create(student1);
			studentDao.Create(student2);
		}
		[TestCleanup]
		public void TearDown()
		{
			string query = "TRUNCATE TABLE Student";

			using (SqlConnection connnection = new SqlConnection("Server=localhost,1433;Database=Vueling;User Id=sa;Password=yourStrong(!)Password"))
			using (SqlCommand command = new SqlCommand(query, connnection))
			{
				connnection.Open();
				command.ExecuteNonQuery();
			}
			
		}

		[TestMethod()]
		public void CreateTest()
		{
			Student studentToCreate = new Student("David", "Jimenez", new DateTime(1992, 6, 24));
			var spected = studentDao.Create(studentToCreate);
			studentToCreate.Id = 3;
			Assert.AreEqual(spected, studentToCreate);
		}

		[TestMethod]
		[ExpectedException(typeof(NullReferenceException))]
		public void CreateWithNullValueThrowsNullReferenceException()
		{
			var spected = studentDao.Create(null);
		}

		[TestMethod()]
		public void ReadTest()
		{
			var result = studentDao.Read();
			Assert.IsTrue(result.Count() == 2);
		}

		[TestMethod()]
		public void UpdateTest()
		{
			Student studentToUpdate = new Student();
			studentToUpdate.Id = 1;
			studentToUpdate.Name = "Update";
			studentToUpdate.Surname = "Row";
			studentToUpdate.DateOfBirth = new DateTime(1996, 11, 29);
			var spected = studentDao.Update(studentToUpdate);
			Assert.IsTrue(spected != null);
		}

		[TestMethod]
		[ExpectedException(typeof(NullReferenceException))]
		public void UpdateWithNullValueThrowsNullReferenceException()
		{
			var spected = studentDao.Update(null);
		}

		[TestMethod()]
		public void DeleteTest()
		{
			Student studentToDelete = new Student();
			studentToDelete.Id = 2;
			var spected = studentDao.Delete(studentToDelete);
			var result = spected && studentDao.Read().Count() == 1;
			Assert.IsTrue(result);
		}

		[TestMethod]
		[ExpectedException(typeof(NullReferenceException))]
		public void DeleteWithNullValueThrowsNullReferenceException()
		{
			var spected = studentDao.Delete(null);
		}
	}
}