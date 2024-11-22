using EcoMetric.Business.Enums;
using EcoMetric.Business.Models;
using MongoDB.Bson;

namespace EcoMetric.Tests
{
    public class RelatorioHardwareTest
    {
        private List<RelatorioHardwareModel> _listaRelatorios;
        private readonly RelatorioHardwareModel _relatorio;

        public RelatorioHardwareTest()
        {
            _listaRelatorios = new List<RelatorioHardwareModel>();
            _relatorio = new RelatorioHardwareModel
            {
                IdRelatorioHardware = new ObjectId("64bcbaba1234567890abcdef"),
                NomeSetor = "TI",
                QtdConsumoSetor = 1200.0,
                PorcentagemConsumoSetor = 60.0,
                PorcentagemConsumoAnterior = 50.0,
                StatusRelatorio = StatusRelatorioEnum.Excedente
            };
        }

        [Fact]
        public void ShouldAddRelatorioHardwareSuccessfully()
        {
            _listaRelatorios.Add(_relatorio);
            Assert.Contains(_relatorio, _listaRelatorios);
        }

        [Fact]
        public void ShouldUpdateRelatorioHardwareSuccessfully()
        {
            _listaRelatorios.Add(_relatorio);
            var relatorioAtualizado = new RelatorioHardwareModel
            {
                QtdConsumoSetor = 1000.0,
                PorcentagemConsumoSetor = 55.0,
                StatusRelatorio = StatusRelatorioEnum.LimiteEstipulado
            };

            var relatorioExistente = _listaRelatorios.FirstOrDefault(r => r.IdRelatorioHardware == _relatorio.IdRelatorioHardware);
            if (relatorioExistente != null)
            {
                relatorioExistente.QtdConsumoSetor = relatorioAtualizado.QtdConsumoSetor;
                relatorioExistente.PorcentagemConsumoSetor = relatorioAtualizado.PorcentagemConsumoSetor;
                relatorioExistente.StatusRelatorio = relatorioAtualizado.StatusRelatorio;
            }

            Assert.Equal(relatorioAtualizado.QtdConsumoSetor, relatorioExistente.QtdConsumoSetor);
        }

        [Fact]
        public void ShouldDeleteRelatorioHardwareSuccessfully()
        {
            _listaRelatorios.Add(_relatorio);
            _listaRelatorios.Remove(_relatorio);
            Assert.DoesNotContain(_relatorio, _listaRelatorios);
        }
    }

}
