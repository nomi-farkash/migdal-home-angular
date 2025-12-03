
using server.Services;
using server.Settings;

namespace server
{
    public class Program
    {
        public static void Main(string[] args)
        {


            var builder = WebApplication.CreateBuilder(args);

            // Settings
            builder.Services.Configure<MongoDbSettings>(
                builder.Configuration.GetSection("MongoDb"));

            // Services
            builder.Services.AddScoped<IGaragesService, GaragesService>();


            // HttpClient
            builder.Services.AddHttpClient();
            // allow angular run
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAngular",
                    policy =>
                    {
                        policy.AllowAnyHeader()
                              .AllowAnyMethod()
                              .AllowCredentials()
                              .WithOrigins("http://localhost:58620"); 
                    });
            });
            // Controllers
            builder.Services.AddControllers();

            // Swagger (�� ����)
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors("AllowAngular");

            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}