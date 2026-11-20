using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Services.Models
{
    public class Producto
    {
        [Browsable(false)]
        [JsonPropertyName("id")]
        public int? Id { get; set; }
        [DisplayName("Nombre")]
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        [DisplayName("Descripción")]
        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;
        [DisplayName("Precio")]
        [JsonPropertyName("price")]
        public decimal Price { get; set; }
        [DisplayName("Stock")]
        [JsonPropertyName("stock")]
        public int Stock { get; set; }
        [DisplayName("Imagen")]
        [JsonPropertyName("image_url")]
        public string ImageUrl { get; set; } = string.Empty;
        [Browsable(false)]
        [JsonPropertyName("tipo_producto_id")]
        public int TipoProductoId { get; set; }
        public TipoProducto? TipoProducto { get; set; }
        [Browsable(false)]
        [JsonPropertyName("plataforma_id")]
        public int PlataformaId { get; set; }
        public Plataforma? Plataforma { get; set; }
        [Browsable(false)]
        [JsonPropertyName("formato_id")]
        public int FormatoId { get; set; }
        public Formato? Formato { get; set; }
        [Browsable(false)]
        [JsonPropertyName("created_at")]
        public DateTimeOffset? Created_at { get; set; } = DateTimeOffset.UtcNow;
        [Browsable(false)]
        [JsonPropertyName("is_deleted")]
        public bool isDeleted { get; set; } = false;
    }
}