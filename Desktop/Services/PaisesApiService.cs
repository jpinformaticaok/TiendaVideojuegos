using DotNetEnv;
using Services.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Desktop.Services
{
    public class PaisesApiService
    {
        HttpClient httpClient;
        string urlApi;
        JsonSerializerOptions options;
        public PaisesApiService() { httpClient = SettingHttpClient(); options = SettingJsonSerializer(); }

        public async Task<List<Pais>?> GetAllAsync()
        {
            try
            {
                var response = await httpClient.GetAsync("");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<List<Pais>>(json, options);
                }
                return null;
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); return null; }
        }

        private HttpClient SettingHttpClient()
        {
            urlApi = Globales.ApiUrl + "Paises/";
            var hc = new HttpClient(); hc.BaseAddress = new Uri(urlApi);
            hc.DefaultRequestHeaders.Add("Accept", "application/json");
            return hc;
        }
        private JsonSerializerOptions SettingJsonSerializer() => new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull, PropertyNameCaseInsensitive = true };
    }
}