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
using Erebor.Service.Identity.Api.Middlewares;
using Erebor.Service.Identity.Core;
using Erebor.Service.Identity.Core.Domain.AuthService.Login;
using Erebor.Service.Identity.Core.Domain.AuthService.RefreshToken;
using Erebor.Service.Identity.Core.Domain.UserService.UpdateUserRole;
using Erebor.Service.Identity.Infrastructure;
using Erebor.Service.Identity.Infrastructure.Security;

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
            var jwtTokenConfig = Configuration.GetSection("jwtAuthConfig").Get<JwtAuthConfig>();
            services.AddSingleton(jwtTokenConfig);

            services.Configure<DataBaseSettings>(options =>
            {
                options.ConnectionString = Configuration.GetSection("IdentitystoreDatabase:ConnectionString").Value;
                options.Database = Configuration.GetSection("IdentitystoreDatabase:Database").Value;
            });
            services.AddInfrastructure();
            services.AddIdentityCommandsCollection();
            
            services.AddControllers().AddNewtonsoftJson();

            services.AddScoped(typeof(ErrorHandlerMiddleware));
           
           
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo() { Title = "Identity API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger()
                .UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                });
        }
    }
}
