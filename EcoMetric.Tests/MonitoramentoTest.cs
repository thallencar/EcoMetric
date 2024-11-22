using EcoMetric.Business.Enums;
using EcoMetric.Business.Models;
using MongoDB.Bson;

namespace EcoMetric.Tests
{
    public class MonitoramentoTest
    {
        private List<MonitoramentoModel> _listaMonitoramentos;
        private readonly MonitoramentoModel _monitoramento;

        public MonitoramentoTest()
        {
            _listaMonitoramentos = new List<MonitoramentoModel>();
            _monitoramento = new MonitoramentoModel
            {
                IdMonitoramento = new ObjectId("64bcbaba1234567890abcdef"),
                DataEmissao = DateTime.UtcNow.AddDays(-30), 
                DataValidade = DateTime.UtcNow,
                StatusMonitoramento = StatusMonitoramentoEnum.Concluido,
                DescricaoMonitoramento = "Monitoramento concluído com sucesso.",
                PorcentagemDiferenca = 15.5, 
                PorcentagemExpectativaMelhoria = 10.0 
            };
        }

        [Fact]
        public void ShouldAddMonitoramentoSuccessfully()
        {
            _listaMonitoramentos.Add(_monitoramento);

            // Assert
            Assert.Contains(_monitoramento, _listaMonitoramentos);
        }

        [Fact]
        public void ShouldUpdateMonitoramentoSuccessfully()
        {
            // Arrange
            _listaMonitoramentos.Add(_monitoramento);

            var monitoramentoAtualizado = new MonitoramentoModel
            {
                DataValidade = DateTime.UtcNow.AddMonths(1), 
                StatusMonitoramento = StatusMonitoramentoEnum.EmAndamento,
                DescricaoMonitoramento = "Monitoramento atualizado e pendente.",
                PorcentagemDiferenca = 20.0, 
                PorcentagemExpectativaMelhoria = 25.0 
            };

            // Act
            var monitoramentoExistente = _listaMonitoramentos.FirstOrDefault(m => m.IdMonitoramento == _monitoramento.IdMonitoramento);
            if (monitoramentoExistente != null)
            {
                monitoramentoExistente.DataValidade = monitoramentoAtualizado.DataValidade;
                monitoramentoExistente.StatusMonitoramento = monitoramentoAtualizado.StatusMonitoramento;
                monitoramentoExistente.DescricaoMonitoramento = monitoramentoAtualizado.DescricaoMonitoramento;
                monitoramentoExistente.PorcentagemDiferenca = monitoramentoAtualizado.PorcentagemDiferenca;
                monitoramentoExistente.PorcentagemExpectativaMelhoria = monitoramentoAtualizado.PorcentagemExpectativaMelhoria;
            }

            // Assert
            Assert.Equal(monitoramentoAtualizado.DataValidade, monitoramentoExistente.DataValidade);
            Assert.Equal(monitoramentoAtualizado.StatusMonitoramento, monitoramentoExistente.StatusMonitoramento);
            Assert.Equal(monitoramentoAtualizado.DescricaoMonitoramento, monitoramentoExistente.DescricaoMonitoramento);
            Assert.Equal(monitoramentoAtualizado.PorcentagemDiferenca, monitoramentoExistente.PorcentagemDiferenca);
            Assert.Equal(monitoramentoAtualizado.PorcentagemExpectativaMelhoria, monitoramentoExistente.PorcentagemExpectativaMelhoria);
        }

        [Fact]
        public void ShouldDeleteMonitoramentoSuccessfully()
        {
            // Act
            _listaMonitoramentos.RemoveAll(m => m.IdMonitoramento == _monitoramento.IdMonitoramento);

            // Assert
            Assert.DoesNotContain(_monitoramento, _listaMonitoramentos);
        }
    }
}
