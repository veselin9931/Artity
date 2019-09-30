namespace Artity.Web.Extensions
{
    using Microsoft.AspNetCore.Builder;
    using Web.Hubs;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseEndpointsRouting(this IApplicationBuilder app)
            => app.UseEndpoints(
                endpoints =>
                {
                    endpoints.MapHub<NotifyHub>("/notify");

                    endpoints.MapControllerRoute(
                        "areaRoute",
                        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                    endpoints.MapControllerRoute(
                        "default",
                        pattern: "{controller=Home}/{action=Index}/{id?}");

                    endpoints.MapRazorPages();
                });
    }
}