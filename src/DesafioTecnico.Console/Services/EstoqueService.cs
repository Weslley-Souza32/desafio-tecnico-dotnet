using DesafioTecnico.Console.Models;
using System.Text.Json;

namespace DesafioTecnico.Console.Services
{
    public class EstoqueService
    {
        public EstoqueData CarregarEstoque(string caminhoArquivo)
        {
            if (!File.Exists(caminhoArquivo))
            {
                throw new FileNotFoundException("Arquivo de estoque não encontrado.", caminhoArquivo);
            }

            string json = File.ReadAllText(caminhoArquivo);

            EstoqueData? dados = JsonSerializer.Deserialize<EstoqueData>(json);

            return dados ?? new EstoqueData();
        }
    }
}
