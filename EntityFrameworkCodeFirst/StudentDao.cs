using System.Collections.Generic;
using System.Linq;
using System;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;

namespace EntityFrameworkCodeFirst
{
	public class StudentDao
	{
		private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(typeof(StudentDao));

		public Student Create(Student student)
		{
			using (var context = new VuelingDbContext())
			{
				var studentInserted = context.Students.Add(student);
				SaveInContext(context);
				return studentInserted;
			}
		}

		public List<Student> Read()
		{
			try
			{
				using (var context = new VuelingDbContext())
				{
					var students = context.Students.ToList();
					return students;
				}
			}
			catch (ArgumentNullException ane)
			{
				logger.Error(Resources.Message + ane.Message);
				logger.Error(Resources.Trace + ane.StackTrace);
				throw;
			}
		}

		public Student Update(Student student)
		{
			try
			{
				using (var context = new VuelingDbContext())
				{
					var studentToUpdate = context.Students.Find(student.Id);
					studentToUpdate.Name = student.Name;
					studentToUpdate.Surname = student.Surname;
					studentToUpdate.DateOfBirth = student.DateOfBirth;

					SaveInContext(context);
					return studentToUpdate;
				}
			}
			catch (InvalidOperationException ioe)
			{
				logger.Error(Resources.Message + ioe.Message);
				logger.Error(Resources.Trace + ioe.StackTrace);
				throw;
			}

		}

		public bool Delete(Student student)
		{
			try
			{
				using (var context = new VuelingDbContext())
				{
					var studentToDelete = context.Students.Find(student.Id);
					context.Students.Remove(studentToDelete);
					SaveInContext(context);

					return (context.Students.Find(student.Id) == null);
				}
			}
			catch (InvalidOperationException ioe)
			{
				logger.Error(Resources.Message + ioe.Message);
				logger.Error(Resources.Trace + ioe.StackTrace);
				throw;
			}
		}

		public void SaveInContext(VuelingDbContext vContext)
		{
			try
			{
				vContext.SaveChanges();
			}
			catch (DbUpdateException due)
			{
				logger.Error(Resources.Message + due.Message);
				logger.Error(Resources.Trace + due.StackTrace);
				throw;
			}
			catch (DbEntityValidationException deve)
			{
				logger.Error(Resources.Message + deve.Message);
				logger.Error(Resources.Trace + deve.StackTrace);
				throw;
			}
			catch (NotSupportedException nse)
			{
				logger.Error(Resources.Message + nse.Message);
				logger.Error(Resources.Trace + nse.StackTrace);
				throw;
			}
			catch (ObjectDisposedException ode)
			{
				logger.Error(Resources.Message + ode.Message);
				logger.Error(Resources.Trace + ode.StackTrace);
				throw;
			}
			catch (InvalidOperationException ioe)
			{
				logger.Error(Resources.Message + ioe.Message);
				logger.Error(Resources.Trace + ioe.StackTrace);
				throw;
			}

		}

	}
}
