using EcoMetric.Business.Enums;
using EcoMetric.Business.Models;
using MongoDB.Bson;

namespace EcoMetric.Tests
{
    public class ConsumoEnergiaTest
    {
        private List<ConsumoEnergiaModel> _listaConsumosEnergia;
        private readonly ConsumoEnergiaModel _consumoEnergia;

        public ConsumoEnergiaTest()
        {
            _listaConsumosEnergia = new List<ConsumoEnergiaModel>();
            _consumoEnergia = new ConsumoEnergiaModel
            {
                IdConsumoEnergia = new ObjectId("64bcbaba1234567890abcdef"),
                ReferenciaInicial = DateTime.UtcNow - TimeSpan.FromDays(2),
                ReferenciaFinal = DateTime.UtcNow,
                DataEmissao = DateTime.UtcNow - TimeSpan.FromDays(4),
                DataVencimento = DateTime.UtcNow + TimeSpan.FromDays(5),
                StatusPagamento = StatusPagamentoEnum.Pago,
                QtdConsumoKwhGeral = 350.5,
                QtdLeituraAnterior = 330.0
            };
        }

        [Fact]
        public void ShouldAddConsumoEnergiaSuccessfully()
        {
            // Act
            _listaConsumosEnergia.Add(_consumoEnergia);

            // Assert
            Assert.Contains(_consumoEnergia, _listaConsumosEnergia);
        }

        [Fact]
        public void ShouldUpdateConsumoEnergiaSuccessfully()
        {
            // Arrange
            _listaConsumosEnergia.Add(_consumoEnergia);

            var consumoAtualizado = new ConsumoEnergiaModel
            {
                ReferenciaInicial = DateTime.UtcNow - TimeSpan.FromDays(3), 
                QtdConsumoKwhGeral = 400.0 
            };

            // Act
            var consumoExistente = _listaConsumosEnergia.FirstOrDefault(c => c.IdConsumoEnergia == _consumoEnergia.IdConsumoEnergia);
            if (consumoExistente != null)
            {
                consumoExistente.ReferenciaInicial = consumoAtualizado.ReferenciaInicial;
                consumoExistente.QtdConsumoKwhGeral = consumoAtualizado.QtdConsumoKwhGeral;
            }

            // Assert
            var toleranciaAtraso = TimeSpan.FromSeconds(1); 
            Assert.InRange(consumoExistente.ReferenciaInicial, consumoAtualizado.ReferenciaInicial - toleranciaAtraso, consumoAtualizado.ReferenciaInicial + toleranciaAtraso);
            Assert.Equal(400.0, consumoExistente.QtdConsumoKwhGeral);
        }

        [Fact]
        public void ShouldDeleteConsumoEnergiaSuccessfully()
        {
            // Arrange
            var consumos = new List<ConsumoEnergiaModel> { _consumoEnergia };

            // Act
            consumos.RemoveAll(c => c.IdConsumoEnergia == _consumoEnergia.IdConsumoEnergia);

            // Assert
            Assert.DoesNotContain(_consumoEnergia, consumos);
        }
    }
}
