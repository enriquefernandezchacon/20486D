﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using WorldJourney.Models;
using WorldJourney.Filters;

namespace WorldJourney
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton<IData, Data>();
            services.AddScoped<LogActionFilterAttribute>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();
            //app.UseMvc();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "TravelerRoute",
                    template: "{controller}/{action}/{name}",
                    defaults: new { controller = "Traveler", action = "Index", name = "Alexay Pivovarov" },
                    constraints: new { name = "[A-Za-z ]+" }
                );

                routes.MapRoute(
                  name: "defaultRoute",
                  template: "{controller}/{action}/{id?}",
                  defaults: new { controller = "Home", action = "Index" },
                  constraints: new { id = "[0-9]+" }
                );

            });
        }
    }
}
