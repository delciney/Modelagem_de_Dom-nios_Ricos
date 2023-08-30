using NerdStore.Catalogo.Domain.Entities;
using NerdStore.Catalogo.Domain.ValueObjects;
using NerdStore.Core.DomainObjects;

namespace NerdStore.Catalogo.Domain.Tests
{
    public class DimensoesTests
    {
        [Fact]
        public void Dimensoes_Validar_ValidacaoAlturaDeveRetornarExceptions()
        {
            var ex = Assert.Throws<DomainException>(() => new Dimensoes(0, 1, 1));

            Assert.Equal("O campo Altura não pode ser menor ou igual a 0", ex.Message);
        }

        [Fact]
        public void Dimensoes_Validar_ValidacaoLarguraDeveRetornarExceptions()
        {
            var ex = Assert.Throws<DomainException>(() => new Dimensoes(1, 0, 1));

            Assert.Equal("O campo Largura não pode ser menor ou igual a 0", ex.Message);
        }

        [Fact]
        public void Dimensoes_Validar_ValidacaoProfundidadeDeveRetornarExceptions()
        {
            var ex = Assert.Throws<DomainException>(() => new Dimensoes(1, 1, 0));

            Assert.Equal("O campo Profundidade não pode ser menor ou igual a 0", ex.Message);
        }
    }
}
