using EcoMetric.Business.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.EntityFrameworkCore;

namespace EcoMetric.Business.Models
{
    [Collection("consumos_energia")]
    public class ConsumoEnergiaModel
    {
        [BsonId(IdGenerator = typeof(ObjectIdGenerator))]
        [BsonElement("idConsumo")]
        public ObjectId IdConsumoEnergia { get; set; }
        
        [BsonElement("referenciaInicial")]
        public DateTime ReferenciaInicial { get; set; }
        
        [BsonElement("referenciaFinal")]
        public DateTime ReferenciaFinal { get; set; }

        [BsonElement("dataEmissao")]
        public DateTime DataEmissao { get; set; }

        [BsonElement("dataVencimento")]
        public DateTime DataVencimento { get; set; }

        [BsonElement("statusPagamento")]
        [BsonRepresentation(BsonType.String)]
        public StatusPagamentoEnum StatusPagamento { get; set; }

        [BsonElement("qtdConsumoKwhGeral")]
        [BsonRepresentation(BsonType.Double)]
        public double QtdConsumoKwhGeral { get; set; }

        [BsonElement("qtdLeituraAnterior")]
        [BsonRepresentation(BsonType.Double)]
        public double QtdLeituraAnterior { get; set; }
    }
}
