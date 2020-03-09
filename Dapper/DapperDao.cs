using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace Dapper
{
	public class DapperDao
	{
		//public readonly StudentContext context = new StudentContext();

		public Student Create(Student studentToCreate)
		{

			using (var connection = new SqlConnection("Server=localhost,1433;Database=Vueling;User Id=sa;Password=yourStrong(!)Password"))
			{
				return studentToCreate;
			}
		}

		public List<Student> Read()
		{
			using (IDbConnection connection = new SqlConnection("Server=localhost,1433;Database=Vueling;User Id=sa;Password=yourStrong(!)Password"))
			{
				connection.Open();
				var students = SqlMapper.Query<Student>(connection, "SELECT * FROM Student").ToList();
				return students;
			}
		}
	}

}
