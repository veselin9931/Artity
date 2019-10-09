namespace Artity.Web.Extensions
{
    using Microsoft.AspNetCore.Builder;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseEndpointsRouting(this IApplicationBuilder app)
            => app.UseEndpoints(
                endpoints =>
                {
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