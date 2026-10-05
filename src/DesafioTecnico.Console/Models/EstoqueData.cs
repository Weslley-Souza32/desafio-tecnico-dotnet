using System.Text.Json.Serialization;

namespace DesafioTecnico.Console.Models
{
    public class EstoqueData
    {
        [JsonPropertyName("estoque")]
        public List<Produto> Estoque { get; set; } = [];
    }
}
