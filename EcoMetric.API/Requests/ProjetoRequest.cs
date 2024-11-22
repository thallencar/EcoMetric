using EcoMetric.Business.Enums;
using System.ComponentModel.DataAnnotations;

namespace EcoMetric.API.Requests
{
    public class ProjetoRequest
    {
        [Required(ErrorMessage = "O campo 'nome_projeto' é obrigatório.")]
        [StringLength(80, MinimumLength = 2, ErrorMessage = "O campo 'nome_projeto' deve conter entre {2} e {1} caracteres.")]
        public string NomeProjeto { get; set; }

        [Required(ErrorMessage = "O campo 'descricao_projeto' é obrigatório.")]
        [StringLength(255, MinimumLength = 2, ErrorMessage = "O campo 'descricao_projeto' deve conter entre {2} e {1} caracteres.")]
        public string DescricaoProjeto { get; set; }

        [Required(ErrorMessage = "O campo 'status_projeto' é obrigatório.")]
        [Range(1, 6, ErrorMessage = "O campo 'status_projeto' deve ser entre 1 e 6.")]
        public StatusProjetoEnum StatusProjeto { get; set; }

        [Required(ErrorMessage = "O campo 'pontos_melhorias' é obrigatório.")]
        [StringLength(255, MinimumLength = 2, ErrorMessage = "O campo 'pontos_melhorias' deve conter entre {2} e {1} caracteres.")]
        public string PontosMelhorias { get; set; }

        [Required(ErrorMessage = "O campo 'porcentagem_melhoria' é obrigatório.")]
        [Range(0.0, 100.0, ErrorMessage = "O campo 'porcentagem_melhoria' deve ser entre 0.0 e 100.0.")]
        public double PorcentagemMelhorias { get; set; }
    }
}
