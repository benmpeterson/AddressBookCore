using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using AddressBook.Services;
using Microsoft.Extensions.Configuration;
using AddressBook.Data;
using Microsoft.EntityFrameworkCore;

namespace AddressBook
{
    public class Startup
    {
        public IConfigurationRoot Configuration {get;}
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<ApplicationDbContext>
            (options => options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
            services.AddMvc();

            services.AddSingleton<IContactRepository, InMemoryContactRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if(env.IsDevelopment())
            {
               app.UseDeveloperExceptionPage();
            }
            else
            {
               app.UseExceptionHandler("Home/Error");
            }
            
            app.UseStaticFiles();
            app.UseMvc( routes => {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                );
            });                        
        }
    }
}