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
			services.AddControllers()
			.AddNewtonsoftJson(); //Add support for HTTP PATCH

			//Add automapper service (automapper dependency)
			services.AddAutoMapper(typeof(Startup));

			var sqlConnectionString = Configuration["ConnectionStrings:PostgreSqlConnectionString"];

			services.AddDbContext<AppDbContext>(options => options.UseNpgsql(sqlConnectionString));

			//Add Cors Service
			//services.AddCors(options =>
			//{
			//	//options.AddPolicy("AllowAPIRequestIO",
			//	//	builder => builder.WithOrigins("https://apirequest.io").WithMethods("GET", "POST").AllowAnyHeader());
			//	options.AddPolicy("AllowAll",
			//			builder =>
			//			{
			//				builder
			//				.AllowAnyOrigin()
			//				.AllowAnyMethod()
			//				.AllowAnyHeader();
			//			});
			//});
			services.AddCors();



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
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			// Enable swagger
			app.UseSwagger();
			app.UseSwaggerUI(config =>
			{
				config.SwaggerEndpoint("/swagger/v1/swagger.json", "MoviesAPI");
			});

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();

			// global cors policy
			app.UseCors(x => x
				.AllowAnyMethod()
				.AllowAnyHeader()
				.SetIsOriginAllowed(origin => true) // allow any origin
				.AllowCredentials()); // allow credentials

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
