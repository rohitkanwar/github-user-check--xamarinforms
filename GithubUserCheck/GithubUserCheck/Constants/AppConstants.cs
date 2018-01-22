using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GithubUserCheck.Constants
{
    public class AppConstants
    {
        public static class Urls
        {
            public static string ServicesRoot = "https://api.github.com";
            public static string UserDetailsTemplate = "/users/{0}";
            public static string RepoListTemplate = "/users/{user}/repos";
        }
    }
}
