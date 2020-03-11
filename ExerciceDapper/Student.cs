using System;

namespace ExerciceDapper
{
    public class Student
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Student(string name, string surname, DateTime dateOfBirth)
        {
            Name = name;
            Surname = surname;
            DateOfBirth = dateOfBirth;
        }

        public Student() { }

    }
}
