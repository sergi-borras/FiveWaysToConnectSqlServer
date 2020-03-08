using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z.Dapper.Plus;

namespace Dapper
{
	public class StudentContext: DapperPlusContext
	{
		public StudentContext() : base(new SqlConnection("Server=localhost,1433;Database=Vueling;User Id=sa;Password=yourStrong(!)Password"))
		{
			this.Entity<Student>().Identity(s => s.Id, true);
		}
	}
}
