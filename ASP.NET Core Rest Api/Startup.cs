using ASP.NET_Core_With_Mongo_Db.Business.Abstract;
using ASP.NET_Core_With_Mongo_Db.Business.Concrete;
using ASP.NET_Core_With_Mongo_Db.Core.EntityRepository.Abstract;
using ASP.NET_Core_With_Mongo_Db.Core.EntityRepository.Concrete;
using ASP.NET_Core_With_Mongo_Db.Core.EntityRepository.ConnectionModel.Abstract;
using ASP.NET_Core_With_Mongo_Db.Core.EntityRepository.ConnectionModel.Concrete;
using ASP.NET_Core_With_Mongo_Db.Dal;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_Rest_Api
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
            

            services.Configure<SimpleDatabaseSettings>(
                Configuration.GetSection(nameof(SimpleDatabaseSettings)));

            services.AddSingleton<ISimpleDatabaseSettings>(sp =>
            sp.GetRequiredService<IOptions<SimpleDatabaseSettings>>().Value);

       
            services.AddControllers();
            services.AddSingleton<IEntityRepository<Address>, AddressRepository>();
            services.AddSingleton<IEntityRepository<Book>, BookRepository>();
            services.AddSingleton<IEntityRepository<Customer>, CustomerRepository>();
            services.AddSingleton<IEntityRepository<Writer>, WriterRepository>();


            services.AddSingleton<IAddressService, AddressService>();
            services.AddSingleton<IBookService, BookService>();
            services.AddSingleton<ICustomerService, CustomerService>();
            services.AddSingleton<IWriterService, WriterService>();

          

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
