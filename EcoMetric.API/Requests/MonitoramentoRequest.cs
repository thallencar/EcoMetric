using EcoMetric.Business.Enums;
using System.ComponentModel.DataAnnotations;

namespace EcoMetric.API.Requests
{
    public class MonitoramentoRequest
    {
        [Required(ErrorMessage = "O campo 'dt_emissao' é obrigatório.")]
        [DataType(DataType.Date, ErrorMessage = "O campo 'dt_emissao' deve ser uma data válida.")]
        public DateTime DataEmissao { get; set; }

        [Required(ErrorMessage = "O campo 'dt_validade' é obrigatório.")]
        [DataType(DataType.Date, ErrorMessage = "O campo 'dt_validade' deve ser uma data válida.")]
        public DateTime DataValidade { get; set; }

        [Required(ErrorMessage = "O campo 'status_monitoramento' é obrigatório.")]
        [Range(1, 5, ErrorMessage = "O campo 'status_monitoramento' deve ser entre 1 e 5.")]
        public StatusMonitoramentoEnum StatusMonitoramento { get; set; }

        [Required(ErrorMessage = "O campo 'descricao' é obrigatório.")]
        [StringLength(225, MinimumLength = 2, ErrorMessage = "O campo 'descricao' deve conter entre {2} e {1} caracteres.")]
        public string DescricaoMonitoramento { get; set; }


        [Required(ErrorMessage = "O campo 'porcentagem_diferenca' é obrigatório.")]
        [Range(0.0, 100.0, ErrorMessage = "O campo 'porcentagem_diferenca' deve ser entre 0.0 e 100.0")]
        public double PorcentagemDiferenca { get; set; }


        [Required(ErrorMessage = "O campo 'porcentagem_melhoria' é obrigatório.")]
        [Range(0.0, 100.0, ErrorMessage = "O campo 'porcentagem_melhoria' deve ser entre 0.0 e 100.0")]
        public double PorcentagemExpectativaMelhoria { get; set; }
    }
}
