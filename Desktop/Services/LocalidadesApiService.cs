using DotNetEnv;
using Services.Models;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Desktop.Services
{
    public class LocalidadesApiService
    {
        HttpClient httpClient;
        string urlApi;
        JsonSerializerOptions options;
        public LocalidadesApiService() { httpClient = SettingHttpClient(); options = SettingJsonSerializer(); }

        public async Task<List<Localidad>?> GetAllAsync()
        {
            try
            {
                var response = await httpClient.GetAsync("");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<List<Localidad>>(json, options);
                }
                return null;
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); return null; }
        }

        private HttpClient SettingHttpClient()
        {
            urlApi = Globales.ApiUrl + "Localidades/";
            var hc = new HttpClient(); hc.BaseAddress = new Uri(urlApi);
            hc.DefaultRequestHeaders.Add("Accept", "application/json");
            return hc;
        }
        private JsonSerializerOptions SettingJsonSerializer() => new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull, PropertyNameCaseInsensitive = true };
    }
}