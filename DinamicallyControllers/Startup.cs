using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DinamicallyControllers.Controllers.ControllerModelConventions;
using DinamicallyControllers.Controllers.FeatureProviders;
using DinamicallyControllers.Models;
using DinamicallyControllers.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DinamicallyControllers
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
            services.AddSingleton(typeof(Repository<>));

            services.AddMvc(opt =>
                opt.Conventions.Add(new GenericControllerRouteConvention())
            ).ConfigureApplicationPartManager(apm =>
                apm.FeatureProviders.Add(new GenericTypeControllerFeatureProvider())
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
