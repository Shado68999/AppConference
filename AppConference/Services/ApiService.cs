using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace AppConference.Services
{
    class ApiService
    {
        static string BaseUrl = DeviceInfo.Platform == DevicePlatform.Android ?
                                            "https://10.0.2.2:80/ApiSharp/api/v1" : "http://localhost:8080/ApiSharp/api/v1";

        static HttpClient apiClient;
        static JsonSerializerOptions _serializerOptions;

        static ApiService()
        {
            try
            {
                apiClient = new HttpClient
                {
                    BaseAddress = new Uri(BaseUrl),
                    Timeout = new TimeSpan(0, 2, 0)
                };
                _serializerOptions = new JsonSerializerOptions
                {
                    NumberHandling = JsonNumberHandling.AllowReadingFromString,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                    PropertyNameCaseInsensitive = true,
                    WriteIndented = true
                };
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }

        public async Task<List<T>> Get<T>(string endpoint)
        {
            var response = await apiClient.GetAsync(endpoint);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<List<T>>(content, _serializerOptions);
                return result;
            }
            else
            {
                // Gérer les erreurs de l'appel API
                throw new Exception($"Error retrieving data. StatusCode: {response.StatusCode}");
            }
        }

        public async Task<T> Post<T>(string endpoint, T data)
        {
            var json = JsonSerializer.Serialize(data, _serializerOptions);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await apiClient.PostAsync(endpoint, content);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var createdData = JsonSerializer.Deserialize<T>(result, _serializerOptions);
                return createdData;
            }
            else
            {
                // Gérer les erreurs de l'appel API
                throw new Exception($"Error creating data. StatusCode: {response.StatusCode}");
            }
        }

        public async Task<T> Put<T>(string endpoint, T data)
        {
            var json = JsonSerializer.Serialize(data, _serializerOptions);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await apiClient.PutAsync(endpoint, content);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var updatedData = JsonSerializer.Deserialize<T>(result, _serializerOptions);
                return updatedData;
            }
            else
            {
                // Gérer les erreurs de l'appel API
                throw new Exception($"Error updating data. StatusCode: {response.StatusCode}");
            }
        }

        public async Task Delete(string endpoint)
        {
            var response = await apiClient.DeleteAsync(endpoint);
            if (!response.IsSuccessStatusCode)
            {
                // Gérer les erreurs de l'appel API
                throw new Exception($"Error deleting data. StatusCode: {response.StatusCode}");
            }
        }
    }
}
