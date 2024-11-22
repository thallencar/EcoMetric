using EcoMetric.Business.Enums;
using EcoMetric.Business.Models;
using MongoDB.Bson;

namespace EcoMetric.Tests
{
    public class ProjetoTest
    {
        private List<ProjetoModel> _listaProjetos;
        private readonly ProjetoModel _projeto;

        public ProjetoTest()
        {
            _listaProjetos = new List<ProjetoModel>();
            _projeto = new ProjetoModel
            {
                IdProjeto = new ObjectId("64bcbaba1234567890abcdef"),
                NomeProjeto = "Projeto Sustentabilidade",
                DescricaoProjeto = "Redução do consumo de energia.",
                StatusProjeto = StatusProjetoEnum.EmDesenvolvimento,
                PontosMelhorias = "Automação de processos.",
                PorcentagemMelhorias = 25.0
            };
        }

        [Fact]
        public void ShouldAddProjetoSuccessfully()
        {
            _listaProjetos.Add(_projeto);
            Assert.Contains(_projeto, _listaProjetos);
        }

        [Fact]
        public void ShouldUpdateProjetoSuccessfully()
        {
            _listaProjetos.Add(_projeto);
            var projetoAtualizado = new ProjetoModel
            {
                NomeProjeto = "Projeto Renovação",
                DescricaoProjeto = "Incorporação de fontes renováveis.",
                StatusProjeto = StatusProjetoEnum.Concluido,
                PontosMelhorias = "Instalação de painéis solares.",
                PorcentagemMelhorias = 35.0
            };

            var projetoExistente = _listaProjetos.FirstOrDefault(p => p.IdProjeto == _projeto.IdProjeto);
            if (projetoExistente != null)
            {
                projetoExistente.NomeProjeto = projetoAtualizado.NomeProjeto;
                projetoExistente.DescricaoProjeto = projetoAtualizado.DescricaoProjeto;
                projetoExistente.StatusProjeto = projetoAtualizado.StatusProjeto;
                projetoExistente.PontosMelhorias = projetoAtualizado.PontosMelhorias;
                projetoExistente.PorcentagemMelhorias = projetoAtualizado.PorcentagemMelhorias;
            }

            Assert.Equal(projetoAtualizado.NomeProjeto, projetoExistente.NomeProjeto);
        }

        [Fact]
        public void ShouldDeleteProjetoSuccessfully()
        {
            _listaProjetos.Add(_projeto);
            _listaProjetos.Remove(_projeto);
            Assert.DoesNotContain(_projeto, _listaProjetos);
        }
    }

}
