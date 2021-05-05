using Ecommercewebsite.Helpers;
using Ecommercewebsite.Models;
using Ecommercewebsite.Repository;
using Ecommercewebsite.Services;
using Ecommercewebsite.Services.Categories;
using Ecommercewebsite.Services.Products;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommercewebsite
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //////////////////////////////////////////////////
            //Map the  values in appsettings with the class JWT.
            services.Configure<JWT>(Configuration.GetSection("JWT"));
            //Use Identity into the project
            //Adds The identityb system configuration for the specified user and the roletype
            //Adds an entity framework implementation of identity information store
            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IProduct, product>();
            services.AddScoped<IUsers, Users>();
            services.AddScoped<ICategory, Categories>();
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            );
            services.AddMemoryCache();


            //Ici Activer LE JWT 
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        //active la validation des ussuer and audience 
                        ValidateIssuerSigningKey = true,
                        //
                        ValidateIssuer = true,
                        //
                        ValidateAudience = true,
                        //
                        ValidateLifetime= true,
                        //
                        ValidIssuer=Configuration["JWT:Issuer"],
                        //
                        ValidAudience = Configuration["JWT:Audience"],
                        //
                        IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Key"]))
                    };
                });
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ecommercewebsite", Version = "v1" });
               
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger(c =>
                {
                    c.RouteTemplate = "/swagger/{documentName}/swagger.json";
                });
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ecommercewebsite v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            //Check The authentication then use the authorisation
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
