namespace DesafioTecnico.Console.Services
{
    public class JurosService
    {
        private const decimal TAXA_DIARIA = 0.025m;

        public decimal CalcularJuros(decimal valor, DateTime dataVencimento, DateTime dataAtual)
        {
            if (dataAtual.Date <= dataVencimento.Date)
                return 0m;

            int diasAtraso = (dataAtual.Date - dataVencimento.Date).Days;

            return valor * TAXA_DIARIA * diasAtraso;
        }

        public decimal CalcularValorAtualizado(decimal valor, decimal juros)
        {
            return valor + juros;
        }
    }
}
