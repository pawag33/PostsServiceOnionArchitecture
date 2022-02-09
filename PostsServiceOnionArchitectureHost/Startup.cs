using ApplicationCore.DomainServices.Implementation;
using ApplicationCore.DomainServices.Interfaces;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using DomainEntities.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Persistence.InMemoryDB.Repositories;

namespace PostsServiceOnionArchitectureHost
{
    public class Startup
    {

        public static ILifetimeScope AutofacContainer { get; private set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Posts Service Onion Architecture API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AutofacContainer = app.ApplicationServices.GetAutofacRoot();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "InternalAPI"));

            app.UseRouting();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            // autofac registration
            // TODO : move it to separate class to lose decoupling  
            builder.RegisterType<ContentModerator>()
                    .As<IContentModerator>()
                    .InstancePerDependency();

            builder.RegisterType<PostManager>()
                .As<IPostManager>()
                .InstancePerDependency();

            builder.RegisterType<PostRetriever>()
                .As<IPostRetriever>()
                .InstancePerDependency();

            builder.RegisterType<PostInMemoryRepository>()
                .As<IPostRepository>()
                .SingleInstance();

        }
    }
}
