using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Exam.BusinessLogic.Interfaces;
using Exam.Models.Models.UsePublicApiModel;

namespace Exam.BusinessLogic.Services
{
    public class UsePublicApiServiceBLL : IUsePublicApiService
    {
        private readonly HttpClient _httpClient;

        public UsePublicApiServiceBLL(HttpClient httpClient)
        {
         _httpClient = httpClient;
        }


        public List<UsePublicApiResponse> UsePublicApi(UsePublicApiRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetAuthToken(string personalToken)
        {
            

            var content = new StringContent("", Encoding.UTF8, "application/json");

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Token", personalToken);

            var response = await _httpClient.PostAsync("https://trackapi.thailandpost.co.th/post/api/v1/authenticate/token", content);

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();

                // Deserialize the response JSON to a JsonDocument
                using JsonDocument doc = JsonDocument.Parse(responseBody);

                // Access the root element
                JsonElement root = doc.RootElement;

                // Check if the root element contains the "token" property
                if (root.TryGetProperty("token", out JsonElement token))
                {
                    if (!token.ValueKind.Equals(JsonValueKind.Null))
                    {
                        // Check if the token is a string before calling GetString()
                        if (token.ValueKind.Equals(JsonValueKind.String))
                        {
                            return token.GetString() ?? "";
                        }
                        else
                        {
                            // Log or handle the case where the token is not a string
                            Console.WriteLine("Auth Token is not a string.");
                            return ""; // Or throw an exception, depending on your application's logic
                        }
                    }
                    else
                    {
                        Console.WriteLine("Auth Token is null.");
                        return ""; // Or throw an exception, depending on your application's logic
                    }
                }
                else
                {
                    Console.WriteLine("Failed to extract Auth Token.");
                    return ""; // Or throw an exception, depending on your application's logic
                }
            }
            else
            {
                Console.WriteLine("Failed to get Auth Token. Status code: " + response.StatusCode);
                return ""; // Or throw an exception, depending on your application's logic
            }
        }


        public async Task<string> TrackItem(string authToken, string emscode)
        {
            var requestData = new
            {
                status = "all",
                language = "TH",
                barcode = new[] { emscode }
            };

            // Serialize the request data to JSON
            var jsonRequest = JsonSerializer.Serialize(requestData);

            // Construct the request content
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            // Add the authentication token to the request headers
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Token", authToken);

            // Send the POST request to the tracking endpoint
            var response = await _httpClient.PostAsync("https://trackapi.thailandpost.co.th/post/api/v1/track", content);

            // Check if the request was successful
            if (response.IsSuccessStatusCode)
            {
                // Read the response body
                var responseBody = await response.Content.ReadAsStringAsync();

                // Log or process the tracking result
                Console.WriteLine("Tracking Result: " + responseBody);

                // Return the response body
                return responseBody;
            }
            else
            {
                // Log the failure
                Console.WriteLine("Failed to track item. Status code: " + response.StatusCode);
                return null; // Or throw an exception, depending on your application's logic
            }
        }
    }
}
