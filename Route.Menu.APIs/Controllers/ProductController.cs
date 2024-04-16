using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Route.Menu.Core.Enities;
using Route.Menu.Core.Repositories.Contract;

namespace Route.Menu.APIs.Controllers
{
	
	public class ProductController : BaseApiController
	{
		private readonly IGenericRepository<Product> _productRepo;

		public ProductController(IGenericRepository<Product> ProductRepo)
		{
			_productRepo = ProductRepo;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
		{
			var products = await _productRepo.GetAllAsync();
			return Ok(products);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Product>> GetProduct(int id)
		{
			var products = await _productRepo.GetAsync(id);

			if(products is null)
				return NotFound(new { Massage = "Not FOund", StatusCode = 404 });

			return Ok(products);
		}

	}
}
