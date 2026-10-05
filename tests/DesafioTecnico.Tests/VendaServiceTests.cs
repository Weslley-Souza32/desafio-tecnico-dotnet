using DesafioTecnico.Console.Services;

namespace DesafioTecnico.Tests
{
    public class VendaServiceTests
    {
        [Theory]
        [InlineData(99.99, 0)]
        [InlineData(100, 1)]
        [InlineData(499.99, 4.9999)]
        [InlineData(500, 25)]
        [InlineData(1000, 50)]
        public void CalcularComissao_DeveRetornarValorCorreto(
            decimal valorVenda,
            decimal comissaoEsperada)
        {
            VendaService service = new();

            decimal resultado = service.CalcularComissao(valorVenda);

            Assert.Equal(comissaoEsperada, resultado);
        }
    }
}
