using DesafioTecnico.Console.Services;

JurosService jurosService = new();

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