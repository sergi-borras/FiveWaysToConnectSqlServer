using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace ExerciceDapper.Tests
{
	[TestClass()]
	public class StudentDaoTests
	{
		public static StudentDao studentDao;
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
		[TestMethod()]
		public void CreateTest()
		{
			Student studentToCreate = new Student("David", "Jimenez", new DateTime(1992, 6, 24));
			var spected = studentDao.Create(studentToCreate);
			Assert.IsTrue(spected != null);
		}

		[TestMethod()]
		public void ReadTest()
		{
			var result = studentDao.Read();
			Assert.IsTrue(result.Count() > 0);
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

		[TestMethod()]
		public void DeleteTest()
		{
			Student studentToDelete = new Student();
			studentToDelete.Id = 2;
			var result = studentDao.Delete(studentToDelete);
			Assert.IsTrue(result);
		}
	}
}