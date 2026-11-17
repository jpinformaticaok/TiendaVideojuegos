using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Services.Models
{
    public class Venta
    {
        [Browsable(false)]
        [JsonPropertyName("id")]
        public int? Id { get; set; }
        [DisplayName("Número")]
        [JsonPropertyName("number")]
        public string Number { get; set; } = string.Empty;
        [DisplayName("Fecha")]
        [JsonPropertyName("date")]
        public DateTimeOffset Date { get; set; } = DateTimeOffset.UtcNow;
        [Browsable(false)]
        [JsonPropertyName("cliente_id")]
        public int? ClienteId { get; set; }
        public Cliente? Cliente { get; set; }
        [DisplayName("Total")]
        [JsonPropertyName("total")]
        public decimal Total { get; set; }
        [Browsable(false)]
        [JsonPropertyName("is_deleted")]
        public bool isDeleted { get; set; } = false;
        public List<DetalleVenta> Detalles { get; set; } = new();
    }
}