using EcoMetric.Business.Enums;
using EcoMetric.Business.Models;
using MongoDB.Bson;

namespace EcoMetric.Tests
{
    public class RelatorioEnelTest
    {
        private List<RelatorioEnelModel> _listaRelatorios;
        private readonly RelatorioEnelModel _relatorio;

        public RelatorioEnelTest()
        {
            _listaRelatorios = new List<RelatorioEnelModel>();
            _relatorio = new RelatorioEnelModel
            {
                IdRelatorioEnel = new ObjectId("64bcbaba1234567890abcdef"),
                UnidadeConsumidora = 1234567,
                NumeroFatura = "FAT001",
                TipoLeitura = TipoLeituraEnum.Celular,
                ValorTotal = 350.5,
                ValorTarifaConsumo = 300.0,
                ValorTarifaImpostos = 50.5,
                StatusBandeiraTarifa = StatusBandeiraTarifaEnum.Verde
            };
        }

        [Fact]
        public void ShouldAddRelatorioEnelSuccessfully()
        {
            _listaRelatorios.Add(_relatorio);
            Assert.Contains(_relatorio, _listaRelatorios);
        }

        [Fact]
        public void ShouldUpdateRelatorioEnelSuccessfully()
        {
            _listaRelatorios.Add(_relatorio);
            var relatorioAtualizado = new RelatorioEnelModel
            {
                ValorTotal = 400.0,
                ValorTarifaConsumo = 320.0,
                ValorTarifaImpostos = 80.0,
                StatusBandeiraTarifa = StatusBandeiraTarifaEnum.Amarela
            };

            var relatorioExistente = _listaRelatorios.FirstOrDefault(r => r.IdRelatorioEnel == _relatorio.IdRelatorioEnel);
            if (relatorioExistente != null)
            {
                relatorioExistente.ValorTotal = relatorioAtualizado.ValorTotal;
                relatorioExistente.ValorTarifaConsumo = relatorioAtualizado.ValorTarifaConsumo;
                relatorioExistente.ValorTarifaImpostos = relatorioAtualizado.ValorTarifaImpostos;
                relatorioExistente.StatusBandeiraTarifa = relatorioAtualizado.StatusBandeiraTarifa;
            }

            Assert.Equal(relatorioAtualizado.ValorTotal, relatorioExistente.ValorTotal);
        }

        [Fact]
        public void ShouldDeleteRelatorioEnelSuccessfully()
        {
            _listaRelatorios.Add(_relatorio);
            _listaRelatorios.Remove(_relatorio);
            Assert.DoesNotContain(_relatorio, _listaRelatorios);
        }
    }

}
