using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Services.Models
{
    public class Pais
    {
        [Browsable(false)]
        [JsonPropertyName("id")]
        public int? Id { get; set; }
        [DisplayName("Nombre del Pais")]
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        [Browsable(false)]
        [JsonPropertyName("is_deleted")]
        public bool isDeleted { get; set; } = false;

        public override string ToString()
        {
            return Name;
        }
    }
}