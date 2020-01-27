using GTI_WebCore.Interfaces;
using GTI_WebCore.Models;
using GTI_WebCore.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GTI_WebCore {
    public class Startup {
        private readonly IConfiguration _Config;

        public Startup(IConfiguration _config) {
            _Config = _config;
        }

        public void ConfigureServices(IServiceCollection services) {
            services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(_Config.GetConnectionString("GTI_Connection")));

            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(20);
                options.Cookie.HttpOnly = true;
            });

            services.AddMvc().AddXmlSerializerFormatters();
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IImovelRepository, ImovelRepository>();
            services.AddScoped<IRequerenteRepository, RequerenteRepository>();
            services.AddScoped<ITributarioRepository, TributarioRepository>();
            services.AddScoped<IProcessoRepository, ProcessoRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseSession();
            app.UseStaticFiles();
            app.UseMvc(routes => {
                routes.MapRoute("default", "{controller=Home}/{action=Index}");
            });

        }
    }
}
