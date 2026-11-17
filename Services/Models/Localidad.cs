using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Services.Models
{
    public class Localidad
    {
        [Browsable(false)]
        [JsonPropertyName("id")]
        public int Id { get; set; } = 0;
        [DisplayName("Nombre de la localidad")]
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        [Browsable(false)]
        [JsonPropertyName("provincia_id")]
        public int ProvinciaId { get; set; } = 0;
        public Provincia? Provincia { get; set; } = null;
        [Browsable(false)]
        [JsonPropertyName("is_deleted")]
        public bool isDeleted { get; set; } = false;

        public override string ToString()
        {
            return Name;
        }
    }
}