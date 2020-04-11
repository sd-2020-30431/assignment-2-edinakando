using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WastelessAPI.DataAccess.Repositories;
using WastelessAPI.Application.Logic;
using WastelessAPI.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WastelessAPI
{
    public class Startup
    {
        private IConfiguration _config { get; }

        public Startup(IConfiguration configuration)
        {
            _config = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<UserRepository>();
            services.AddTransient<GroceriesRepository>();
            services.AddTransient<CharitiesRepository>();
            services.AddTransient<UserLogic>();
            services.AddTransient<GroceriesLogic>();
            services.AddTransient<CharitiesLogic>();

            services.AddDbContext<WastelessDbContext>(options => options.UseMySql(_config.GetConnectionString("WASTELESS_DB")));
            
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
             .AddJwtBearer(options =>
             {
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidateLifetime = true,
                     ValidateIssuerSigningKey = true,
                     ValidIssuer = _config["Jwt:Issuer"],
                     ValidAudience = _config["Jwt:Issuer"],
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]))
                 };
             });

            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddCors();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options => options.WithOrigins(_config.GetSection("RequestOrigin").Value)
                                          .AllowAnyMethod()
                                          .AllowAnyHeader());
            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
