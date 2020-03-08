using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCodeFirst
{
	[Table("Student")]
	public class Student
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public DateTime DateOfBirth { get; set; }

		public Student(int id, string name, string surname, DateTime dateOfBirth)
		{
			Id = id;
			Name = name;
			Surname = surname;
			DateOfBirth = dateOfBirth;
		}

		public Student() { }

		public override string ToString()
		{
			return "id: " + Id + ", name: " + Name + ", surname: " + Surname + ", DateOfBirth: " + DateOfBirth;
		}
	}
}
