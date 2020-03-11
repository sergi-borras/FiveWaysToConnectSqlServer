using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciceDapper
{
	public interface IStudentDao<T>
	{
		T Create(T item);
		List<T> Read();
		T Update(T item);
		bool Delete(T item);
	}
}
