using DesafioTecnico.Console.Services;

VendaService vendaService = new();

string caminhoArquivo = Path.Combine(
    AppContext.BaseDirectory,
    "Data",
    "vendas.json"
);

var dados = vendaService.CarregarVendas(caminhoArquivo);

Console.WriteLine($"Quantidade de vendas carregadas: {dados.Vendas.Count}");