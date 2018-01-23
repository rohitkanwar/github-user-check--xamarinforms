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
            // Rohit: We invoke our proxy web service which in turn invokes the GitHub API:
            public static string ServicesRoot = "http://www.rohitkanwar.net/temp/mock-github-api";
            public static string UserDetailsTemplate = "/users.php?user={0}";
            public static string RepoListTemplate = "/repos.php?user={0}";

            // Rohit: Directly accessing the GitHub API from the mobile app is not working.
            //public static string ServicesRoot = "https://api.github.com";
            //public static string UserDetailsTemplate = "/users/{0}";
            //public static string RepoListTemplate = "/users/{user}/repos";
        }

        public static class ServiceAccessResult
        {
            public static int Success = 0;
            public static int NotFoundError = 1;
            public static int OtherError = 2;
            public static int Unknown = 3;
        }

    }
}
