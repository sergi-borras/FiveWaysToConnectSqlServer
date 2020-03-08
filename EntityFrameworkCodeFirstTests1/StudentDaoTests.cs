using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntityFrameworkCodeFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace EntityFrameworkCodeFirst.Tests
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
			student = new Student(1, "David", "Jimenez", new DateTime(1992, 6, 24));
			var spected = studentDao.Create(student);
			Assert.AreEqual(spected, student);
		}

		[TestMethod()]
		public void ReadTest()
		{
			studentDao = new StudentDao();
			var result = studentDao.Read();
			Assert.IsTrue(result != null);
		}
		[TestMethod()]
		public void ReadWithValuesTest()
		{
			studentDao = new StudentDao();
			var result = studentDao.Read();
			Assert.IsTrue(result.Count() > 0);
		}

		[TestMethod()]
		public void UpdateTest()
		{
			studentDao = new StudentDao();
			student = new Student(1, "D", "J", new DateTime(2000, 10, 10));
			var spected = studentDao.Update(student);
			Assert.AreEqual(student.ToString(), student.ToString());
		}

		[TestMethod()]
		public void DeleteTest()
		{
			studentDao = new StudentDao();
			student = new Student();
			student.Id = 7;
			var result = studentDao.Delete(student);
			Assert.IsTrue(result);
		}
	}
}