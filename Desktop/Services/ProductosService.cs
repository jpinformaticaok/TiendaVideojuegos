using DotNetEnv;
using Services.Models;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Desktop.Services
{
    public class ProductosService
    {
        HttpClient httpClient;
        const string urlApi = "https://sukjueyvigrcyafzppjx.supabase.co/rest/v1/productos";
        JsonSerializerOptions options;

        public ProductosService()
        {
            httpClient = SettingHttpClient();
            options = SettingJsonSerializer();
        }

        public async Task<List<Producto>?> GetAllAsync()
        {
            try
            {
                var response = await httpClient.GetAsync("?select=*,tipo_producto:tipos_producto(*),plataforma:plataformas(*),formato:formatos(*)");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<List<Producto>>(json, options);
                }
                throw new Exception("Error al obtener los productos " + response.ReasonPhrase);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public async Task<List<Producto>?> GetAllWithFilterAsync(string filter)
        {
            try
            {
                string filtrosupabase = $"?select=*,tipo_producto:tipos_producto(*),plataforma:plataformas(*),formato:formatos(*)&or=(name.ilike.*{filter}*,description.ilike.*{filter}*)";
                var response = await httpClient.GetAsync(filtrosupabase);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<List<Producto>>(json, options);
                }
                throw new Exception("Error al obtener los productos " + response.ReasonPhrase);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public async Task<bool> AddProductoAsync(Producto producto)
        {
            try
            {
                var json = JsonSerializer.Serialize(producto, options);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("", content);
                if (response.IsSuccessStatusCode) return true;
                MessageBox.Show("Error al crear el producto: " + response.ReasonPhrase);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear el producto: " + ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateProductoAsync(Producto producto)
        {
            try
            {
                var json = JsonSerializer.Serialize(producto, options);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                string urlUpdate = $"?id=eq.{producto.Id}";
                var response = await httpClient.PutAsync(urlUpdate, content);
                if (response.IsSuccessStatusCode) return true;
                MessageBox.Show("Error al actualizar el producto: " + response.ReasonPhrase);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el producto: " + ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteProductoAsync(int? id)
        {
            try
            {
                string urlDelete = $"?id=eq.{id}";
                var response = await httpClient.DeleteAsync(urlDelete);
                if (response.IsSuccessStatusCode) return true;
                MessageBox.Show("Error al eliminar el producto: " + response.ReasonPhrase);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el producto: " + ex.Message);
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