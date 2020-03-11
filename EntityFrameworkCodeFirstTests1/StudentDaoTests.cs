using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntityFrameworkCodeFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Data.SqlClient;

namespace EntityFrameworkCodeFirst.Tests
{
	[TestClass()]
	public class StudentDaoTests
	{
		public static StudentDao studentDao;
		public static Student student;
		[TestInitialize]
		public void Setup()
		{
			studentDao = new StudentDao();
			Student student1 = new Student("Name1", "Surname1", new DateTime(2001, 01, 01));
			Student student2 = new Student("Name2", "Surname2", new DateTime(2002, 02, 02));
			Student student3 = new Student("Name3", "Surname3", new DateTime(2003, 03, 03));
			Student student4 = new Student("Name4", "Surname4", new DateTime(2004, 04, 04));
			studentDao.Create(student1);
			studentDao.Create(student2);
			studentDao.Create(student3);
			studentDao.Create(student4);
		}

		[TestCleanup]
		public void TearDown()
		{
			string query = "TRUNCATE TABLE [Vueling].[dbo].[Student]";
			using (var connection = new SqlConnection("Server=localhost,1433;Database=Vueling;User Id=sa;Password=yourStrong(!)Password"))
			{
				connection.Open();
				SqlCommand cmd = new SqlCommand(query, connection);
				cmd.ExecuteNonQuery();
			}
		}

		[TestMethod()]
		public void CreateDefaultTest()
		{
			var studentToCreate = new Student("David", "Jimenez", new DateTime(1992, 6, 24));
			var spected = studentDao.Create(studentToCreate);
			Assert.AreEqual(spected, studentToCreate);
		}

		[TestMethod()]
		public void ReadTest()
		{
			var result = studentDao.Read();
			Assert.IsTrue(result != null);
		}
		[TestMethod()]
		public void ReadWithValuesTest()
		{
			var result = studentDao.Read();
			Assert.IsTrue(result.Count() > 0);
		}

		[TestMethod()]
		public void UpdateTest()
		{
			var studentToUpdate = new Student("D", "J", new DateTime(2000, 10, 10));
			studentToUpdate.Id = 1;
			var spected = studentDao.Update(studentToUpdate);
			Assert.AreEqual(spected.ToString(), studentToUpdate.ToString());
		}

		[TestMethod()]
		public void DeleteTest()
		{
			var studentToDelete = new Student();
			studentToDelete.Id = 2;
			var result = studentDao.Delete(studentToDelete);
			Assert.IsTrue(result);
		}
	}
}