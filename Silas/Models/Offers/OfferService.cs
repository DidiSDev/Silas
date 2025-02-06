using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Silas.Models.Offers
{
    public class OfferService
    {
        private readonly HttpClient _httpClient;

        public OfferService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Offer>> GetOffersByCompanyIdAsync(int companyId)
        {
            try
            {
                var company = companyId;
                var response = await _httpClient.GetAsync($"http://volumidev.duckdns.org/silasapp/api/endpoint/listOffersByCompanyId.php?id_company=11");
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var jsonOptions = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };
                var offers = JsonSerializer.Deserialize<List<Offer>>(json, jsonOptions);
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
