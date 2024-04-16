﻿using Route.Menu.Core.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route.Menu.Core.Repositories.Contract
{
	public interface IGenericRepository<T> where T : BaseEntity
	{
		Task <T?> GetAsync(int id);

		Task<IEnumerable<T>> GetAllAsync();
	}
}
