using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using AppConference.models;
using System.Net.Http;
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

        public static async Task<User> Login(User user)
        {
            var url = $"{BaseUrl}/User/login";

            var jsonContent = JsonSerializer.Serialize(user, _serializerOptions);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await apiClient.PostAsync(url, httpContent);
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var loggedInUser = JsonSerializer.Deserialize<User>(responseContent, _serializerOptions);
                return loggedInUser;
            }
            else
            {
                return null;
            }
        }

        public static async Task<User> CreateUser(User user)
        {
            var url = $"{BaseUrl}/User/create";

            using (var httpClient = new HttpClient())
            {
                var jsonContent = JsonSerializer.Serialize(user, _serializerOptions);
                var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(url, httpContent);
                Debug.WriteLine("code",response);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var createdUser = JsonSerializer.Deserialize<User>(responseContent, _serializerOptions);
                    return createdUser;
                }
                else
                {
                    return null;
                }
            }
        }


        public static async Task<List<User>> ReadUsers()
        {
            var url = $"{BaseUrl}/User/read";

            var response = await apiClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var users = JsonSerializer.Deserialize<List<User>>(responseContent, _serializerOptions);
                return users;
            }
            else
            {
                return null;
            }
        }

        public static async Task<User> GetUserById(long id)
        {
            var url = $"{BaseUrl}/User/get/{id}";

            var response = await apiClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var user = JsonSerializer.Deserialize<User>(responseContent, _serializerOptions);
                return user;
            }
            else
            {
                return null;
            }
        }

        public static async Task<User> UpdateUser(long id, User user)
        {
            var url = $"{BaseUrl}/User/update/{id}";

            var jsonContent = JsonSerializer.Serialize(user, _serializerOptions);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await apiClient.PutAsync(url, httpContent);
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var updatedUser = JsonSerializer.Deserialize<User>(responseContent, _serializerOptions);
                return updatedUser;
            }
            else
            {
                return null;
            }
        }

        public static async Task<string> DeleteUser(long id)
        {
            var url = $"{BaseUrl}/User/delete/{id}";

            var response = await apiClient.DeleteAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return "Utilisateur supprimé avec succès !";
            }
            else
            {
                return "Une erreur s'est produite lors de la suppression de l'utilisateur.";
            }
        }

        public static async Task<Conference> CreateConference(Conference conference)
        {
            var url = $"{BaseUrl}/Conference/create";

            var jsonContent = JsonSerializer.Serialize(conference, _serializerOptions);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await apiClient.PostAsync(url, httpContent);
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var createdConference = JsonSerializer.Deserialize<Conference>(responseContent, _serializerOptions);
                return createdConference;
            }
            else
            {
                return null;
            }
        }

        public static async Task<List<Conference>> ReadConferences()
        {
            var url = $"{BaseUrl}/Conference/read";

            var response = await apiClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var conferences = JsonSerializer.Deserialize<List<Conference>>(responseContent, _serializerOptions);
                return conferences;
            }
            else
            {
                return null;
            }
        }

        public static async Task<Conference> UpdateConference(long id, Conference conference)
        {
            var url = $"{BaseUrl}/Conference/update/{id}";

            var jsonContent = JsonSerializer.Serialize(conference, _serializerOptions);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await apiClient.PutAsync(url, httpContent);
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var updatedConference = JsonSerializer.Deserialize<Conference>(responseContent, _serializerOptions);
                return updatedConference;
            }
            else
            {
                return null;
            }
        }

        public static async Task<string> DeleteConference(long id)
        {
            var url = $"{BaseUrl}/Conference/delete/{id}";

            var response = await apiClient.DeleteAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return "Conférence supprimée avec succès !";
            }
            else
            {
                return "Une erreur s'est produite lors de la suppression de la conférence.";
            }
        }

        public static async Task<Article> CreateArticle(Article article)
        {
            var url = $"{BaseUrl}/Article/create";

            var jsonContent = JsonSerializer.Serialize(article, _serializerOptions);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await apiClient.PostAsync(url, httpContent);
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var createdArticle = JsonSerializer.Deserialize<Article>(responseContent, _serializerOptions);
                return createdArticle;
            }
            else
            {
                return null;
            }
        }

        public static async Task<List<Article>> ReadArticles()
        {
            var url = $"{BaseUrl}/Article/read";

            var response = await apiClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var articles = JsonSerializer.Deserialize<List<Article>>(responseContent, _serializerOptions);
                return articles;
            }
            else
            {
                return null;
            }
        }

        public static async Task<Article> UpdateArticle(long id, Article article)
        {
            var url = $"{BaseUrl}/Article/update/{id}";

            var jsonContent = JsonSerializer.Serialize(article, _serializerOptions);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await apiClient.PutAsync(url, httpContent);
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var updatedArticle = JsonSerializer.Deserialize<Article>(responseContent, _serializerOptions);
                return updatedArticle;
            }
            else
            {
                return null;
            }
        }

        public static async Task<string> DeleteArticle(long id)
        {
            var url = $"{BaseUrl}/Article/delete/{id}";

            var response = await apiClient.DeleteAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return "Article supprimé avec succès !";
            }
            else
            {
                return "Une erreur s'est produite lors de la suppression de l'article.";
            }
        }
    }
}
