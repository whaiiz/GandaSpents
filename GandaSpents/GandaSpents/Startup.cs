using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GandaSpents.Models;
using GandaSpents.Models.Repositories;
using GandaSpents.Models.Sql;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GandaSpents
{
    public class Startup
    {

        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<AppDbContext>();
            services.AddScoped<IProductTypeRepository, ProductTypeRepository>();
            services.AddScoped<ISpentEntityRepository, SpentEntityRepository>();
            services.AddScoped<ISpentRepository, SpentRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"))
            );

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductType, ProductType>().ForMember(dest => dest.Id, act => act.Ignore());
                cfg.CreateMap<Spent, Spent>().ForMember(dest => dest.Id, act => act.Ignore());
                cfg.CreateMap<SpentEntity, SpentEntity>().ForMember(dest => dest.Id, act => act.Ignore());
                cfg.CreateMap<Product, Product>().ForMember(dest => dest.Id, act => act.Ignore());

            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
            services.AddSignalR();

            services.AddRazorPages();
            services.AddAuthentication()
                .AddGoogle(options =>
                {
                    options.ClientId = "470635064401-oj4r0ucrcndgg1hqopp6311j3np99dsm.apps.googleusercontent.com";
                    options.ClientSecret = "EijhA6eisudHAVVMCxAVgLQL";
                });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();

            });
                       
        }
    }
}
