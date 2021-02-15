using Erebor.Service.Identity.Infrastructure.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Erebor.Service.Identity.Api.Middlewares;
using Erebor.Service.Identity.Core;
using Erebor.Service.Identity.Core.SelfHosted;
using Erebor.Service.Identity.Infrastructure;
using Erebor.Service.Identity.Infrastructure.Hangfire;
using Erebor.Service.Identity.Infrastructure.Security;
using Hangfire;
using Hangfire.Mongo;
using Hangfire.Mongo.Migration.Strategies;
using Hangfire.Mongo.Migration.Strategies.Backup;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using LogLevel = Hangfire.Logging.LogLevel;
using Erebor.Service.Identity.Infrastructure.RabbitMQ.Settings;

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
            services.AddHangfire(config =>
            {

                // Read DefaultConnection string from appsettings.json
                var connectionString = Configuration.GetSection("ConnectionStrings:EreborHangfire").Value;
                var mongoUrlBuilder = new MongoUrlBuilder(connectionString);
                var mongoClient = new MongoClient(mongoUrlBuilder.ToMongoUrl());

                var storageOptions = new MongoStorageOptions
                {
                    MigrationOptions = new MongoMigrationOptions
                    {
                        MigrationStrategy = new MigrateMongoMigrationStrategy(),
                        BackupStrategy = new CollectionMongoBackupStrategy()
                    }
                };
                //config.UseLogProvider(new FileLogProvider());
                config.UseColouredConsoleLogProvider(LogLevel.Info);
                config.UseMongoStorage(mongoClient, mongoUrlBuilder.DatabaseName, storageOptions);
            });
            var serviceClientSettingsConfig = Configuration.GetSection("RabbitMq");
            services.Configure<RabbitMqConfiguration>(serviceClientSettingsConfig);
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
            var options = new BackgroundJobServerOptions { Queues = new[] { "default", "notDefault" } };

            app.UseHangfireServer(options);

            app.UseHangfireDashboard();
            RecurringJob.AddOrUpdate<RemoveExpiredTokenManager>
            (nameof(RemoveExpiredTokenManager.RemoveExpiredTokens),
                x => x.RemoveExpiredTokens(), Cron.Hourly);
        }
    }
}
