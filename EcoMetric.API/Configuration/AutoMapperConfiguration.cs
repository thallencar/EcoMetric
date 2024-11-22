using AutoMapper;
using EcoMetric.API.Requests;
using EcoMetric.API.Responses;
using EcoMetric.Business.Models;

namespace EcoMetric.API.Configuration
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<CadastroModel, CadastroRequest>().ReverseMap();
            CreateMap<CadastroModel, CadastroResponse>().ReverseMap();

            CreateMap<ConsumoEnergiaModel, ConsumoEnergiaRequest>().ReverseMap();
            CreateMap<ConsumoEnergiaModel, ConsumoEnergiaResponse>().ReverseMap();

            CreateMap<ContatoModel, ContatoRequest>().ReverseMap();
            CreateMap<ContatoModel, ContatoResponse>().ReverseMap();

            CreateMap<EnderecoModel, EnderecoRequest>().ReverseMap();
            CreateMap<EnderecoModel, EnderecoResponse>().ReverseMap();

            CreateMap<MonitoramentoModel, MonitoramentoRequest>().ReverseMap();
            CreateMap<MonitoramentoModel, MonitoramentoResponse>().ReverseMap();

            CreateMap<ProjetoModel, ProjetoRequest>().ReverseMap();
            CreateMap<ProjetoModel, ProjetoResponse>().ReverseMap();

            CreateMap<RelatorioEnelModel, RelatorioEnelRequest>().ReverseMap();
            CreateMap<RelatorioEnelModel, RelatorioEnelResponse>().ReverseMap();

            CreateMap<RelatorioHardwareModel, RelatorioHardwareRequest>().ReverseMap();
            CreateMap<RelatorioHardwareModel, RelatorioHardwareResponse>().ReverseMap();

            CreateMap<RelatorioModel, RelatorioRequest>().ReverseMap();
            CreateMap<RelatorioModel, RelatorioResponse>().ReverseMap();
        }
    }
}
