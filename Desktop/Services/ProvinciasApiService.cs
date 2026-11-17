using DotNetEnv;
using Services.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Desktop.Services
{
    public class ProvinciasApiService
    {
        HttpClient httpClient;
        string urlApi;
        JsonSerializerOptions options;
        public ProvinciasApiService() { httpClient = SettingHttpClient(); options = SettingJsonSerializer(); }

        public async Task<List<Provincia>?> GetAllAsync()
        {
            try
            {
                var response = await httpClient.GetAsync("");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<List<Provincia>>(json, options);
                }
                return null;
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); return null; }
        }

        private HttpClient SettingHttpClient()
        {
            urlApi = Globales.ApiUrl + "Provincias/";
            var hc = new HttpClient(); hc.BaseAddress = new Uri(urlApi);
            hc.DefaultRequestHeaders.Add("Accept", "application/json");
            return hc;
        }
        private JsonSerializerOptions SettingJsonSerializer() => new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull, PropertyNameCaseInsensitive = true };
    }
}