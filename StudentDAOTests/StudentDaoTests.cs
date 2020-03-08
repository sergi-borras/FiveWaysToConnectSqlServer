using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDAO.Tests
{
    [TestClass()]
    public class StudentDaoTests
    {
        [TestMethod()]
        public void CreateTest()
        {
            Student student = new Student("Name1", "Surname1", new DateTime(2001, 01, 01));
            StudentDao manager = new StudentDao();
            int idToCheck = 1;
            manager.Create(student);
            Student testStudent = manager.SelectStudentById(idToCheck);
            Assert.IsNotNull(testStudent);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            Student student = new Student("Update1", "Surname1", new DateTime(2001, 01, 01));
            StudentDao manager = new StudentDao();
            int idToCheck = 1;
            manager.Update(student, idToCheck);
            Student testStudent = manager.SelectStudentById(idToCheck);
            Assert.AreEqual("Update1", testStudent.Name);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            StudentDao manager = new StudentDao();
            int idToCheck = 1;
            manager.Delete(idToCheck);
            Student testStudent = manager.SelectStudentById(idToCheck);
            Assert.IsTrue(testStudent == null);
        }

        [TestMethod()]
        public void ReadTest()
        {
            Student student1 = new Student("Name1", "Surname1", new DateTime(2001, 01, 01));
            Student student2 = new Student("Name2", "Surname2", new DateTime(2002, 02, 02));
            Student student3 = new Student("Name3", "Surname3", new DateTime(2003, 03, 03));
            Student student4 = new Student("Name4", "Surname4", new DateTime(2004, 04, 04));
            StudentDao manager = new StudentDao();
            manager.Create(student1);
            manager.Create(student2);
            manager.Create(student3);
            manager.Create(student4);
            List<Student> students = manager.Read();
            Assert.AreEqual(4, students.Count);
        }
    }
}