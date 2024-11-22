namespace EcoMetric.API.Responses
{
    public class RelatorioResponse
    {
        public string IdRelatorio { get; set; }
        public DateTime DataEmissao { get; set; }
        public string StatusRelatorio { get; set; }
        public double ValorDiferencaConsumo { get; set; }
        public string? JustificativaAumento { get; set; }
    }
}
