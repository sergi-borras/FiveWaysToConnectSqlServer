using System.Collections.Generic;
using System.Linq;

namespace EntityFrameworkCodeFirst
{
	public class StudentDao
	{
		private readonly VuelingDbContext context = new VuelingDbContext();

		public Student Create(Student student)
		{

			var studentInserted = context.Students.Add(student);
			context.SaveChanges();
			return studentInserted;
		}

		public List<Student> Read()
		{
			var students = context.Students.ToList();
			return students;
		}

		public Student Update(Student student)
		{
			var studentToUpdate = context.Students.Find(student.Id);
			if (studentToUpdate != null)
			{
				studentToUpdate.Name = student.Name;
				studentToUpdate.Surname = student.Surname;
				studentToUpdate.DateOfBirth = student.DateOfBirth;
			}
			context.SaveChanges();
			return studentToUpdate;
		}

		public bool Delete(Student student)
		{
			var studentToDelete = context.Students.Find(student.Id);
			if (studentToDelete != null)
			{
				context.Students.Remove(studentToDelete);
				context.SaveChanges();
			}
			return (context.Students.Find(student.Id) == null);
		}



	}
}
