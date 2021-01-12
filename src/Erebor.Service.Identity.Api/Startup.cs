using Erebor.Service.Identity.Core.Domain.UserService.CreateUser;
using Erebor.Service.Identity.Core.Interfaces;
using Erebor.Service.Identity.Domain.Repositories;
using Erebor.Service.Identity.Infrastructure.Context;
using Erebor.Service.Identity.Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Erebor.Service.Identity.Api
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
            services.Configure<DataBaseSettings>(options =>
            {
                options.ConnectionString = Configuration.GetSection("IdentitystoreDatabase:ConnectionString").Value;
                options.Database = Configuration.GetSection("IdentitystoreDatabase:Database").Value;
            });
            services.AddScoped<IApplicationContext, ApplicationContext>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddMediatR(typeof(CreateUserCommandHandler));
            services.AddControllers().AddNewtonsoftJson(); 
         
           
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Erebor.Service.Identity.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Erebor.Service.Identity.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}