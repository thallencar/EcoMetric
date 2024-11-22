using EcoMetric.Business.Enums;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace EcoMetric.API.Responses
{
    public class CadastroResponse
    {
        public string IdCadastro { get; set; }
        public string NomeEmpresa { get; set; }
        public string Cnpj { get; set; }
        public string InscricaoEstadual { get; set; }
        public string RazaoSocial { get; set; }
        public string? Porte { get; set; }
        public DateTime DataAbertura { get; set; }
        public string Email { get; set; }
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }
        public string StatusUsuario { get; set; }
    }
}
