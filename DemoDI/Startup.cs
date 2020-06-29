using System;
using DemoDI.Cases;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DemoDI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            #region Lifecycle

            services.AddTransient<IOperacaoTransient, Operacao>();
            services.AddScoped<IOperacaoScoped, Operacao>();
            services.AddSingleton<IOperacaoSingleton, Operacao>();
            services.AddSingleton<IOperacaoSingletonInstance>(new Operacao(Guid.Empty));
            services.AddTransient<OperacaoService>();

            #endregion

            #region VidaReal

            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IClienteServices, ClienteServices>();

            #endregion

            #region Generics

            //typeof será resolvido (qual classe umplementa) durante a execução
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            #endregion

            #region MultiplasClasses

            services.AddTransient<ServiceA>();
            services.AddTransient<ServiceB>();
            services.AddTransient<ServiceC>();
            services.AddTransient<Func<string, IService>>(serviceProvider => key =>
            {
                switch (key)
                {
                    case "A":
                        return serviceProvider.GetService<ServiceA>();
                    case "B":
                        return serviceProvider.GetService<ServiceB>();
                    case "C":
                        return serviceProvider.GetService<ServiceC>();
                    default:
                        return null;
                }
            });

            #endregion

            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddRazorPages();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapRazorPages();
                endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");});
          
        }
    }
}
