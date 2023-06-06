using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AppConference.models
{
    class User
    {
        [JsonPropertyName("id")]
        public int id { get; set; }
        [JsonPropertyName("name")]
        private string name { get; set; }
        [JsonPropertyName("email")]
        private string email { get; set; }
        [JsonPropertyName("password")]
        private string password { get; set; }
        [JsonPropertyName("confirm_pass")]
        private string confirmPass { get; set; }
        [JsonPropertyName("role")]
        private string role { get; set; }
        [JsonPropertyName("origin")]
        private string origin { get; set; }
        [JsonPropertyName("conference_id")]
        private Conference conference { get; set; }
        private List<Article> articles { get; set; }

       public User(string name, string email, string password, string confirmPass, string role, string origin) 
        {
            this.name = name;
            this.email = email;
            this.password = password;
            this.confirmPass = confirmPass;
            this.role = role;
            this.origin = origin;
        }

        public User(string email, string password)
        {
            this.email = email;
            this.password = password;
        }

       public User( Conference conference, List<Article> articles)
        {
            this.conference = conference;
            this.articles = articles;
        }

    }
}
