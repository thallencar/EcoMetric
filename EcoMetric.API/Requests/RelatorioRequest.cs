using EcoMetric.Business.Enums;
using System.ComponentModel.DataAnnotations;

namespace EcoMetric.API.Requests
{
    public class RelatorioRequest
    {
        [Required(ErrorMessage = "O campo 'dt_emissao' é obrigatório.")]
        [DataType(DataType.Date, ErrorMessage = "O campo 'dt_emissao' deve ser uma data válida.")]
        public DateTime DataEmissao { get; set; }

        [Required(ErrorMessage = "O campo 'status_relatorio' é obrigatório.")]
        [Range(1, 2, ErrorMessage = "O campo 'status_relatorio' deve ser entre 1 e 2.")]
        public StatusRelatorioEnum StatusRelatorio { get; set; }

        [Required(ErrorMessage = "O campo 'diferenca_consumo' é obrigatório.")]
        [Range(0, 99999999.99, ErrorMessage = "O campo 'diferenca_consumo' deve ser entre 0 e 99999999.99.")]
        public double ValorDiferencaConsumo { get; set; }

        [StringLength(255, MinimumLength = 2, ErrorMessage = "O campo 'justificativa' deve conter entre {2} e {1} caracteres.")]
        public string? JustificativaAumento { get; set; }
    }
}
