using DesafioTecnico.Console.Services;

namespace DesafioTecnico.Tests
{
    public class JurosServiceTests
    {
        [Fact]
        public void CalcularJuros_DataVencimentoHoje_DeveRetornarZero()
        {
            JurosService service = new();

            decimal valor = 1000m;
            DateTime hoje = new(2026, 10, 5);

            decimal resultado = service.CalcularJuros(
                valor,
                hoje,
                hoje
            );

            Assert.Equal(0m, resultado);
        }

        [Fact]
        public void CalcularJuros_UmDiaAtraso_DeveRetornarVinteECinco()
        {
            JurosService service = new();

            decimal valor = 1000m;
            DateTime dataAtual = new(2026, 10, 5);
            DateTime dataVencimento = new(2026, 10, 4);

            decimal resultado = service.CalcularJuros(
                valor,
                dataVencimento,
                dataAtual
            );

            Assert.Equal(25m, resultado);
        }

        [Fact]
        public void CalcularJuros_TresDiasAtraso_DeveRetornarSetentaECinco()
        {
            JurosService service = new();

            decimal valor = 1000m;
            DateTime dataAtual = new(2026, 10, 5);
            DateTime dataVencimento = new(2026, 10, 2);

            decimal resultado = service.CalcularJuros(
                valor,
                dataVencimento,
                dataAtual
            );

            Assert.Equal(75m, resultado);
        }

        [Fact]
        public void CalcularJuros_DataFutura_DeveRetornarZero()
        {
            JurosService service = new();

            decimal valor = 1000m;
            DateTime dataAtual = new(2026, 10, 5);
            DateTime dataVencimento = new(2026, 10, 10);

            decimal resultado = service.CalcularJuros(
                valor,
                dataVencimento,
                dataAtual
            );

            Assert.Equal(0m, resultado);
        }

        [Fact]
        public void CalcularValorAtualizado_DeveSomarValorOriginalEJuros()
        {
            JurosService service = new();

            decimal valor = 1000m;
            decimal juros = 75m;

            decimal resultado = service.CalcularValorAtualizado(
                valor,
                juros
            );

            Assert.Equal(1075m, resultado);
        }
    }
}
