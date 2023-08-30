using NerdStore.Catalogo.Domain.Entities;
using NerdStore.Catalogo.Domain.ValueObjects;
using NerdStore.Core.DomainObjects;

namespace NerdStore.Catalogo.Domain.Tests
{
    public class ProdutoTests
    {
        [Fact]
        public void Produto_Validar_ValidacaoNomeDeveRetornarExceptions()
        {
            var ex = Assert.Throws<DomainException>(() =>
                new Produto(string.Empty, "Descricao", false, 100, Guid.NewGuid(), DateTime.Now, "Imagem", new Dimensoes(1, 1, 1))
            );

            Assert.Equal("O campo Nome do produto não pode estar vazio", ex.Message);
        }

        [Fact]
        public void Produto_Validar_ValidacaoDescricaoDeveRetornarExceptions()
        {
            var ex = Assert.Throws<DomainException>(() =>
                new Produto("Nome", string.Empty, false, 100, Guid.NewGuid(), DateTime.Now, "Imagem", new Dimensoes(1, 1, 1))
            );

            Assert.Equal("O campo Descrição do produto não pode estar vazio", ex.Message);
        }

        [Fact]
        public void Produto_Validar_ValidacaoValorDeveRetornarExceptions()
        {
            var ex = Assert.Throws<DomainException>(() =>
                new Produto("Nome", "Descricao", false, 0, Guid.NewGuid(), DateTime.Now, "Imagem", new Dimensoes(1, 1, 1))
            );

            Assert.Equal("O campo Valor do produto não pode ser menor ou igual a 0", ex.Message);
        }

        [Fact]
        public void Produto_Validar_ValidacaoCategoriaIdDeveRetornarExceptions()
        {
            var ex = Assert.Throws<DomainException>(() =>
                new Produto("Nome", "Descricao", false, 100, Guid.Empty, DateTime.Now, "Imagem", new Dimensoes(1, 1, 1))
            );

            Assert.Equal("O campo CategoriaId do produto não pode estar vazio", ex.Message);
        }

        [Fact]
        public void Produto_Validar_ValidacaoImagemDeveRetornarExceptions()
        {
            var ex = Assert.Throws<DomainException>(() =>
                new Produto("Nome", "Descricao", false, 100, Guid.NewGuid(), DateTime.Now, string.Empty, new Dimensoes(1, 1, 1))
            );

            Assert.Equal("O campo Imagem do produto não pode estar vazio", ex.Message);
        }
    }
}
