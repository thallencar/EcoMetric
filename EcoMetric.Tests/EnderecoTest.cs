using EcoMetric.Business.Models;
using MongoDB.Bson;

namespace EcoMetric.Tests
{
    public class EnderecoTest
    {
        private List<EnderecoModel> _listaEnderecos;
        private readonly EnderecoModel _endereco;

        public EnderecoTest()
        {
            _listaEnderecos = new List<EnderecoModel>();
            _endereco = new EnderecoModel
            {
                IdEndereco = new ObjectId("64bcbaba1234567890abcdef"),
                Cep = "01310-000",
                Estado = "SP",
                Cidade = "São Paulo",
                Bairro = "Bela Vista",
                Logradouro = "Av. Paulista",
                Numero = 1100
            };
        }

        [Fact]
        public void ShouldAddEnderecoSuccessfully()
        {
            _listaEnderecos.Add(_endereco);

            // Assert
            Assert.Contains(_endereco, _listaEnderecos);
        }

        [Fact]
        public void ShouldUpdateEnderecoSuccessfully()
        {
            // Arrange
            _listaEnderecos.Add(_endereco);
            var enderecoAtualizado = new EnderecoModel
            {
                Cep = "01452-000",
                Bairro = "Pinheiros",
                Logradouro = "Av. Faria Lima",
                Numero = 500
            };

            // Act
            var enderecoExistente = _listaEnderecos.FirstOrDefault(e => e.Cep == _endereco.Cep);
            if (enderecoExistente != null)
            {
                enderecoExistente.Cep = enderecoAtualizado.Cep;
                enderecoExistente.Bairro = enderecoAtualizado.Bairro;
                enderecoExistente.Logradouro = enderecoAtualizado.Logradouro;
                enderecoExistente.Numero = enderecoAtualizado.Numero;
            }

            // Assert
            Assert.Equal("01452-000", enderecoExistente.Cep);
            Assert.Equal("Pinheiros", enderecoExistente.Bairro);
            Assert.Equal("Av. Faria Lima", enderecoExistente.Logradouro);
            Assert.Equal(500, enderecoExistente.Numero);
        }

        [Fact]
        public void ShouldDeleteEnderecoSuccessfully()
        {
            _listaEnderecos.RemoveAll(e => e.IdEndereco == _endereco.IdEndereco);

            // Assert
            Assert.DoesNotContain(_endereco, _listaEnderecos);
        }
    }
}
