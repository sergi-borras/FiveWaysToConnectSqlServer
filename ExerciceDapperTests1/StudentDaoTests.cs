using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExerciceDapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciceDapper.Tests
{
	[TestClass()]
	public class StudentDaoTests
	{
		[TestMethod()]
		public void CreateTest()
		{
			StudentDao studentDao = new StudentDao();
			Student student = new Student();
			student.Name = "Teresa";
			student.Surname = "Calvo";
			student.DateOfBirth = new DateTime(1996, 11, 29);
			var spected = studentDao.Create(student);
			Assert.IsTrue(spected != null);
		}

		[TestMethod()]
		public void ReadTest()
		{
			StudentDao dapper = new StudentDao();
			var result = dapper.Read();
			Assert.IsTrue(result.Count() > 0);
		}

		[TestMethod()]
		public void UpdateTest()
		{
			StudentDao studentDao = new StudentDao();
			Student student = new Student();
			student.Id = 1;
			student.Name = "Teresa";
			student.Surname = "Calvo";
			student.DateOfBirth = new DateTime(1996, 11, 29);
			var spected = studentDao.Update(student);
			Assert.IsTrue(spected != null);
		}

		[TestMethod()]
		public void DeleteTest()
		{
			StudentDao studentDao = new StudentDao();
			Student student = new Student();
			student.Id = 7;
			var result = studentDao.Delete(student);
			Assert.IsTrue(result);
		}
	}
}