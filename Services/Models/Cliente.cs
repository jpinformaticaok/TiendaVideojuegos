using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Services.Models
{
    public class Cliente
    {
        [Browsable(false)]
        [JsonPropertyName("id")]
        public int? Id { get; set; }
        [DisplayName("Fecha de creación")]
        [JsonPropertyName("created_at")]
        public DateTimeOffset? Created_at { get; set; } = DateTimeOffset.UtcNow;
        [DisplayName("Nombres")]
        [JsonPropertyName("firstname")]
        public string Firstname { get; set; } = string.Empty;
        [DisplayName("Apellidos")]
        [JsonPropertyName("lastname")]
        public string Lastname { get; set; } = string.Empty;
        [JsonPropertyName("dni")]
        public string Dni { get; set; } = string.Empty;
        [DisplayName("Dirección")]
        [JsonPropertyName("address")]
        public string Address { get; set; } = string.Empty;
        [Browsable(false)]
        [JsonPropertyName("localidad_id")]
        public int LocalidadId { get; set; } = 0;
        public Localidad? Localidad { get; set; }
        [Browsable(false)]
        [JsonPropertyName("is_deleted")]
        public bool isDeleted { get; set; } = false;
    }
}