using EcoMetric.Business.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.EntityFrameworkCore;

namespace EcoMetric.Business.Models
{
    [Collection("relatorios_hardware")]
    public class RelatorioHardwareModel
    {
        [BsonId(IdGenerator = typeof(ObjectIdGenerator))]
        [BsonElement("idRelatorioHardare")]
        public ObjectId IdRelatorioHardware { get; set; }

        [BsonElement("nomeSetor")]
        public string NomeSetor { get; set; }

        [BsonElement("qtdConsumoSetor")]
        [BsonRepresentation(BsonType.Double)]
        public double QtdConsumoSetor { get; set; }

        [BsonElement("porcentagemConsumoSetor")]
        [BsonRepresentation(BsonType.Double)]
        public double PorcentagemConsumoSetor { get; set; }

        [BsonElement("porcentagemConsumoAnterior")]
        [BsonRepresentation(BsonType.Double)]
        public double PorcentagemConsumoAnterior { get; set; }

        [BsonElement("statusRelatorio")]
        [BsonRepresentation(BsonType.String)]
        public StatusRelatorioEnum StatusRelatorio { get; set; }
    }
}
