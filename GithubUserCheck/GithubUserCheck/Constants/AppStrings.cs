using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GithubUserCheck.Constants
{
    /// <summary>
    /// All the User Interface strings are defined in this class, to:
    /// (1) Avoid hard-coding of string in the UI,
    /// (2) Enable easy changes, 
    /// (3) Enable any future translations to other languages, etc.
    /// </summary>
    public static class AppStrings
    {
        public static class Common
        {
            public static string MissingInfoDescription = "(Info not found.)";

            // TODO: Before the final release, make sure this string is not used anywhere:
            public static string NotImplementedDescription = "(Not implemented yet.)";
        }

        public static class Search
        {
            public static string WelcomeText = "Welcome!";
            public static string UsernamePromptText = "Which GitHub user would you like to check?";
            public static string UsernamePlaceholderText = "GitHub Username";
            public static string SearchButtonText = "Check";
        }
    }
}
