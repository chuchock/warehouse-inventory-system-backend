using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
using Microsoft.OpenApi.Models;
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
			//////////////////////////////////////////////////////////////
			// Add support for HTTP PATCH
			services.AddControllers()
			.AddNewtonsoftJson();
			/////////////////////////////////////////////////////////////


			//////////////////////////////////////////////////////////////
			// Add automapper service (automapper dependency)
			services.AddAutoMapper(typeof(Startup));
			/////////////////////////////////////////////////////////////


			//////////////////////////////////////////////////////////////
			// Add DB connection
			var sqlConnectionString = Configuration["ConnectionStrings:PostgreSqlConnectionString"];
			services.AddDbContext<AppDbContext>(options => options.UseNpgsql(sqlConnectionString));
			//////////////////////////////////////////////////////////////


			//////////////////////////////////////////////////////////////
			// Add Cors Service
			services.AddCors(options =>
			{
				options.AddPolicy("AllowAll",
						builder =>
						{
							builder
							.AllowAnyOrigin()
							.AllowAnyMethod()
							.AllowAnyHeader()
							.WithExposedHeaders("totalAmountPages") // enable custom header for pagination
							;
						});
			});
			///////////////////////////////////////////////////////////////


			//////////////////////////////////////////////////////////////
			//Add identity service
			services.AddIdentity<IdentityUser, IdentityRole>()
			.AddEntityFrameworkStores<AppDbContext>()
			.AddDefaultTokenProviders();
			/////////////////////////////////////////////////////////////


			//////////////////////////////////////////////////////////////
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
			/////////////////////////////////////////////////////////////


			services.AddScoped<IWarehouseRepository, WarehouseRepository>();
			services.AddScoped<ICategoryRepository, CategoryRepository>();
			services.AddScoped<IProductRepository, ProductRepository>();


			//////////////////////////////////////////////////////////////
			//ADD SWAGGER DCOUMENTATION
			services.AddSwaggerGen(config =>
			{
				config.SwaggerDoc("v1", new OpenApiInfo
				{
					Version = "v1",

					Title = "wisysAPI",
					Description = "This is a Web API for WISYS system",
					//TermsOfService = new Uri(""),
					License = new OpenApiLicense()
					{
						Name = "MIT"
					},
					Contact = new OpenApiContact()
					{
						Name = "Jesús Montero Cuevas",
						Email = "jesusmontero.developer@gmail.com"
						//Url = new Uri("")
					}
				});

				// include comments
				var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
				var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
				config.IncludeXmlComments(xmlPath);
			});
			///////////////////////////////////////////////////////////
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			// Enable swagger
			app.UseSwagger();
			app.UseSwaggerUI(config =>
			{
				config.SwaggerEndpoint("/swagger/v1/swagger.json", "wisysAPI");
			});


			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}


			app.UseRouting();


			// global cors policy
			app.UseCors();


			app.UseAuthorization();
			app.UseAuthorization();


			//https
			app.UseHttpsRedirection();


			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
