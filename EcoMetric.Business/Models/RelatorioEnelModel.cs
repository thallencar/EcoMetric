using EcoMetric.Business.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.EntityFrameworkCore;

namespace EcoMetric.Business.Models
{
    [Collection("relatorios_enel")]
    public class RelatorioEnelModel
    {
        [BsonId(IdGenerator = typeof(ObjectIdGenerator))]
        [BsonElement("idRelatorioEnel")]
        public ObjectId IdRelatorioEnel { get; set; }

        [BsonElement("unidadeConsumidora")]
        public int UnidadeConsumidora { get; set; }

        [BsonElement("numeroFatura")]
        public string NumeroFatura { get; set; }

        [BsonElement("tipoLeitura")]
        [BsonRepresentation(BsonType.String)]
        public TipoLeituraEnum TipoLeitura { get; set; }

        [BsonElement("valorTotal")]
        [BsonRepresentation(BsonType.Double)]
        public double ValorTotal { get; set; }

        [BsonElement("valorTarifaConsumo")]
        [BsonRepresentation(BsonType.Double)]
        public double ValorTarifaConsumo { get; set; }

        [BsonElement("valorTarifaImpostos")]
        [BsonRepresentation(BsonType.Double)]
        public double ValorTarifaImpostos { get; set; }

        [BsonElement("statusBandeiraTarifa")]
        [BsonRepresentation(BsonType.String)]
        public StatusBandeiraTarifaEnum StatusBandeiraTarifa { get; set; }
    }
}
