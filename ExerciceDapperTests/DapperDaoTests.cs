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
	public class DapperDaoTests
	{
		[TestMethod()]
		public void ReadTest()
		{
			StudentDao dapper = new StudentDao();
			var result = dapper.Read();
			Assert.IsTrue(result.Count() > 0);
		}
	}
}