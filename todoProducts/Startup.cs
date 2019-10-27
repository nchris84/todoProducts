using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using todoProducts.Logger;
using todoProducts.BusinessLogic.ServiceManager.Product;
using todoProducts.BusinessLogic;
using todoProducts.DataAccess.Context;
using todoProducts.DataAccess.UnitOfWork;
using todoProducts.DataAccess.Entity;
using todoProducts.DataAccess.Repository;
using todoProducts.BusinessLogic.Mapper;

namespace todoProducts
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
            services.AddControllers();
            services.AddSingleton<ILoggerManager, LoggerManager>();
            services.AddTransient<IProductServiceManager, ProductServiceManager>();
            services.AddTransient<IProductManager, ProductManager>();
            services.AddScoped<IMongoContext, MongoContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IRepository<ProductEntity>, Repository<ProductEntity>>();
            services.AddAutoMapper(typeof(MappingProfile));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}