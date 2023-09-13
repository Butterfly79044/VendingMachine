using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using VendingMachine.Repository;

namespace VendingMachine
{
    public class Startup
    {
        private IConfigurationRoot _confString;

        public Startup(IHostEnvironment hostEnv)
        {
            _confString = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseMvcWithDefaultRoute();
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(x => x.EnableEndpointRouting = false);
            services.AddDbContext<DBContent>(x => x.UseSqlServer(_confString.GetConnectionString("DefaultConnection")));
            services.AddTransient < DrinkRepository>();
        }
    }
}
