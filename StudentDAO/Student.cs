using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDAO
{
    public class Student
    {
        public int Id;
        public string Name;
        public string Surname;
        public DateTime Birthdate;

        public Student(string name, string surname, DateTime birthDate)
        {
            Name = name;
            Surname = surname;
            Birthdate = birthDate;
        }

        public Student() { }
    }
}
