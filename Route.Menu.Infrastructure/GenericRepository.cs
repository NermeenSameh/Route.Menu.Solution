using Microsoft.EntityFrameworkCore;
using Route.Menu.Core.Enities;
using Route.Menu.Core.Repositories.Contract;
using Route.Menu.Core.Specifications;
using Route.Menu.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route.Menu.Infrastructure
{
	public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
	{
		private readonly ApplicationDbContext _dbContext;

		public GenericRepository(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public async Task<IEnumerable<T>> GetAllAsync()
		{
			///if (typeof(T) == typeof(Product))
			///	return (IEnumerable<T>) await _dbContext.Set<Product>().Include(P => P.Brand).Include(P => P.Category).AsNoTracking().ToListAsync();

			return await _dbContext.Set<T>().AsNoTracking().ToListAsync();
		}


		public async Task<T?> GetAsync(int id)
		{
			///if(typeof(T) == typeof(Product))
			///	return await _dbContext.Set<Product>().Where(P => P.Id == id).AsNoTracking().FirstOrDefaultAsync() as T;

			return await _dbContext.Set<T>().FindAsync(id);
		}
		public async Task<IEnumerable<T>> GetAllWIthSpecAsync(ISpecifications<T> spec)
		{
			return await ApplySpecification(spec).ToListAsync();
		}


		public async Task<T?> GetWithSpecAsync(ISpecifications<T> spec)
		{
			return await ApplySpecification(spec).FirstOrDefaultAsync();
		}
		private IQueryable<T> ApplySpecification(ISpecifications<T> spec)
		{
			return SpecificationsEvaluator<T>.GetQuery(_dbContext.Set<T>(), spec);
		}
	}
}
