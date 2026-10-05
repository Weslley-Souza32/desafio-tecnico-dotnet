using DesafioTecnico.Console.Models;
using DesafioTecnico.Console.Services;

VendaService vendaService = new();
EstoqueService estoqueService = new();
JurosService jurosService = new();

while (true)
{
    Console.Clear();

    Console.WriteLine("========================================");
    Console.WriteLine("          DESAFIO TÉCNICO .NET");
    Console.WriteLine("========================================");
    Console.WriteLine();
    Console.WriteLine("1 - Comissão de vendedores");
    Console.WriteLine("2 - Movimentação de estoque");
    Console.WriteLine("3 - Cálculo de juros por atraso");
    Console.WriteLine("0 - Sair");
    Console.WriteLine();

    Console.Write("Escolha uma opção: ");

    string? opcao = Console.ReadLine();

    Console.Clear();

    switch (opcao)
    {
        case "1":
            ExibirComissoes();
            break;

        case "2":
            MovimentarEstoque();
            break;

        case "3":
            CalcularJuros();
            break;

        case "0":
            return;

        default:
            Console.WriteLine("Opção inválida.");
            break;
    }

    Console.WriteLine();
    Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
    Console.ReadKey();
}

void ExibirComissoes()
{
    string caminhoArquivo = Path.Combine(
        AppContext.BaseDirectory,
        "Data",
        "vendas.json"
    );

    var dados = vendaService.CarregarVendas(caminhoArquivo);

    var comissoes = vendaService.CalcularComissaoPorVendedor(
        dados.Vendas
    );

    Console.WriteLine("========================================");
    Console.WriteLine("       COMISSÃO DOS VENDEDORES");
    Console.WriteLine("========================================");
    Console.WriteLine();

    foreach (var item in comissoes)
    {
        Console.WriteLine(
            $"Vendedor: {item.Key} | Comissão: {item.Value:C2}"
        );
    }
}

void MovimentarEstoque()
{
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
}

void CalcularJuros()
{
    Console.WriteLine("========================================");
    Console.WriteLine("         CÁLCULO DE JUROS POR ATRASO");
    Console.WriteLine("========================================");
    Console.WriteLine();

    Console.Write("Informe o valor original: R$ ");

    if (!decimal.TryParse(Console.ReadLine(), out decimal valor))
    {
        Console.WriteLine("Valor inválido.");
        return;
    }

    Console.Write("Informe a data de vencimento (dd/MM/yyyy): ");

    if (!DateTime.TryParse(
        Console.ReadLine(),
        out DateTime dataVencimento))
    {
        Console.WriteLine("Data de vencimento inválida.");
        return;
    }

    DateTime dataAtual = DateTime.Today;

    int diasEmAtraso = 0;

    if (dataAtual.Date > dataVencimento.Date)
    {
        diasEmAtraso = (dataAtual.Date - dataVencimento.Date).Days;
    }

    decimal juros = jurosService.CalcularJuros(
        valor,
        dataVencimento,
        dataAtual
    );

    decimal valorAtualizado = jurosService.CalcularValorAtualizado(
        valor,
        juros
    );

    Console.WriteLine();
    Console.WriteLine("========================================");
    Console.WriteLine("              RESULTADO");
    Console.WriteLine("========================================");

    Console.WriteLine($"Valor original: {valor:C2}");
    Console.WriteLine($"Data de vencimento: {dataVencimento:dd/MM/yyyy}");
    Console.WriteLine($"Data atual: {dataAtual:dd/MM/yyyy}");
    Console.WriteLine($"Dias em atraso: {diasEmAtraso}");
    Console.WriteLine($"Juros: {juros:C2}");
    Console.WriteLine($"Valor atualizado: {valorAtualizado:C2}");
}