using Route.Menu.Core.Enities;

namespace Route.Menu.APIs.DTOs
{
	public class ProductToReturnDto
	{
        public int Id { get; set; }
        public string Name { get; set; } = null!;
		public string Description { get; set; } = null!;

		public string PictureUrl { get; set; } = null!;

		public decimal Price { get; set; }

		public int BrandId { get; set; }

		public int CategoryId { get; set; }

		public string Brand { get; set; } = null!;

		public string Category { get; set; } = null!;


	}
}
