using DesafioTecnico.Console.Models;
using DesafioTecnico.Console.Services;

namespace DesafioTecnico.Tests
{
    public class EstoqueServiceTests
    {
        [Fact]
        public void MovimentarEstoque_Entrada_DeveSomarQuantidadeAoEstoque()
        {
            EstoqueService service = new();

            Produto produto = new()
            {
                CodigoProduto = 101,
                DescricaoProduto = "Caneta Azul",
                Estoque = 150
            };

            service.MovimentarEstoque(
                produto,
                TipoMovimentacao.Entrada,
                20,
                "Entrada de teste"
            );

            Assert.Equal(170, produto.Estoque);
        }

        [Fact]
        public void MovimentarEstoque_Saida_DeveSubtrairQuantidadeDoEstoque()
        {
            EstoqueService service = new();

            Produto produto = new()
            {
                CodigoProduto = 101,
                DescricaoProduto = "Caneta Azul",
                Estoque = 150
            };

            service.MovimentarEstoque(
                produto,
                TipoMovimentacao.Saida,
                20,
                "Saída de teste"
            );

            Assert.Equal(130, produto.Estoque);
        }

        [Fact]
        public void MovimentarEstoque_QuantidadeZero_DeveLancarExcecao()
        {
            EstoqueService service = new();

            Produto produto = new()
            {
                CodigoProduto = 101,
                DescricaoProduto = "Caneta Azul",
                Estoque = 150
            };

            Assert.Throws<ArgumentException>(() =>
                service.MovimentarEstoque(
                    produto,
                    TipoMovimentacao.Entrada,
                    0,
                    "Teste inválido"
                )
            );
        }

        [Fact]
        public void MovimentarEstoque_SaidaMaiorQueEstoque_DeveLancarExcecao()
        {
            EstoqueService service = new();

            Produto produto = new()
            {
                CodigoProduto = 101,
                DescricaoProduto = "Caneta Azul",
                Estoque = 150
            };

            Assert.Throws<InvalidOperationException>(() =>
                service.MovimentarEstoque(
                    produto,
                    TipoMovimentacao.Saida,
                    200,
                    "Saída inválida"
                )
            );
        }
    }
}
