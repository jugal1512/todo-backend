namespace ToDo.API.Middlewares
{
    public class TokenAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;
        public TokenAuthenticationMiddleware(RequestDelegate next,
                                            IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Headers["APIToken"].FirstOrDefault();
            var configuredToken = _configuration["APIToken"];

            if (string.IsNullOrEmpty(token) || token != configuredToken)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Unauthorized: Invalid API Token");
                return;
            }
            await _next(context);
        }
    }
}
