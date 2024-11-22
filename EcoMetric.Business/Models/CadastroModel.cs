using EcoMetric.Business.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.EntityFrameworkCore;

namespace EcoMetric.Business.Models
{
    [Collection("cadastros")]
    public class CadastroModel
    {
        [BsonId(IdGenerator = typeof(ObjectIdGenerator))]
        [BsonElement("idCadastro")]
        public ObjectId IdCadastro { get; set; }

        [BsonElement("nomeEmpresa")]
        public string NomeEmpresa { get; set; }

        [BsonElement("cnpj")]
        public string Cnpj { get; set; }

        [BsonElement("incricaEstadual")]
        public string InscricaoEstadual { get; set; }

        [BsonElement("razaoSocial")]
        public string RazaoSocial { get; set; }

        [BsonElement("porte")]
        [BsonRepresentation(BsonType.String)]
        public PorteEmpresaEnum? Porte { get; set; }

        [BsonElement("dataAbertura")]
        public DateTime DataAbertura { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("nomeUsuario")]
        public string NomeUsuario { get; set; }

        [BsonElement("senha")]
        public string Senha { get; set; }

        [BsonElement("statusUsuario")]
        [BsonRepresentation(BsonType.String)]
        public StatusUsuarioEnum StatusUsuario { get; set; }
    }
}
