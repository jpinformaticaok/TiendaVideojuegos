using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Services.Models
{
    public class Provincia
    {
        [Browsable(false)]
        [JsonPropertyName("id")]
        public int? Id { get; set; }
        [DisplayName("Nombres de la provincia")]
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        [Browsable(false)]
        [JsonPropertyName("pais_id")]
        public int PaisId { get; set; } = 0;
        public Pais? Pais { get; set; } = null;
        [Browsable(false)]
        [JsonPropertyName("is_deleted")]
        public bool isDeleted { get; set; } = false;

        public override string ToString()
        {
            return Name;
        }
    }
}