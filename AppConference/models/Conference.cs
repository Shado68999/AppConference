using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AppConference.models
{
    class Conference
    {
        [JsonPropertyName("id")]
        private int id { get; set; }
        [JsonPropertyName("name")]
        private string name { get; set; }
        [JsonPropertyName("sigle")]
        private string sigle { get; set; }
        [JsonPropertyName("theme")]
        private string theme { get; set; }
        [JsonPropertyName("date_Soumission")]
        private DateTime dateSoumission { get; set; }
        [JsonPropertyName("date_Resultat")]
        private DateTime dateResultat { get; set; }
        [JsonPropertyName("date_Inscription")]
        private DateTime dateInscription { get; set; }
        [JsonPropertyName("date_Deroulement")]
        private DateTime dateDeroulement { get; set; }
        private List<User> users { get; set; }

        Conference(string name, string sigle, string theme, DateTime dateSoumission, DateTime dateResultat, DateTime dateInscription, DateTime dateDeroulement, List<User> users) 
        {
            this.name = name;
            this.sigle = sigle;
            this.theme = theme;
            this.dateDeroulement = DateTime.Now;
            this.dateInscription = DateTime.Now;
            this.dateResultat = DateTime.Now;
            this.dateSoumission = DateTime.Now;
            this.users = users;
        }
    }
}
