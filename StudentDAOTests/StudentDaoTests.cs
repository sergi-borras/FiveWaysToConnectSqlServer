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
        public static Student student;
        [TestInitialize]
        public void SetUp()
        {
            student = new Student("Name1", "Surname1", new DateTime(2001, 01, 01));
        }
        [TestMethod()]
        public void CreateTest()
        {
            StudentDao manager = new StudentDao();
            int idToCheck = 1;
            manager.Create(student);
            Student testStudent = manager.SelectStudentById(idToCheck);
            Assert.IsNotNull(testStudent);
        }
    }
}