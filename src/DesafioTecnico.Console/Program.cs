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

foreach (var item in comissoes)
{
    Console.WriteLine($"Vendedor: {item.Key}, Comissão: {item.Value:C}");
}