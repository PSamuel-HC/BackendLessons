namespace MyStore.API.Middlewares
{
    public class LoggingMiddleware(RequestDelegate next)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            //Before
            Console.WriteLine("Before");

            await next(context);


            Console.WriteLine("After");
            //After
        }
    }
}
