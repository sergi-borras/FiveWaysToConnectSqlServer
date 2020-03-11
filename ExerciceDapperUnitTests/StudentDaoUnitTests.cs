using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExerciceDapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace ExerciceDapper.Tests
{
	[TestClass()]
	public class StudentDaoUnitTests
	{
		public static Mock<IStudentDao<Student>> mockObject;
		public static StudentDao studentDao;
		public static Student inputStudentWithId;
		public static Student inputStudent;
		public static Student outputStudent;

		[TestInitialize]
		public void Setup()
		{
			mockObject = new Mock<IStudentDao<Student>>();
			studentDao = new StudentDao();
			inputStudent = new Student("David", "Jimenez", new DateTime(1992, 6, 24));
			inputStudentWithId = new Student("Prueba", "Update", DateTime.Now);
			inputStudentWithId.Id = 1;
			outputStudent = inputStudent;
			outputStudent.Id = 1;

			mockObject.Setup(x => x.Create(inputStudent)).Returns(outputStudent);
			mockObject.Setup(x => x.Create(null)).Throws<NullReferenceException>();
			mockObject.Setup(x => x.Read()).Returns(new List<Student>());
			mockObject.Setup(x => x.Update(inputStudentWithId)).Returns(inputStudentWithId);
			mockObject.Setup(x => x.Update(null)).Throws<NullReferenceException>();
			mockObject.Setup(x => x.Delete(inputStudentWithId)).Returns(true);
			mockObject.Setup(x => x.Delete(null)).Throws<NullReferenceException>();

		}

		[TestMethod()]
		public void CreateTest()
		{
			var spected = mockObject.Object.Create(inputStudent);
			Assert.AreEqual(spected, outputStudent);
		}

		[TestMethod]
		[ExpectedException(typeof(NullReferenceException))]
		public void CreateWithNullValueThrowsNullReferenceException()
		{
			var spected = mockObject.Object.Create(null);
		}

		[TestMethod()]
		public void ReadTest()
		{
			var result = mockObject.Object.Read();
			Assert.IsTrue(result != null);
		}

		[TestMethod()]
		public void UpdateTest()
		{
			var spected = mockObject.Object.Update(inputStudentWithId);
			Assert.AreEqual(spected, inputStudentWithId);
		}

		[TestMethod]
		[ExpectedException(typeof(NullReferenceException))]
		public void UpdateWithNullValueThrowsNullReferenceException()
		{
			var spected = mockObject.Object.Update(null);
		}

		[TestMethod()]
		public void DeleteTest()
		{
			var spected = mockObject.Object.Delete(inputStudentWithId);
			Assert.IsTrue(spected);
		}

		[TestMethod]
		[ExpectedException(typeof(NullReferenceException))]
		public void DeleteWithNullValueThrowsNullReferenceException()
		{
			var spected = mockObject.Object.Delete(null);
		}
	}
}