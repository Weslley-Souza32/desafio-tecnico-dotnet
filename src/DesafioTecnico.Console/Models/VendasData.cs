using System.Text.Json.Serialization;

namespace DesafioTecnico.Console.Models
{
    public class VendasData
    {
        [JsonPropertyName("vendas")]
        public List<Venda> Vendas { get; set; } = [];
    }
}
