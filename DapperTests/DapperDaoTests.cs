using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
	}
}