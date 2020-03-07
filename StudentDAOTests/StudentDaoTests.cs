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
            int idToCheck = 12;
            manager.Create(student);
            Student testStudent = manager.SelectStudentById(idToCheck);
            Assert.IsNotNull(testStudent);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            Student student = new Student("Update1", "Surname1", new DateTime(2001, 01, 01));
            StudentDao manager = new StudentDao();
            int idToCheck = 12;
            manager.Update(student, idToCheck);
            Student testStudent = manager.SelectStudentById(idToCheck);
            Assert.AreEqual("Update1", testStudent.Name);
        }
    }
}