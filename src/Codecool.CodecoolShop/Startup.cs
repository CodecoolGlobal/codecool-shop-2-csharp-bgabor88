using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Codecool.CodecoolShop
{
    public class Startup
    {
        private readonly string _connectionMode;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _connectionMode = Configuration.GetSection("Mode").Value;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            if (Equals(_connectionMode, "SQL"))
            {
                SetupDependencyInjectionForDb(services);
            }
            services.AddScoped<ProductService>();
            services.AddControllersWithViews();
            services.AddMvc();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Product/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseSession();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            
            if (Equals(_connectionMode, "IM"))
            {
                InMemoryDb.SetupInMemoryDatabases();
            }
        }

        private void SetupDependencyInjectionForDb(IServiceCollection services)
        {
            services.AddDbContext<ProductContext>(options =>
            {
                options
                    .UseLazyLoadingProxies()
                    .UseSqlServer(Configuration.GetConnectionString("Default"));
            });
            services.AddScoped<ISupplierDao, SupplierDaoDb>();
            services.AddScoped<IProductCategoryDao, ProductCategoryDaoDb>();
            services.AddScoped<IProductDao, ProductDaoDb>();
        }
    }
}
