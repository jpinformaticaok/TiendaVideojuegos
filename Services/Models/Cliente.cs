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
        [DisplayName("Localidad")]
        [JsonPropertyName("localidad")]
        public string Localidad { get; set; } = string.Empty;
        [DisplayName("Provincia")]
        [JsonPropertyName("provincia")]
        public string Provincia { get; set; } = string.Empty;
        [DisplayName("País")]
        [JsonPropertyName("pais")]
        public string Pais { get; set; } = string.Empty;
        [Browsable(false)]
        [JsonPropertyName("is_deleted")]
        public bool isDeleted { get; set; } = false;

        public override string ToString()
        {
            return $"{Firstname} {Lastname}".Trim();
        }
    }
}