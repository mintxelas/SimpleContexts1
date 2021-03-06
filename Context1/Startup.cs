using Context1.Application;
using Context1.Domain;
using Context1.Infrastructure;
using Context1.Subscriptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Context1
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<Bus>();
            services.AddSingleton<OneSubscriber>();
            services.AddSingleton<AnotherSubscriber>();
            services.AddScoped<IRepository<RepositoryWithSubscribers>, RepositoryWithSubscribers>();
            services.AddScoped<IRepository<RepositoryWithBus>, RepositoryWithBus>();
            services.AddScoped<IRepository<Repository>, Repository>();
            services.AddScoped<ApplicationService<RepositoryWithSubscribers>>();
            services.AddScoped<ApplicationService<RepositoryWithBus>>();
            services.AddScoped<ApplicationService<Repository>>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, 
            OneSubscriber subscriber1, AnotherSubscriber subscriber2)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            subscriber1.InitializeSubscriptions();
            subscriber2.InitializeSubscriptions();

        }
    }
}
