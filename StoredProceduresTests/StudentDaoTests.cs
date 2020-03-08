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
        [TestInitialize]
        public void Setup()
        {
            manager = new StudentDao();
        }
        [TestMethod()]
        public void CreateTest()
        {
            Student student = new Student("Create1", "Create1", new DateTime(2001, 01, 01));
            manager.Create(student);
            int idToCheck = 28;
            Student testStudent = manager.SelectStudentById(idToCheck);
            Assert.IsNotNull(testStudent);
        }
    }
}
