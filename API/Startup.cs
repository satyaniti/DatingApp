using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using API.Interfaces;
using API.Services;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using API.Extensions;

namespace API
{
    public class Startup
    {
      public readonly IConfiguration _config;
        public Startup(IConfiguration config)
        {
          _config = config;
        }
        public IConfiguration Configuration{get;}
        
        public void ConfigureServices (IServiceCollection services) 
        {
          services.AddApplicationServices(_config);
          services.AddControllers();
          services.AddCors();
         services.AddIdentityServices(_config);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
          if(env.IsDevelopment())
          {
            app.UseDeveloperExceptionPage();
          }
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseCors(x=>x.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:5001/"));
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
          endpoints.MapControllers();
        });
        }
        
    }
}
