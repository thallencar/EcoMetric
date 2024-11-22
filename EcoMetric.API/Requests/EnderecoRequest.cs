using System.ComponentModel.DataAnnotations;

namespace EcoMetric.API.Requests
{
    public class EnderecoRequest
    {
        [Required(ErrorMessage = "O campo 'cep' é obrigatório.")]
        [StringLength(10, MinimumLength = 8, ErrorMessage = "O campo 'cep' deve conter entre {2} e {1} caracteres.")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "O campo 'estado' é obrigatório.")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "O campo 'estado' deve conter 2 caracteres.")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "O campo 'cidade' é obrigatório.")]
        [StringLength(80, MinimumLength = 2, ErrorMessage = "O campo 'cidade' deve conter entre {2} e {1} caracteres.")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O campo 'bairro' é obrigatório.")]
        [StringLength(80, MinimumLength = 2, ErrorMessage = "O campo 'bairro' deve conter entre {2} e {1} caracteres.")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O campo 'logradouro' é obrigatório.")]
        [StringLength(125, MinimumLength = 2, ErrorMessage = "O campo 'logradouro' deve conter entre {2} e {1} caracteres.")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "O campo 'numero' é obrigatório.")]
        [RegularExpression(@"^\d{1,5}$", ErrorMessage = "O campo 'numero' deve conter entre 1 e 5 caracteres.")]
        public int Numero { get; set; }

        [StringLength(125, MinimumLength = 2, ErrorMessage = "O campo 'complemento' deve conter entre {2} e {1} caracteres.")]
        public string? Complemento { get; set; }

        [StringLength(225, MinimumLength = 2, ErrorMessage = "O campo 'ponto_referencia' deve conter entre {2} e {1} caracteres.")]
        public string? PontoReferencia { get; set; }
    }
}
