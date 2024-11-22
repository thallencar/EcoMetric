
using EcoMetric.API.Configuration;
using EcoMetric.API.Extensions;
using EcoMetric.ML;

namespace EcoMetric.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            IConfiguration configuration = builder.Configuration;
            APIConfiguration appConfiguration = new();
            configuration.Bind(appConfiguration);
            builder.Services.Configure<APIConfiguration>(configuration);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerDocs(appConfiguration);

            builder.Services.AddRepository();

            builder.Services.AddMongoDbContext(appConfiguration);

            builder.Services.AddSingleton<PrevisaoConsumoEngine>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
