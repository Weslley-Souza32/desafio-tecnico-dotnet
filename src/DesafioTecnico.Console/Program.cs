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