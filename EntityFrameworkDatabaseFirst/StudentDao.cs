using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkDatabaseFirst
{
	public class StudentDao
	{
		private VuelingDbContext context = new VuelingDbContext();

		public Student Create(Student student)
		{

			context.Students.Add(student);
			context.SaveChanges();
			return student;
		}

		public List<Student> Read()
		{
			var students = context.Students.ToList();
			return students;
		}



	}
}
