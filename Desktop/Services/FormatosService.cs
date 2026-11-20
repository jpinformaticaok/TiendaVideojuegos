using DotNetEnv;
using Services.Models;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Desktop.Services
{
    public class FormatosService
    {
        HttpClient httpClient;
        const string urlApi = "https://sukjueyvigrcyafzppjx.supabase.co/rest/v1/formatos";
        JsonSerializerOptions options;

        public FormatosService()
        {
            httpClient = SettingHttpClient();
            options = SettingJsonSerializer();
        }

        public async Task<List<Formato>?> GetAllAsync()
        {
            try
            {
                var response = await httpClient.GetAsync("?select=*&order=name");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<List<Formato>>(json, options);
                }
                throw new Exception("Error al obtener los formatos " + response.ReasonPhrase);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener formatos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public async Task<bool> AddFormatoAsync(Formato formato)
        {
            try
            {
                var json = JsonSerializer.Serialize(formato, options);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("", content);
                if (response.IsSuccessStatusCode) return true;
                MessageBox.Show("Error al crear el formato: " + response.ReasonPhrase);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear el formato: " + ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateFormatoAsync(Formato formato)
        {
            try
            {
                var json = JsonSerializer.Serialize(formato, options);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                string urlUpdate = $"?id=eq.{formato.Id}";
                var response = await httpClient.PutAsync(urlUpdate, content);
                if (response.IsSuccessStatusCode) return true;
                MessageBox.Show("Error al actualizar el formato: " + response.ReasonPhrase);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el formato: " + ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteFormatoAsync(int? id)
        {
            try
            {
                string urlDelete = $"?id=eq.{id}";
                var response = await httpClient.DeleteAsync(urlDelete);
                if (response.IsSuccessStatusCode) return true;
                MessageBox.Show("Error al eliminar el formato: " + response.ReasonPhrase);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el formato: " + ex.Message);
                return false;
            }
        }

        private HttpClient SettingHttpClient()
        {
            Env.Load("../../../");
            var apikey = Environment.GetEnvironmentVariable("apikey_supabase");
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(urlApi);
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            httpClient.DefaultRequestHeaders.Add("apikey", apikey);
            return httpClient;
        }

        private JsonSerializerOptions SettingJsonSerializer()
        {
            return new JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                PropertyNameCaseInsensitive = true,
            };
        }
    }
}
