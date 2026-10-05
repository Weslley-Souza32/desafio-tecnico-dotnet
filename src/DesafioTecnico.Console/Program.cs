using DesafioTecnico.Console.Models;
using DesafioTecnico.Console.Services;

EstoqueService estoqueService = new();

string caminhoArquivo = Path.Combine(
    AppContext.BaseDirectory,
    "Data",
    "estoque.json"
);

var dados = estoqueService.CarregarEstoque(caminhoArquivo);

Console.WriteLine("========================================");
Console.WriteLine("          MOVIMENTAÇÃO DE ESTOQUE");
Console.WriteLine("========================================");
Console.WriteLine();

Console.WriteLine("Produtos disponíveis:");
Console.WriteLine();

foreach (var produto in dados.Estoque)
{
    Console.WriteLine(
        $"{produto.CodigoProduto} - {produto.DescricaoProduto} - Estoque: {produto.Estoque}"
    );
}

Console.WriteLine();
Console.Write("Informe o código do produto: ");

if (!int.TryParse(Console.ReadLine(), out int codigoProduto))
{
    Console.WriteLine("Código de produto inválido.");
    return;
}

Produto? produtoSelecionado = estoqueService.BuscarProdutoPorCodigo(
    dados.Estoque,
    codigoProduto
);

if (produtoSelecionado is null)
{
    Console.WriteLine("Produto não encontrado.");
    return;
}

Console.WriteLine();
Console.WriteLine("Tipo da movimentação:");
Console.WriteLine("1 - Entrada");
Console.WriteLine("2 - Saída");
Console.Write("Escolha uma opção: ");

if (!int.TryParse(Console.ReadLine(), out int tipoInformado))
{
    Console.WriteLine("Tipo de movimentação inválido.");
    return;
}

if (!Enum.IsDefined(typeof(TipoMovimentacao), tipoInformado))
{
    Console.WriteLine("Tipo de movimentação inválido.");
    return;
}

TipoMovimentacao tipo = (TipoMovimentacao)tipoInformado;

Console.Write("Informe a quantidade: ");

if (!int.TryParse(Console.ReadLine(), out int quantidade))
{
    Console.WriteLine("Quantidade inválida.");
    return;
}

Console.Write("Informe uma descrição para a movimentação: ");

string descricao = Console.ReadLine() ?? string.Empty;

try
{
    MovimentacaoEstoque movimentacao = estoqueService.MovimentarEstoque(
        produtoSelecionado,
        tipo,
        quantidade,
        descricao
    );

    Console.WriteLine();
    Console.WriteLine("Movimentação realizada com sucesso.");
    Console.WriteLine($"Id: {movimentacao.Id}");
    Console.WriteLine($"Produto: {produtoSelecionado.DescricaoProduto}");
    Console.WriteLine($"Tipo: {movimentacao.Tipo}");
    Console.WriteLine($"Quantidade: {movimentacao.Quantidade}");
    Console.WriteLine($"Descrição: {movimentacao.Descricao}");
    Console.WriteLine($"Estoque final: {produtoSelecionado.Estoque}");
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Erro: {ex.Message}");
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Erro: {ex.Message}");
}