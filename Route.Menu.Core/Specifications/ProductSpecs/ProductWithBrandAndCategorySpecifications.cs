using Route.Menu.Core.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route.Menu.Core.Specifications.ProductSpecs
{
	public class ProductWithBrandAndCategorySpecifications : BaseSpecifications<Product>
	{
        public ProductWithBrandAndCategorySpecifications()
            :base()
		{
			AddIncludes();
		}
		public ProductWithBrandAndCategorySpecifications(int id)
		  : base(P => P.Id == id)
		{
			AddIncludes();
		}
		private void AddIncludes()
		{
			Includes.Add(P => P.Brand);
			Includes.Add(P => P.Category);
		}


	}
}
