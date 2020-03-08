using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace EntityFrameworkDatabaseFirst.Tests
{
	[TestClass()]
	public class StudentDaoTests
	{

		public static StudentDao studentDao;
		public static Student student;
		[TestMethod()]
		public void CreateDefaultTest()
		{
			studentDao = new StudentDao();
			student = new Student();
			student.Name = "David"; student.Surname = "Jiménez";
			student.DateOfBirth = new DateTime(1992, 6, 24);
			var spected = studentDao.Create(student);
			Assert.AreEqual(spected, student);
		}
	}
		
}