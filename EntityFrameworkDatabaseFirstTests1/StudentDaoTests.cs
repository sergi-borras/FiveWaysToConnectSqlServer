using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntityFrameworkDatabaseFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
			student.Name = "DDD"; student.Surname = "JJJ";
			student.DateOfBirth = new DateTime(1992, 6, 24);
			var spected = studentDao.Create(student);
			Assert.AreEqual(spected, student);
		}

	}
}