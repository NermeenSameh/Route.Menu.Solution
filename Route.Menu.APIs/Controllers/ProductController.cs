using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Route.Menu.APIs.DTOs;
using Route.Menu.APIs.Errors;
using Route.Menu.Core.Enities;
using Route.Menu.Core.Repositories.Contract;
using Route.Menu.Core.Specifications.ProductSpecs;

namespace Route.Menu.APIs.Controllers
{
	
	public class ProductController : BaseApiController
	{
		private readonly IGenericRepository<Product> _productRepo;
		private readonly IMapper _mapper;

		public ProductController(IGenericRepository<Product> ProductRepo , IMapper mapper )
		{
			_productRepo = ProductRepo;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<ProductToReturnDto>>> GetProducts()
		{
			var spec = new ProductWithBrandAndCategorySpecifications();
			
			var products = await _productRepo.GetAllWIthSpecAsync(spec);
			
			return Ok(_mapper.Map<IEnumerable<Product>, IEnumerable<ProductToReturnDto>>(products));
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
		{
			var spec = new ProductWithBrandAndCategorySpecifications(id);
			
			var products = await _productRepo.GetWithSpecAsync(spec);

			if(products is null)
				return NotFound(new ApiResponse(404));

			return Ok(_mapper.Map<Product, ProductToReturnDto>(products));
		}

	}
}
