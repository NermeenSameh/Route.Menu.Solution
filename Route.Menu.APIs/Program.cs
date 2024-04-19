
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Route.Menu.APIs.Extensions;
using Route.Menu.APIs.Helpers;
using Route.Menu.Core.Repositories.Contract;
using Route.Menu.Infrastructure;
using Route.Menu.Infrastructure.Data;

namespace Route.Menu.APIs
{
    public class Program
	{
		public static async Task Main(string[] args)
		{
			var webApplicationBuilder = WebApplication.CreateBuilder(args);



			#region Configure Services
			// Add services to the container.

			webApplicationBuilder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			webApplicationBuilder.Services.AddEndpointsApiExplorer();
			webApplicationBuilder.Services.AddSwaggerGen();


			webApplicationBuilder.Services.AddDbContext<ApplicationDbContext>(options =>
			{
				options.UseSqlServer(webApplicationBuilder.Configuration.GetConnectionString("DefaultConnection"));
			});

			webApplicationBuilder.Services.AddApplicationServices();
			#endregion



			var app = webApplicationBuilder.Build();

			using var scope = app.Services.CreateScope();
			var services = scope.ServiceProvider;
			var _dbContext = services.GetRequiredService<ApplicationDbContext>();

			var loggerFactory = services.GetRequiredService<ILoggerFactory>();
			try
			{

				await _dbContext.Database.MigrateAsync();
				await ApplicationContextSeed.SeedAsync(_dbContext);
			}
			catch (Exception ex)
			{

				var logger = loggerFactory.CreateLogger<Program>();
				logger.LogError(ex, "An Error has been occured during apply the migration");
			}

			// Configure the HTTP request pipeline.
			#region Configure Kestral Middlewares
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseAuthorization();


			app.MapControllers();
			#endregion

			app.Run();
		}
	}
}
