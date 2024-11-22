using EcoMetric.Business.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.EntityFrameworkCore;

namespace EcoMetric.Business.Models
{
    [Collection("monitoramentos")]
    public class MonitoramentoModel
    {
        [BsonId(IdGenerator = typeof(ObjectIdGenerator))]
        [BsonElement("idMonitoramento")]
        public ObjectId IdMonitoramento { get; set; }

        [BsonElement("dataEmissao")]
        public DateTime DataEmissao { get; set; }

        [BsonElement("dataValidade")]
        public DateTime DataValidade { get; set; }

        [BsonElement("statusMonitoramento")]
        [BsonRepresentation(BsonType.String)]
        public StatusMonitoramentoEnum StatusMonitoramento { get; set; }

        [BsonElement("descricaoMonitoramento")]
        public string DescricaoMonitoramento { get; set; }

        [BsonElement("porcentagemDiferenca")]
        [BsonRepresentation(BsonType.Double)]
        public double PorcentagemDiferenca { get; set; }

        [BsonElement("porcentagemExpectativaMelhoria")]
        [BsonRepresentation(BsonType.Double)]
        public double PorcentagemExpectativaMelhoria { get; set; }

    }
}
