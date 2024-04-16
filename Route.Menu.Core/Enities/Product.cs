﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route.Menu.Core.Enities
{
	public class Product : BaseEntity
	{
		public string Name { get; set; } = null!;
		public string Description { get; set; } = null!;

		public string PictureUrl { get; set; } = null!;

		public decimal Price { get; set; }

		public int BrandId { get; set; } 

		public int CategoryId { get; set; }

		public ProductBrand Brand { get; set; } = null!; 

		public ProductCategory Category { get; set; } = null!;  
	}
}
