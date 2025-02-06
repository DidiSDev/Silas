using Silas.Models.Offers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Silas.Models.Companies
{
    public class CompanyService
    {
        private readonly HttpClient _httpClient;

        public CompanyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        //AÑADE UNA COMAÑIA A LA BBDD
        public async Task<bool> CreateCompanyAsync(Company company)
        {
            var json = JsonSerializer.Serialize(company);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.PostAsync("http://volumidev.duckdns.org/silasapp/api/endpoint/createCompanyDetails.php", content);
                response.EnsureSuccessStatusCode();
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException)
            {
                return false;
            }
        }

        //RECOGE UNA COMAÑIA DE LA DE BBDD POR SU ID
        public async Task<Company> GetCompanyByIdAsync(int idUser)
        {
            try
            {
                var response = await _httpClient.GetAsync($"http://volumidev.duckdns.org/silasapp/api/endpoint/getCompanyById.php?id_user={idUser}");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var company = JsonSerializer.Deserialize<Company>(json);
                    return company;
                }
                else
                {
                    return null;
                }
            }
            catch (HttpRequestException)
            {
                return null;
            }
        }

        //ACTUALIZA LOS DATOS DE LA COPAÑIA EN LA BBDD
        public async Task<bool> UpdateCompanyAsync(Company company)
        {
            var json = JsonSerializer.Serialize(company);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.PostAsync("http://volumidev.duckdns.org/silasapp/api/endpoint/updateCompanyDetails.php", content);
                response.EnsureSuccessStatusCode();
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException)
            {
                return false;
            }
        }


        //DESACTIVA UNA COMPAÑIA EN LA BBDD
        public async Task<bool> DeactivateCompanyAsync(int idUser)
        {
            var json = JsonSerializer.Serialize(new { id_user = idUser });
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.PostAsync("http://volumidev.duckdns.org/silasapp/api/endpoint/desactivateCompany.php", content);
                response.EnsureSuccessStatusCode();
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException)
            {
                return false;
            }
        }


        //RECOGE TODAS LAS COPAÑIAS DE LA BBDD
        public async Task<List<Company>> ListAllCompaniesAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("http://volumidev.duckdns.org/silasapp/api/endpoint/listCompanies.php");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var companies = JsonSerializer.Deserialize<List<Company>>(json);
                    return companies;
                }
                else
                {
                    return null;
                }
            }
            catch (HttpRequestException)
            {
                return null;
            }
        }


        //LISTO LAS OFERTAS EN "_LeftPanelPartial" DE UNA id_company CONCRETA
        public async Task<List<Offer>> ListOffersByCompanyIdAsync(int companyId)
        {
            try
            {
                var response = await _httpClient.GetAsync(
                    $"http://volumidev.duckdns.org/silasapp/api/endpoint/listOffersByCompanyId.php?id_company={companyId}"
                );
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var offers = JsonSerializer.Deserialize<List<Offer>>(json);

                return offers ?? new List<Offer>();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return new List<Offer>();
            }
        }
    }
}
