using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using API.Data;
using Microsoft.EntityFrameworkCore;
using API.interfaces;
using API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using API.Extensions;
using API.Middleware;

namespace API
{
    public class Startup
    {


        private readonly IConfiguration _Config;
        public Startup(IConfiguration configuration)
        {
            _Config = configuration;
        }

/*        public IConfiguration Configuration { get; }*/

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {


            /* services.AddDbContext<DataContext>(options =>
             {
                 options.UseSqlite(_Config.GetConnectionString("DefaultConnection"));
             });


             services.AddScoped<ITokenService,TokenService>();*/

            services.AddApplicationServices(_Config);
            services.AddControllers();
            services.AddCors(options => {
                options.AddDefaultPolicy(builder => {
                    builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                });
            });

            /* services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
                 options =>
                 {
                     options.TokenValidationParameters = new TokenValidationParameters
                     {
                         ValidateIssuerSigningKey = true,
                         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Config["TokenKey"])),
                         ValidateIssuer = false,
                         ValidateAudience = false,
                     };

                 }
                 );*/

            services.AddIdentityServices(_Config);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            /*     if (env.IsDevelopment())
                 {
                     app.UseDeveloperExceptionPage();
                     app.UseSwagger();
                     app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
                 }*/


            app.UseMiddleware<ExceptionMiddleware>();

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
