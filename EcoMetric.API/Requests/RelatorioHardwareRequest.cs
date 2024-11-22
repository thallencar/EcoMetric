using EcoMetric.Business.Enums;
using System.ComponentModel.DataAnnotations;

namespace EcoMetric.API.Requests
{
    public class RelatorioHardwareRequest
    {
        [Required(ErrorMessage = "O campo 'nome_setor' é obrigatório.")]
        [StringLength(255, MinimumLength = 2, ErrorMessage = "O campo 'nome_setor' deve conter entre {2} e {1} caracteres.")]
        public string NomeSetor { get; set; }

        [Required(ErrorMessage = "O campo 'qtd_kwh_setor' é obrigatório.")]
        [Range(0.0, 99999.99, ErrorMessage = "O campo 'qtd_kwh_setor' deve ser entre 0.0 e 99999.99")]
        public double QtdConsumoSetor { get; set; }

        [Required(ErrorMessage = "O campo 'porcentagem_consumo' é obrigatório.")]
        [Range(0.0, 100.0, ErrorMessage = "O campo 'porcentagem_consumo' deve ser entre 0.0 e 100.0")]
        public double PorcentagemConsumoSetor { get; set; }

        [Required(ErrorMessage = "O campo 'porcentagem_anterior' é obrigatório.")]
        [Range(0.0, 100.0, ErrorMessage = "O campo 'porcentagem_anterior' deve ser entre 0.0 e 100.0")]
        public double PorcentagemConsumoAnterior { get; set; }

        [Required(ErrorMessage = "O campo 'status_relatorio' é obrigatório.")]
        [Range(1, 2, ErrorMessage = "O campo 'status_relatorio' deve ser entre 1 e 2.")]
        public StatusRelatorioEnum StatusRelatorio { get; set; }
    }
}
