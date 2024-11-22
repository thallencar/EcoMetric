namespace EcoMetric.API.Responses
{
    public class RelatorioEnelResponse
    {
        public string IdRelatorioEnel { get; set; }
        public int UnidadeConsumidora { get; set; }
        public string NumeroFatura { get; set; }
        public string TipoLeitura { get; set; }
        public double ValorTotal { get; set; }
        public double ValorTarifaConsumo { get; set; }
        public double ValorTarifaImpostos { get; set; }
        public string StatusBandeiraTarifa { get; set; }
    }
}
