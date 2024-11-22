using EcoMetric.API.Configuration;
using EcoMetric.Business.Models;
using EcoMetric.Data.Contexts;
using EcoMetric.Repositories.Interfaces;
using EcoMetric.Repositories.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace EcoMetric.API.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddSwaggerDocs(this IServiceCollection services, APIConfiguration appConfiguration)
        {
            services.AddSwaggerGen(
                x => x.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "EcoMetric - APPLICATION API",
                    Version = "v1",
                    Description = "API de um sistema de monitoramento energético para pequenas e médias empresas, fornecendo insights sobre o consumo de energia e sugestões personalizadas de economia. O sistema se concentrará em melhorar a eficiência energética e reduzir custos, ajudando as empresas a alcançar práticas mais sustentáveis.",
                    Contact = new OpenApiContact() { Email = "ecometric@fivetech.com.br", Name = "FiveTech Collective" }
                }
                )
            );

            return services;
        }

        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperConfiguration).Assembly);

            services.AddScoped<IRepository<CadastroModel>, Repository<CadastroModel>>();
            services.AddScoped<IRepository<ConsumoEnergiaModel>, Repository<ConsumoEnergiaModel>>();
            services.AddScoped<IRepository<ContatoModel>, Repository<ContatoModel>>();
            services.AddScoped<IRepository<EnderecoModel>, Repository<EnderecoModel>>();
            services.AddScoped<IRepository<MonitoramentoModel>, Repository<MonitoramentoModel>>();
            services.AddScoped<IRepository<ProjetoModel>, Repository<ProjetoModel>>();
            services.AddScoped<IRepository<RelatorioEnelModel>, Repository<RelatorioEnelModel>>();
            services.AddScoped<IRepository<RelatorioHardwareModel>, Repository<RelatorioHardwareModel>>();
            services.AddScoped<IRepository<RelatorioModel>, Repository<RelatorioModel>>();

            return services;
        }

        public static IServiceCollection AddMongoDbContext(this IServiceCollection services, APIConfiguration appConfiguration)
        {
            services.AddDbContext<EcoMetricDbContext>(options =>
            {
                options.UseMongoDB(appConfiguration.MongoDbConnectionString, appConfiguration.MongoDbDatabase);
            });
            return services;
        }
    }
}
