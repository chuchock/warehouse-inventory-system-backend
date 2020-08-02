using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using wisys.Data;
using wisys.Services;

namespace wisys
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers()
			.AddNewtonsoftJson(); //Add support for HTTP PATCH

			//Add automapper service (automapper dependency)
			services.AddAutoMapper(typeof(Startup));

			var sqlConnectionString = Configuration["ConnectionStrings:PostgreSqlConnectionString"];

			services.AddDbContext<AppDbContext>(options => options.UseNpgsql(sqlConnectionString));

			//Add Cors Service
			services.AddCors(options =>
			{
				//options.AddPolicy("AllowAPIRequestIO",
				//	builder => builder.WithOrigins("https://apirequest.io").WithMethods("GET", "POST").AllowAnyHeader());
				options.AddPolicy("AllowAll",
						builder =>
						{
							builder
							.AllowAnyOrigin()
							.AllowAnyMethod()
							.AllowAnyHeader();
						});
			});

			//Add identity service
			services.AddIdentity<IdentityUser, IdentityRole>()
			.AddEntityFrameworkStores<AppDbContext>()
			.AddDefaultTokenProviders();

			//Add authentication service
			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
					.AddJwtBearer(options =>
						options.TokenValidationParameters = new TokenValidationParameters
						{
							ValidateIssuer = false,
							ValidateAudience = false,
							ValidateLifetime = true,
							ValidateIssuerSigningKey = true,
							IssuerSigningKey = new SymmetricSecurityKey(
								Encoding.UTF8.GetBytes(Configuration["jwt:key"])),
							ClockSkew = TimeSpan.Zero
						}
					);

			services.AddScoped<IWarehouseRepository, WarehouseRepository>();
			services.AddScoped<ICategoryRepository, CategoryRepository>();
			services.AddScoped<IProductRepository, ProductRepository>();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();

			app.UseAuthorization();
			app.UseAuthorization();

			app.UseCors();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
