using Microsoft.Extensions.DependencyInjection.Extensions;

namespace BTL_ConGa
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();



        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "error",
                    pattern: "{*url}",
                    defaults: new { controller = "TrangChu", action = "Error404" }
                );
            });
        }

    }
}
