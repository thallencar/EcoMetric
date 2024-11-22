namespace EcoMetric.API.Responses
{
    public class MonitoramentoResponse
    {
        public string IdMonitoramento { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataValidade { get; set; }
        public string StatusMonitoramento { get; set; }
        public string DescricaoMonitoramento { get; set; }
        public double PorcentagemDiferenca { get; set; }
        public double PorcentagemExpectativaMelhoria { get; set; }
    }
}
