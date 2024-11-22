using EcoMetric.Business.Enums;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace EcoMetric.API.Responses
{
    public class ConsumoEnergiaResponse
    {
        public string IdConsumoEnergia { get; set; }
        public DateTime ReferenciaInicial { get; set; }
        public DateTime ReferenciaFinal { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataVencimento { get; set; }
        public string StatusPagamento { get; set; }
        public double QtdConsumoKwhGeral { get; set; }
        public double QtdLeituraAnterior { get; set; }
    }
}
