namespace MyStore.API.Middlewares
{
    public class HeaderMiddleware(RequestDelegate next)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.ContainsKey("API-Key"))
            {
                context.Response.StatusCode = 401;

                return;
            }

            await next(context);


        }
    }
}
