using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper
{
	public class DapperDao
	{
		public readonly StudentContext context = new StudentContext();
		
		public Student Create(Student student)
		{
			context.BulkInsert(student);
			return student;
		}

		public Student Update(Student student)
		{
			context.BulkUpdate(student);
			return student;
		}
	}
}
