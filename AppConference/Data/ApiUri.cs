using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppConference.Data
{
    class ApiUri
    {
        public static string RestUrl = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:80/ApiSharp/api/v1/{0}" : "http://localhost:8080/ApiSarp/api/v1/{0}";
        public static string NewUserUrl = "User/create";
        public static string ListUserUrl = "User/read";
        public static string ViewUserUrl = "User/view";
        public static string UpdateUserUrl = "User/update/{id}";
        public static string DeleteUserUrl = "User/delete/{id}";
        public static string NewConferenceUrl = "Conference/create";
        public static string ListConferenceUrl = "Conference/read";
        public static string ViewConferenceUrl = "Conference/view";
        public static string UpdateConferenceUrl = "Conference/update/{id}";
        public static string DeleteConferenceUrl = "Conference/delete/{id}";
        public static string NewArticleUrl = "Article/create";
        public static string ListArticleUrl = "Article/read";
        public static string ViewArticleUrl = "Article/view";
        public static string UpdateArticleUrl = "Article/update/{id}";
        public static string DeleteArticleUrl = "Article/delete/{id}";
    }
}
