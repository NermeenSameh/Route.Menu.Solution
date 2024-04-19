using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Route.Menu.APIs.Errors;
using Route.Menu.APIs.Helpers;
using Route.Menu.Core.Repositories.Contract;
using Route.Menu.Infrastructure;

namespace Route.Menu.APIs.Extensions
{
	public static class ApplicationServicesExtension
	{


	public static IServiceCollection AddApplicationServices(this IServiceCollection services)
		{
			services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

			services.AddAutoMapper((typeof(MapperProfiles)));



			services.Configure<ApiBehaviorOptions>(options =>
			{
				options.InvalidModelStateResponseFactory = (actionContext) =>
				{
					var errors = actionContext.ModelState.Where(P => P.Value.Errors.Count() > 0)
														 .SelectMany(P => P.Value.Errors)
														 .Select(E => E.ErrorMessage)
														 .ToArray();
					var response = new ApiValidationErrorResponse()
					{
						Errors = errors
					};
					return new BadRequestObjectResult(response);
				};
			});


			return services;
		}
	}
}
