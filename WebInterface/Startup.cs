using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Simulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebInterface.Display;
using WebInterface.Display.BasicWorld;
using WebInterface.Display.DroneWorld;
using Worlds;
using Worlds.Basic;
using Worlds.Drones;

namespace WebInterface
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();

            SetupDisplayers(services);

            SetupWorld<DroneWorld>(services);
        }

        private static void SetupDisplayers(IServiceCollection services)
        {
            services.AddSingleton<ICanvasDisplayer<BasicWorld>, BasicWorldDisplayer>();
            services.AddSingleton<ICanvasDisplayer<DroneWorld>, DroneWorldDisplayer>();
        }

        private static void SetupWorld<WorldType>(IServiceCollection services)
            where WorldType : class, IWorld<WorldType>
        {
            services.AddSingleton<Runner>();

            services.AddSingleton<ISimulationEngine, Engine<WorldType>>();
            services.AddSingleton<IWorldCanvasContext, WorldCanvasContext<WorldType>>();

            services.AddSingleton<IWorld<WorldType>, WorldType>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
