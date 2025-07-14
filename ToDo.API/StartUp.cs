using Microsoft.EntityFrameworkCore;
using ToDo.API.Extensions;
using ToDo.API.Middlewares;
using ToDo.Data.Data;

namespace ToDo.API
{
    public class StartUp
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;
        public StartUp(IConfiguration configuration, IWebHostEnvironment environment)
        {
            _configuration = configuration;
            _environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                        options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"))
            );

            services.AddCors(options =>
            {
                options.AddPolicy("AddAllowOrigin",
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                    });
            });

            services.AddApplicationService();
            services.AddAutoMapper(typeof(MapperProfile));
            
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        public void Configure(WebApplication app, IWebHostEnvironment environment)
        {
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseCors("AddAllowOrigin");
            app.UseMiddleware<TokenAuthenticationMiddleware>();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();

        }
    }
}
