using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using HydrometricControl.Domain.Interfaces;
using HydrometricControl.Domain.Services;
using HydrometricControl.Data;
using Microsoft.EntityFrameworkCore;

namespace HydrometricControlApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
            => Configuration = configuration;

        public IConfiguration Configuration { get; }
        readonly string AllowedSpecificOrigins = "_AllowedSpecificOrigins";
        readonly string[] SpecifcUrlOriginsList = { "http://localhost:5000" };

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
                .EnableSensitiveDataLogging());

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //Services
            services.AddScoped<IFaixaService, FaixaService>();
            //services.AddScoped<IContaService, ContaService>();
            services.AddScoped<IUnidadeService, UnidadeService>();
            services.AddScoped<IImpostoService, ImpostoService>();
            services.AddScoped<ILeituraService, LeituraService>();
            services.AddScoped<ICondominioService, CondominioService>();
            services.AddScoped<ILeituraGeralService, LeituraGeralService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseCors(AllowedSpecificOrigins);

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
