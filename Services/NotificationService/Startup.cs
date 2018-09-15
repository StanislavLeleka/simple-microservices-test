using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NotificationService.Hubs;

namespace NotificationService
{
    public class Startup
    {
        private const string SPA_HOST = "http://localhost:3000";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSignalR();
            services.AddScoped<IMessageHub, MessageHub>();
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.UseCors(builder => builder.WithOrigins(SPA_HOST)
               .AllowAnyHeader()
               .AllowAnyMethod()
               .AllowCredentials());

            app.UseSignalR(routes =>
            {
                routes.MapHub<MessageHub>("/messageHub");
            });
        }
    }
}
