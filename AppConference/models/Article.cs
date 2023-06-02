using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AppConference.models
{
    class Article
    {
        [JsonPropertyName("title")]
        private string title { get; set; }
        [JsonPropertyName("description")]
        private string content { get; set; }
        [JsonPropertyName("fichier")]
        private string file { get; set; }
        [JsonPropertyName("idUser")]
        private User user { get; set; }

        Article(string title, string content, string file, User user) 
        {
            this.title = title;
            this.content = content;
            this.file = file;
            this.user = user;
        }
    }
}
