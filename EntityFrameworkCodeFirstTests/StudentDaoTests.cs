using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntityFrameworkCodeFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCodeFirst.Tests
{
	[TestClass()]
	public class StudentDaoTests
	{
		public static Student student;
		public static StudentDao studentDao;
		[TestMethod()]
		public void CreateTest()
		{
			studentDao = new StudentDao();
			student = new Student(1, "David", "Jimenez", new DateTime(1992, 6, 24));
			var spected = studentDao.Create(student);
			Assert.Equals(spected, student);
		}
	}
}