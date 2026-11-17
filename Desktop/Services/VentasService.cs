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
            httpVentas.DefaultRequestHeaders.Add("Prefer", "return=representation");
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

                var ventaPayload = new Dictionary<string, object?>
                {
                    ["number"] = venta.Number,
                    ["date"] = venta.Date,
                    ["cliente_id"] = venta.ClienteId,
                    ["total"] = venta.Total,
                    ["is_deleted"] = false
                };
                var vjson = JsonSerializer.Serialize(ventaPayload, options);
                var content = new StringContent(vjson, Encoding.UTF8, "application/json");
                var response = await httpVentas.PostAsync("", content);
                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Error al crear la venta: " + response.ReasonPhrase);
                    return false;
                }

                var respJson = await response.Content.ReadAsStringAsync();
                var creadas = JsonSerializer.Deserialize<List<Venta>>(respJson, options);
                int ventaId = creadas?.FirstOrDefault()?.Id ?? 0;
                if (ventaId == 0)
                {
                    MessageBox.Show("No se pudo obtener el ID de la venta creada.");
                    return false;
                }

                foreach (var d in venta.Detalles)
                {
                    d.VentaId = ventaId;
                    var detallePayload = new Dictionary<string, object?>
                    {
                        ["venta_id"] = d.VentaId,
                        ["producto_id"] = d.ProductoId,
                        ["quantity"] = d.Quantity,
                        ["unit_price"] = d.UnitPrice,
                        ["subtotal"] = d.Subtotal
                    };
                    var dj = JsonSerializer.Serialize(detallePayload, options);
                    var dc = new StringContent(dj, Encoding.UTF8, "application/json");
                    var detalleResponse = await httpDetalles.PostAsync("", dc);
                    if (!detalleResponse.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Error al crear el detalle de la venta: " + detalleResponse.ReasonPhrase);
                        return false;
                    }
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