using DesafioTecnico.Console.Models;
using System.Text.Json;

namespace DesafioTecnico.Console.Services
{
    public class VendaService
    {
        public VendasData CarregarVendas(string caminhoArquivo)
        {
            if (!File.Exists(caminhoArquivo))
            {
                throw new FileNotFoundException("Arquivo de vendas não encontrado.", caminhoArquivo);
            }

            string json = File.ReadAllText(caminhoArquivo);

            VendasData? dados = JsonSerializer.Deserialize<VendasData>(json);

            return dados ?? new VendasData();
        }

        public decimal CalcularComissao(decimal valorVenda)
        {
            if (valorVenda < 100m)
                return 0m;

            if (valorVenda < 500m)
                return valorVenda * 0.01m;

            return valorVenda * 0.05m;
        }

        public Dictionary<string, decimal> CalcularComissaoPorVendendor(List<Venda> vendas)
        {
            var commisaoPorVendedor = vendas
                .GroupBy(v => v.Vendedor)
                .ToDictionary(
                    g => g.Key,
                    g => g.Sum(v => CalcularComissao(v.Valor))
                );

            return commisaoPorVendedor;
        }
    }
}
