using EcoMetric.Business.Enums;
using System.ComponentModel.DataAnnotations;

namespace EcoMetric.API.Requests
{
    public class ConsumoEnergiaRequest
    {
        [Required(ErrorMessage = "O campo 'dt_inicial' é obrigatório.")]
        [DataType(DataType.Date, ErrorMessage = "O campo 'dt_inicial' deve ser uma data válida.")]
        public DateTime ReferenciaInicial { get; set; }

        [Required(ErrorMessage = "O campo 'dt_final' é obrigatório.")]
        [DataType(DataType.Date, ErrorMessage = "O campo 'dt_final' deve ser uma data válida.")]
        public DateTime ReferenciaFinal { get; set; }

        [Required(ErrorMessage = "O campo 'dt_emissao' é obrigatório.")]
        [DataType(DataType.Date, ErrorMessage = "O campo 'dt_emissao' deve ser uma data válida.")]
        public DateTime DataEmissao { get; set; }

        [Required(ErrorMessage = "O campo 'dt_vencimento' é obrigatório.")]
        [DataType(DataType.Date, ErrorMessage = "O campo 'dt_vencimento' deve ser uma data válida.")]
        public DateTime DataVencimento { get; set; }

        [Required(ErrorMessage = "O campo 'status_pagamento' é obrigatório.")]
        [Range(1, 6, ErrorMessage = "O campo 'status_pagamento' deve ser entre 1 e 6.")]
        public StatusPagamentoEnum StatusPagamento { get; set; }

        [Required(ErrorMessage = "O campo 'qtd_kwh_geral' é obrigatório.")]
        [Range(0.0, 99999.99, ErrorMessage = "O campo 'qtd_kwh_geral' deve ser entre 0.0 e 99999.99")]
        public double QtdConsumoKwhGeral { get; set; }

        [Required(ErrorMessage = "O campo 'qtd_leitura_anterior' é obrigatório.")]
        [Range(0.0, 99999.99, ErrorMessage = "O campo 'qtd_leitura_anterior' deve ser entre 0.0 e 99999.99")]
        public double QtdLeituraAnterior { get; set; }
    }
}
