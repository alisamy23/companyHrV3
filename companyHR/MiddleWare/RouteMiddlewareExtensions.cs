namespace companyHR.MiddleWare
{
   
    public static class RouteMiddlewareExtensions
    {
        public static IApplicationBuilder UseRouteMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RouteMiddleware>();
        }

    }
}
