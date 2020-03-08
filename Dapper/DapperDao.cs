using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper
{
	public class DapperDao
	{
		public Student Create(Student student)
		{
			var contenx = new StudentContext();
			contenx.BulkInsert(student);
			return student;
		}
	}
}
