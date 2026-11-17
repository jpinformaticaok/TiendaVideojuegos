using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Services.Models
{
    public class DetalleVenta
    {
        [Browsable(false)]
        [JsonPropertyName("id")]
        public int? Id { get; set; }
        [Browsable(false)]
        [JsonPropertyName("venta_id")]
        public int VentaId { get; set; }
        public Venta? Venta { get; set; }
        [Browsable(false)]
        [JsonPropertyName("producto_id")]
        public int ProductoId { get; set; }
        public Producto? Producto { get; set; }
        [DisplayName("Cantidad")]
        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }
        [DisplayName("Precio unitario")]
        [JsonPropertyName("unit_price")]
        public decimal UnitPrice { get; set; }
        [DisplayName("Subtotal")]
        [JsonPropertyName("subtotal")]
        public decimal Subtotal { get; set; }
    }
}