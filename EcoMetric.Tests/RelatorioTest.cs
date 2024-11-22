using EcoMetric.Business.Enums;
using EcoMetric.Business.Models;
using MongoDB.Bson;

namespace EcoMetric.Tests
{
    public class RelatorioTest
    {
        private List<RelatorioModel> _listaRelatorios;
        private readonly RelatorioModel _relatorio;

        public RelatorioTest()
        {
            _listaRelatorios = new List<RelatorioModel>();
            _relatorio = new RelatorioModel
            {
                IdRelatorio = new ObjectId("64bcbaba1234567890abcdef"),
                DataEmissao = DateTime.UtcNow,
                StatusRelatorio = StatusRelatorioEnum.Excedente,
                ValorDiferencaConsumo = 50.0,
                JustificativaAumento = "Aumento devido ao uso excessivo."
            };
        }

        [Fact]
        public void ShouldAddRelatorioSuccessfully()
        {
            _listaRelatorios.Add(_relatorio);
            Assert.Contains(_relatorio, _listaRelatorios);
        }

        [Fact]
        public void ShouldUpdateRelatorioSuccessfully()
        {
            _listaRelatorios.Add(_relatorio);
            var relatorioAtualizado = new RelatorioModel
            {
                StatusRelatorio = StatusRelatorioEnum.LimiteEstipulado,
                ValorDiferencaConsumo = 30.0,
                JustificativaAumento = "Redução de consumo."
            };

            var relatorioExistente = _listaRelatorios.FirstOrDefault(r => r.IdRelatorio == _relatorio.IdRelatorio);
            if (relatorioExistente != null)
            {
                relatorioExistente.StatusRelatorio = relatorioAtualizado.StatusRelatorio;
                relatorioExistente.ValorDiferencaConsumo = relatorioAtualizado.ValorDiferencaConsumo;
                relatorioExistente.JustificativaAumento = relatorioAtualizado.JustificativaAumento;
            }

            Assert.Equal(relatorioAtualizado.StatusRelatorio, relatorioExistente.StatusRelatorio);
        }

        [Fact]
        public void ShouldDeleteRelatorioSuccessfully()
        {
            _listaRelatorios.Add(_relatorio);
            _listaRelatorios.Remove(_relatorio);
            Assert.DoesNotContain(_relatorio, _listaRelatorios);
        }
    }

}
