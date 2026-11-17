using DotNetEnv;
using Services.Models;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Desktop.Services
{
    public class TiposProductoService
    {
        HttpClient httpClient;
        const string urlApi = "https://sukjueyvigrcyafzppjx.supabase.co/rest/v1/tipos_producto";
        JsonSerializerOptions options;

        public TiposProductoService()
        {
            httpClient = SettingHttpClient();
            options = SettingJsonSerializer();
        }

        public async Task<List<TipoProducto>?> GetAllAsync()
        {
            try
            {
                var response = await httpClient.GetAsync(urlApi);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<List<TipoProducto>>(json, options);
                }
                throw new Exception("Error al obtener los tipos " + response.ReasonPhrase);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener tipos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public async Task<bool> AddTipoProductoAsync(TipoProducto tipo)
        {
            try
            {
                var json = JsonSerializer.Serialize(tipo, options);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("", content);
                if (response.IsSuccessStatusCode) return true;
                MessageBox.Show("Error al crear el tipo: " + response.ReasonPhrase);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear el tipo: " + ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateTipoProductoAsync(TipoProducto tipo)
        {
            try
            {
                var json = JsonSerializer.Serialize(tipo, options);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                string urlUpdate = $"?id=eq.{tipo.Id}";
                var response = await httpClient.PutAsync(urlUpdate, content);
                if (response.IsSuccessStatusCode) return true;
                MessageBox.Show("Error al actualizar el tipo: " + response.ReasonPhrase);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el tipo: " + ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteTipoProductoAsync(int? id)
        {
            try
            {
                string urlDelete = $"?id=eq.{id}";
                var response = await httpClient.DeleteAsync(urlDelete);
                if (response.IsSuccessStatusCode) return true;
                MessageBox.Show("Error al eliminar el tipo: " + response.ReasonPhrase);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el tipo: " + ex.Message);
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