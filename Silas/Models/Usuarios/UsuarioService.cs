using System.Text;
using System.Text.Json;

namespace Silas.Models.Usuarios
{
    public class UsuarioService
    {
        private readonly HttpClient _httpClient;

        public UsuarioService(HttpClient httpClient) { 
         _httpClient = httpClient;
        }

        public async Task<bool> CrearUsuarioAsync (Usuario usuario) 
        {
           
        var json = JsonSerializer.Serialize(usuario);
        var content = new StringContent (json, Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.PostAsync("http://volumidev.duckdns.org/silasapp/api/create_user.php", content);
                response.EnsureSuccessStatusCode();
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex) { 
            Console.WriteLine ($"Error en la solicitud: {ex.Message}");
                return false;
            }
        }
    }
}
