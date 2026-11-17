using DotNetEnv;
using Services.Models;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Desktop.Services
{
    public class ClientesApiService
    {
        HttpClient httpClient;
        string urlApi;
        JsonSerializerOptions options;

        public ClientesApiService()
        {
            httpClient = SettingHttpClientAsync();
            options = SettingJsonSerializer();
        }

        public async Task<List<Cliente>?> GetAllAsync()
        {
            try
            {
                var response = await httpClient.GetAsync("");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<List<Cliente>>(json, options);
                }
                throw new Exception("Error al obtener los clientes " + response.ReasonPhrase);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener clientes desde la Api: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public async Task<List<Cliente>?> GetAllWithFilterAsync(string filter)
        {
            try
            {
                var response = await httpClient.GetAsync($"?filtro={filter}");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<List<Cliente>>(json, options);
                }
                throw new Exception("Error al obtener los clientes " + response.ReasonPhrase);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener clientes desde la Api: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public async Task<bool> AddClienteAsync(Cliente cliente)
        {
            try
            {
                var json = JsonSerializer.Serialize(cliente, options);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("", content);
                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Error al crear el cliente: " + response.ReasonPhrase);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear el cliente desde la Api: " + ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateClienteAsync(Cliente cliente)
        {
            try
            {
                var json = JsonSerializer.Serialize(cliente, options);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PutAsync(cliente.Id.ToString(), content);
                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Error al actualizar el cliente: " + response.ReasonPhrase);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el cliente desde la Api: " + ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteClienteAsync(int? id)
        {
            try
            {
                var response = await httpClient.DeleteAsync(id.ToString());
                if (response.IsSuccessStatusCode) return true;
                MessageBox.Show("Error al eliminar el cliente: " + response.ReasonPhrase);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el cliente desde la Api: " + ex.Message);
                return false;
            }
        }

        public async Task<bool> RestoreClienteAsync(int? id)
        {
            try
            {
                var response = await httpClient.PutAsync($"restore/{id}", null);
                if (response.IsSuccessStatusCode) return true;
                MessageBox.Show("Error al restaurar el cliente: " + response.ReasonPhrase);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al restaurar el cliente desde la Api: " + ex.Message);
                return false;
            }
        }

        private HttpClient SettingHttpClientAsync()
        {
            urlApi = Globales.ApiUrl + "Clientes/";
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(urlApi);
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
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