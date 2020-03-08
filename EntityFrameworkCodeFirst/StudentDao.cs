
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;

namespace EntityFrameworkCodeFirst
{
	public class StudentDao
	{
		public Student Create(Student student)
		{
			using (var context = new VuelingDbContext())
			{
				context.Students.Add(student);
				context.SaveChanges();
			}
			return student;
		}

		
	}
}
