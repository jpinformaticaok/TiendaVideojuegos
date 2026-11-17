using DotNetEnv;
using Services.Models;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Desktop.Services
{
    public class VentasService
    {
        HttpClient httpVentas;
        HttpClient httpDetalles;
        const string urlVentas = "https://sukjueyvigrcyafzppjx.supabase.co/rest/v1/ventas";
        const string urlDetalles = "https://sukjueyvigrcyafzppjx.supabase.co/rest/v1/detalles_venta";
        JsonSerializerOptions options;

        public VentasService()
        {
            Env.Load("../../../");
            var apikey = Environment.GetEnvironmentVariable("apikey_supabase");
            httpVentas = new HttpClient { BaseAddress = new Uri(urlVentas) };
            httpVentas.DefaultRequestHeaders.Add("Accept", "application/json");
            httpVentas.DefaultRequestHeaders.Add("apikey", apikey);
            httpDetalles = new HttpClient { BaseAddress = new Uri(urlDetalles) };
            httpDetalles.DefaultRequestHeaders.Add("Accept", "application/json");
            httpDetalles.DefaultRequestHeaders.Add("apikey", apikey);
            options = new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull, PropertyNameCaseInsensitive = true };
        }

        public async Task<List<Venta>?> GetAllAsync()
        {
            try
            {
                var response = await httpVentas.GetAsync(urlVentas + "?select=*,cliente:clientes(*),detalles:detalles_venta(*,producto:productos(*))");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<List<Venta>>(json, options);
                }
                throw new Exception("Error al obtener las ventas " + response.ReasonPhrase);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener ventas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public async Task<bool> AddVentaAsync(Venta venta)
        {
            try
            {
                // generar numero
                var existing = await GetAllAsync();
                int next = (existing?.Count ?? 0) + 1;
                venta.Number = $"FAC-{next:D5}";
                venta.Date = DateTimeOffset.UtcNow;

                decimal total = 0;
                foreach (var d in venta.Detalles)
                {
                    d.Subtotal = d.Quantity * d.UnitPrice;
                    total += d.Subtotal;
                }
                venta.Total = total;

                var json = JsonSerializer.Serialize(venta, new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull, PropertyNameCaseInsensitive = true });
                // remove Detalles from venta payload (send separately)
                var ventaPayload = new { venta.Number, venta.Date, cliente_id = venta.ClienteId, venta.Total, venta.isDeleted };
                var vjson = JsonSerializer.Serialize(ventaPayload, options);
                var content = new StringContent(vjson, Encoding.UTF8, "application/json");
                var response = await httpVentas.PostAsync("", content);
                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Error al crear la venta: " + response.ReasonPhrase);
                    return false;
                }
                // get created venta id from response
                var respJson = await response.Content.ReadAsStringAsync();
                var created = JsonSerializer.Deserialize<Venta>(respJson, options);
                int ventaId = created?.Id ?? 0;

                foreach (var d in venta.Detalles)
                {
                    d.VentaId = ventaId;
                    var dj = JsonSerializer.Serialize(d, options);
                    var dc = new StringContent(dj, Encoding.UTF8, "application/json");
                    await httpDetalles.PostAsync("", dc);
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear la venta: " + ex.Message);
                return false;
            }
        }
    }
}