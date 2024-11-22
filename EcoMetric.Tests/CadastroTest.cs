using EcoMetric.Business.Enums;
using EcoMetric.Business.Models;
using MongoDB.Bson;

namespace EcoMetric.Tests
{
    public class CadastroTest
    {
        private List<CadastroModel> _listaCadastros;
        private readonly CadastroModel _cadastro;

        public CadastroTest()
        {
            _listaCadastros = new List<CadastroModel>();
            _cadastro = new CadastroModel
            {
                IdCadastro = new ObjectId("64bcbaba1234567890abcdef"),
                NomeEmpresa = "Tech Innovators",
                Cnpj = "12345678000190",
                InscricaoEstadual = "1234567890",
                RazaoSocial = "Tech Innovators Ltda.",
                Porte = PorteEmpresaEnum.Grande,
                DataAbertura = DateTime.UtcNow,
                Email = "contato@techinnovators.com.br",
                NomeUsuario = "admin1",
                Senha = "senha123",
                StatusUsuario = StatusUsuarioEnum.Ativo
            };
        }

        [Fact]
        public void ShouldAddCadastroSuccessfully()
        {
            // Act
            _listaCadastros.Add(_cadastro);

            // Assert
            Assert.Contains(_cadastro, _listaCadastros);
        }

        [Fact]
        public void ShouldUpdateCadastroSuccessfully()
        {
            // Arrange
            _listaCadastros.Add(_cadastro);

            var cadastroAtualizado = new CadastroModel
            {
                IdCadastro = _cadastro.IdCadastro,
                NomeEmpresa = "Updated Tech Innovators"
            };

            // Act
            var cadastroExistente = _listaCadastros.FirstOrDefault(c => c.IdCadastro == _cadastro.IdCadastro);
            if (cadastroExistente != null)
            {
                cadastroExistente.NomeEmpresa = cadastroAtualizado.NomeEmpresa;
            }

            // Assert
            Assert.Equal("Updated Tech Innovators", cadastroExistente.NomeEmpresa);
        }

        [Fact]
        public void ShouldDeleteCadastroSuccessfully()
        {
            // Act
            _listaCadastros.RemoveAll(c => c.IdCadastro == _cadastro.IdCadastro);

            // Assert
            Assert.DoesNotContain(_cadastro, _listaCadastros);
        }
    }
}
