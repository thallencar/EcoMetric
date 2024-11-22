using EcoMetric.Business.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.EntityFrameworkCore;

namespace EcoMetric.Business.Models
{
    [Collection("relatorios")]
    public class RelatorioModel
    {
        [BsonId(IdGenerator = typeof(ObjectIdGenerator))]
        [BsonElement("idRelatorio")]
        public ObjectId IdRelatorio { get; set; }

        [BsonElement("dataEmissao")]
        public DateTime DataEmissao { get; set; }

        [BsonElement("statusRelatorio")]
        [BsonRepresentation(BsonType.String)]
        public StatusRelatorioEnum StatusRelatorio { get; set; }

        [BsonElement("valorDiferencaConsumo")]
        [BsonRepresentation(BsonType.Double)]
        public double ValorDiferencaConsumo { get; set; }

        [BsonElement("justificativaAumento")]
        public string? JustificativaAumento { get; set; }
    }
}
