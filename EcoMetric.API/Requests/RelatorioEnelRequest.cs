using EcoMetric.Business.Enums;
using System.ComponentModel.DataAnnotations;

namespace EcoMetric.API.Requests
{
    public class RelatorioEnelRequest
    {
        [Required(ErrorMessage = "O campo 'unidade_consumidora' é obrigatório.")]
        [Range(0, 9999999999, ErrorMessage = "O campo 'unidade_consumidora' deve ser entre 0 e 9999999999.")]
        public int UnidadeConsumidora { get; set; }

        [Required(ErrorMessage = "O campo 'numero_fatura' é obrigatório.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "O campo 'numero_fatura' deve conter entre {2} e {1} caracteres.")]
        public string NumeroFatura { get; set; }

        [Required(ErrorMessage = "O campo 'tipo_leitura' é obrigatório.")]
        [Range(1, 2, ErrorMessage = "O campo 'tipo_leitura' deve ser entre 1 e 2.")]
        public TipoLeituraEnum TipoLeitura { get; set; }

        [Required(ErrorMessage = "O campo 'valor_total' é obrigatório.")]
        [Range(0, 99999999.99, ErrorMessage = "O campo 'valor_total' deve ser entre 0 e 99999999.99.")]
        public double ValorTotal { get; set; }

        [Required(ErrorMessage = "O campo 'valor_tarifa' é obrigatório.")]
        [Range(0, 99999999.99, ErrorMessage = "O campo 'valor_tarifa' deve ser entre 0 e 99999999.99.")]
        public double ValorTarifaConsumo { get; set; }

        [Required(ErrorMessage = "O campo 'valor_imposto' é obrigatório.")]
        [Range(0, 99999999.99, ErrorMessage = "O campo 'valor_imposto' deve ser entre 0 e 99999999.99.")]
        public double ValorTarifaImpostos { get; set; }

        [Required(ErrorMessage = "O campo 'bandeira' é obrigatório.")]
        [Range(1, 3, ErrorMessage = "O campo 'bandeira' deve ser entre 1 e 3.")]
        public StatusBandeiraTarifaEnum StatusBandeiraTarifa { get; set; }
    }
}
