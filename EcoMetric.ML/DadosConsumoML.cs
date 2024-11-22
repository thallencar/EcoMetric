namespace EcoMetric.ML
{
    public class DadosConsumoML
    {
        public string NomeSetor { get; set; }
        public float PorcentagemConsumoAnterior { get; set; }
        public float ValorTarifaConsumo { get; set; }
        public float ValorTarifaImpostos { get; set; }
        public float QtdConsumoSetor { get; set; }
    }

    public class PrevisaoConsumoML
    {
        public float Score { get; set; } 
    }
}
