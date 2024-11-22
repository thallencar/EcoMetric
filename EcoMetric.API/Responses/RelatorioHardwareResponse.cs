namespace EcoMetric.API.Responses
{
    public class RelatorioHardwareResponse
    {
        public string IdRelatorioHardware { get; set; }
        public string NomeSetor { get; set; }
        public double QtdConsumoSetor { get; set; }
        public double PorcentagemConsumoSetor { get; set; }
        public double PorcentagemConsumoAnterior { get; set; }
        public string StatusRelatorio { get; set; }
    }
}
