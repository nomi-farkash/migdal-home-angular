
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

            // Controllers
            builder.Services.AddControllers();

            // Swagger (אם תרצי)
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.MapControllers();

            app.Run();
        }
    }
}