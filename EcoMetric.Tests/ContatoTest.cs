using EcoMetric.Business.Enums;
using EcoMetric.Business.Models;
using MongoDB.Bson;

namespace EcoMetric.Tests
{
    public class ContatoTest
    {
        private List<ContatoModel> _listaContatos;
        private readonly ContatoModel _contato;

        public ContatoTest()
        {
            _listaContatos = new List<ContatoModel>();
            _contato = new ContatoModel
            {
                IdContato = new ObjectId("64bcbaba1234567890abcdef"),
                Ddi = 55,
                Ddd = 11,
                Telefone = "123456789",
                TipoContato = TipoContatoEnum.Comercial,
                StatusContato = StatusContatoEnum.Ativo
            };
        }


        [Fact]
        public void ShouldAddContatoSuccessfully()
        {
            // Arrange
            _listaContatos.Add(_contato);

            // Assert
            Assert.Contains(_contato, _listaContatos);
        }

        [Fact]
        public void ShouldUpdateContatoSuccessfully()
        {
            // Arrange
            _listaContatos.Add(_contato);

            var contatoAtualizado = new ContatoModel
            {
                StatusContato = StatusContatoEnum.Suspenso
            };

            // Act
            var cadastroExistente = _listaContatos.FirstOrDefault(c => c.IdContato == _contato.IdContato);
            if (cadastroExistente != null)
            {
                cadastroExistente.StatusContato = contatoAtualizado.StatusContato;
            }

            // Assert
            Assert.Equal("Suspenso", cadastroExistente.StatusContato.ToString());
        }

        [Fact]
        public void ShouldDeleteContatoSuccessfully()
        {
            // Act
            _listaContatos.RemoveAll(c => c.IdContato == _contato.IdContato);

            // Assert
            Assert.DoesNotContain(_contato, _listaContatos);
        }
    }

}