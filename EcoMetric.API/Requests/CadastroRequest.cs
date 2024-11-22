using EcoMetric.Business.Enums;
using System.ComponentModel.DataAnnotations;

namespace EcoMetric.API.Requests
{
    public class CadastroRequest
    {
        [Required(ErrorMessage = "O campo 'nome_empresa' é obrigatório.")]
        [StringLength(255, MinimumLength = 2, ErrorMessage = "O campo 'nome_empresa' deve conter entre {2} e {1} caracteres.")]
        public string NomeEmpresa { get; set; }

        [Required(ErrorMessage = "O campo 'cnpj' é obrigatório.")]
        [StringLength(20, MinimumLength = 14, ErrorMessage = "O campo 'cnpj' deve conter entre {2} e {1} caracteres.")]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "O campo 'inscricao_estadual' é obrigatório.")]
        [StringLength(15, MinimumLength = 8, ErrorMessage = "O campo 'inscricao_estadual' deve conter entre {2} e {1} caracteres.")]
        public string InscricaoEstadual { get; set; }

        [Required(ErrorMessage = "O campo 'razao_social' é obrigatório.")]
        [StringLength(255, MinimumLength = 2, ErrorMessage = "O campo 'razao_social' deve conter entre {2} e {1} caracteres.")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "O campo 'porte' é obrigatório.")]
        [Range(1, 3, ErrorMessage = "O campo 'porte' deve ser entre 1 e 3.")]
        public PorteEmpresaEnum Porte { get; set; }

        [Required(ErrorMessage = "O campo 'data_abertura' é obrigatório.")]
        [DataType(DataType.Date, ErrorMessage = "O campo 'data_abertura' deve ser uma data válida.")]
        public DateTime DataAbertura { get; set; }

        [Required(ErrorMessage = "O campo 'email' é obrigatório.")]
        [StringLength(255, MinimumLength = 2, ErrorMessage = "O campo 'email' deve conter entre {2} e {1} caracteres.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo 'usuario' é obrigatório.")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "O campo 'usuario' deve conter entre 2 e 25 caracteres.")]
        public string NomeUsuario { get; set; }

        [Required(ErrorMessage = "O campo 'senha' é obrigatório.")]
        [StringLength(16, MinimumLength = 2, ErrorMessage = "O campo 'senha' deve conter entre 2 e 16 caracteres.")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "O campo 'status_usuario' é obrigatório.")]
        [Range(1, 5, ErrorMessage = "O campo 'status_usuario' deve ser entre 1 e 5.")]
        public StatusUsuarioEnum StatusUsuario { get; set; }
    }
}
