using EcoMetric.Business.Enums;
using System.ComponentModel.DataAnnotations;

namespace EcoMetric.API.Requests
{
    public class ContatoRequest
    {
        [Required(ErrorMessage = "O campo 'ddi' é obrigatório.")]
        [RegularExpression(@"^\d{1,3}$", ErrorMessage = "O campo 'ddi' deve conter entre 1 e 3 caracteres.")]
        public int Ddi { get; set; }

        [Required(ErrorMessage = "O campo 'ddd' é obrigatório.")]
        [RegularExpression(@"^\d{1,3}$", ErrorMessage = "O campo 'ddd' deve conter entre 1 e 3 caracteres.")]
        public int Ddd { get; set; }

        [Required(ErrorMessage = "O campo 'telefone' é obrigatório.")]
        [StringLength(10, MinimumLength = 9, ErrorMessage = "O campo 'telefone' deve conter entre {2} e {1} caracteres.")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O campo 'tipo_contato' é obrigatório.")]
        [Range(1, 6, ErrorMessage = "O campo 'tipo_contato' deve ser entre 1 e 6.")]
        public TipoContatoEnum TipoContato { get; set; }

        [Required(ErrorMessage = "O campo 'status' é obrigatório.")]
        [Range(1, 4, ErrorMessage = "O campo 'status' deve ser entre 1 e 4.")]
        public StatusContatoEnum StatusContato { get; set; }
    }
}
