using DesafioTecnico.Console.Services;

Console.WriteLine("Desafio Técnico .NET");

VendaService vendaService = new();

string caminhoArquivo = Path.Combine(
    AppContext.BaseDirectory,
    "Data",
    "vendas.json"
);

var dados = vendaService.CarregarVendas(caminhoArquivo);

var comissoes = vendaService.CalcularComissaoPorVendendor(dados.Vendas);

Console.WriteLine("========================================");
Console.WriteLine("       COMISSÃO DOS VENDEDORES");
Console.WriteLine("========================================");
Console.WriteLine();

foreach (var item in comissoes)
{
    Console.WriteLine($"Vendedor: {item.Key} | Comissão: {item.Value:C2}");
}


EstoqueService estoqueService = new();

string caminhoArquivoEstoque = Path.Combine(
    AppContext.BaseDirectory,
    "Data",
    "estoque.json"
);

var dadosEstoque = estoqueService.CarregarEstoque(caminhoArquivoEstoque);

Console.WriteLine($"Quantidade de produtos carregados: {dadosEstoque.Estoque.Count}");

foreach (var produto in dadosEstoque.Estoque)
{
    Console.WriteLine(
        $"{produto.CodigoProduto} - {produto.DescricaoProduto} - Estoque: {produto.Estoque}"
    );
}