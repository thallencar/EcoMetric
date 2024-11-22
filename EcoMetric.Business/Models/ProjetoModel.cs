using EcoMetric.Business.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.EntityFrameworkCore;

namespace EcoMetric.Business.Models
{
    [Collection("projetos")]
    public class ProjetoModel
    {
        [BsonId(IdGenerator = typeof(ObjectIdGenerator))]
        [BsonElement("idProjeto")]
        public ObjectId IdProjeto { get; set; }

        [BsonElement("nomeProjeto")]
        public string NomeProjeto { get; set; }

        [BsonElement("descricaoProjeto")]
        public string DescricaoProjeto { get; set; }

        [BsonElement("statusProjeto")]
        [BsonRepresentation(BsonType.String)]
        public StatusProjetoEnum StatusProjeto { get; set; }

        [BsonElement("pontosMelhorias")]
        public string PontosMelhorias { get; set; }

        [BsonElement("porcentagemMelhorias")]
        [BsonRepresentation(BsonType.Double)]
        public double PorcentagemMelhorias { get; set; }
    }
}
