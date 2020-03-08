using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoredProcedures;
using StudentDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoredProcedures.Tests
{
    [TestClass()]
    public class StudentDaoTests
    {
        public static StudentDao manager;
        public const int testRowIndex = 0;
        [TestInitialize]
        public void Setup()
        {
            manager = new StudentDao();
            Student student1 = new Student("Name1", "Surname1", new DateTime(2001, 01, 01));
            Student student2 = new Student("Name2", "Surname2", new DateTime(2002, 02, 02));
            Student student3 = new Student("Name3", "Surname3", new DateTime(2003, 03, 03));
            Student student4 = new Student("Name4", "Surname4", new DateTime(2004, 04, 04));
            manager.Create(student1);
            manager.Create(student2);
            manager.Create(student3);
            manager.Create(student4);
        }
        [TestMethod()]
        public void CreateTest()
        {
            Student student = new Student("Create1", "Create1", new DateTime(2001, 01, 01));
            manager.Create(student);
            List<Student> students = manager.Read();
            int idToCheck = students.Last().Id;
            Student testStudent = manager.SelectStudentById(idToCheck);
            Assert.IsNotNull(testStudent);
        }
        [TestMethod()]
        public void UpdateTest()
        {
            Student student = new Student("Update1", "Update1", new DateTime(2001, 01, 01));
            List<Student> students = manager.Read();
            int idToCheck = students[testRowIndex].Id;
            manager.Update(student, idToCheck);
            Student testStudent = manager.SelectStudentById(idToCheck);
            Assert.AreEqual("Update1", testStudent.Name);
        }
        [TestMethod()]
        public void DeleteTest()
        {
            List<Student> students = manager.Read();
            int idToCheck = students[testRowIndex].Id;
            manager.Delete(idToCheck);
            Student testStudent = manager.SelectStudentById(idToCheck);
            Assert.IsTrue(testStudent == null);
        }
        [TestMethod()]
        public void ReadTest()
        {
            List<Student> students = manager.Read();
            Assert.AreEqual(4, students.Count);
        }
        [TestCleanup]
        public void TearDown()
        {
            manager.DeleteAll();
        }
    }
}
