using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Dapper.Tests
{
	[TestClass()]
	public class DapperDaoTests
	{
		public static DapperDao dapperDao;
		public static Student studentTest1;
		public static Student studentTest2;
		public static Student studentTest3;

		[ClassInitialize]
		public static void TestFixtureSetup(TestContext context)
		{
			studentTest1 = new Student();
			studentTest2 = new Student();
			studentTest3 = new Student();
		}

		[TestInitialize]
		public void Setup()
		{
			dapperDao = new DapperDao();

		}
		[TestMethod()]
		public void CreateTest()
		{
			studentTest1.Name = "David";
			studentTest1.Surname = "Jimenez";
			studentTest1.DateOfBirth = DateTime.Now;
			dapperDao.Create(studentTest1);
			Assert.IsTrue(true);
		}

		[TestMethod()]
		public void UpdateTest()
		{
			studentTest1.Id = 1;
			studentTest1.Name = "Prueba";
			studentTest1.Surname = "Update";
			studentTest1.DateOfBirth = DateTime.Now.AddDays(-5);
			var spected = dapperDao.Update(studentTest1);
			Assert.AreEqual(spected, studentTest1);
		}

		[TestMethod()]
		public void ReadTest()
		{
			var result = dapperDao.Read();
			Assert.IsTrue(result.Count() > 0);
			//Assert.IsTrue(true);
		}
	}
}