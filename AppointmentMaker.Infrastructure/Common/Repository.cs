using AppointmentMaker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentMaker.Infrastructure.Common
{
	public class Repository: IRepository
	{
		protected DbContext context;
		public Repository(ApplicationDbContext _context)
		{
			context = _context;
		}
		public DbSet<T> DbSet<T>() where T : class
		{
			return context.Set<T>();
		}
		//This generic method adds a object of type T to the repository
		public async Task AddAsync<T>(T entity) where T : class
		{
			await DbSet<T>().AddAsync(entity);
		}

		public IQueryable<T> All<T>() where T : class
		{
			return DbSet<T>();
		}

		public IQueryable<T> AllReadOnly<T>() where T : class
		{
			return DbSet<T>().AsNoTracking();
		}
		//This generic method deletes a object of type T from the repository by its id
		public async Task DeleteAsync<T>(object id) where T : class
		{
			T? entity = await GetByIdAsync<T>(id);
			if (entity != null)
			{
				DbSet<T>().Remove(entity);
			}
		}
		//This generic method returns a object of type T by its id
		public async Task<T?> GetByIdAsync<T>(object id) where T : class
		{
			return await DbSet<T>().FindAsync(id);
		}

		public async Task<int> SaveChangesAsync()
		{
			return await context.SaveChangesAsync();
		}

		public async Task RemoveAsync<T>(T entity) where T : class
		{

			DbSet<T>().Remove(entity);
		}
	}
}
