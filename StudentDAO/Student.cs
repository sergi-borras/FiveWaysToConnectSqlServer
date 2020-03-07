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
        public DateTime DateOfBirth;

        public Student(int id, string name, string surname, DateTime dateOfBirth)
        {
            Id = id;
            Name = name;
            Surname = surname;
            DateOfBirth = dateOfBirth;
        }
    }
}
