using System.Text;
using System.Text.Json;

namespace Silas.Models.Usuarios
{
    public class UserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient) {
            _httpClient = httpClient;
        }


        //METODO PARA LA CREACION DEL USER
        public async Task<int> AsyncCreateUser(User usuario)
        {
            //COMPROBAMOS QUE EL EMAIL NO ESTA YA EN LA BBDD

            bool emailExist = await CheckEmailExist(usuario.email);

            if (emailExist == false)
            {
                try
                {
                    //EN EL BACK INICIALIZAMOS EL STATUS A 0
                    var json = JsonSerializer.Serialize(usuario);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await _httpClient.PostAsync("http://volumidev.duckdns.org/silasapp/api/endpoint/create_user.php", content);
                    response.EnsureSuccessStatusCode();
                    return 0;
                }
                catch (HttpRequestException ex) {
                    Console.WriteLine($"Error en la solicitud: {ex.Message}");
                    return 1;
                }
            }
            else
            {

                return 2;
            }
        }


        //METODO PARA VALIDAR LA EXISTENCIA DE UN EMAIL
        public async Task<bool> CheckEmailExist(string email)
        {
            try
            {
                var requestBody = new { email = email };
                var json = JsonSerializer.Serialize(requestBody);

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PostAsync("http://volumidev.duckdns.org/silasapp/api/endpoint/exist_email.php", content);
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    EmailCheckResponse result = JsonSerializer.Deserialize<EmailCheckResponse>(responseContent);
                    return result.exist;
                }
                else
                {
                    Console.WriteLine($"Error en la solicitud: {response.StatusCode}");
                    return false;
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error en la solicitud: {ex.Message}");
                return false;
            }
        }


        public async Task<UserValidatorResponse> CheckUserCredentials(string email, string password)
        {
            try
            {
                var requestBody = new { email = email, password = password };
                var json = JsonSerializer.Serialize(requestBody);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PostAsync("http://volumidev.duckdns.org/silasapp/api/endpoint/credential_validator.php", content);
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    UserValidatorResponse result = JsonSerializer.Deserialize<UserValidatorResponse>(responseContent);
                    return result;
                }
                else
                {
                    UserValidatorResponse resp = new UserValidatorResponse(-1, -1, -1, "Credentials Error");
                    return resp;
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error en la solicitud: {ex.Message}");
                UserValidatorResponse resp = new UserValidatorResponse(-1, -1, -1, "Error");
                return resp;
            }

        }
    }
}
