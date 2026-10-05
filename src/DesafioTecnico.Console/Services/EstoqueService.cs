using DesafioTecnico.Console.Models;
using System.Text.Json;

namespace DesafioTecnico.Console.Services
{
    public class EstoqueService
    {
        public EstoqueData CarregarEstoque(string caminhoArquivo)
        {
            if (!File.Exists(caminhoArquivo))
            {
                throw new FileNotFoundException("Arquivo de estoque não encontrado.", caminhoArquivo);
            }

            string json = File.ReadAllText(caminhoArquivo);

            EstoqueData? dados = JsonSerializer.Deserialize<EstoqueData>(json);

            return dados ?? new EstoqueData();
        }

        public Produto? BuscarProdutoPorCodigo(List<Produto> produtos, int codigoProduto)
        {
            return produtos.FirstOrDefault(produto => produto.CodigoProduto == codigoProduto);
        }

        public MovimentacaoEstoque MovimentarEstoque(Produto produto, TipoMovimentacao tipo, int quantidade, string descricao)
        {
            if (tipo == TipoMovimentacao.Entrada)
                produto.Estoque += quantidade;

            else if (tipo == TipoMovimentacao.Saida)
                produto.Estoque -= quantidade;

            return new MovimentacaoEstoque
            {
                Id = Guid.NewGuid(),
                CodigoProduto = produto.CodigoProduto,
                Tipo = tipo,
                Quantidade = quantidade,
                Descricao = descricao
            };
        }
    }
}
