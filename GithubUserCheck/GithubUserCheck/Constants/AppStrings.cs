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
            //public static string WelcomeText = "Welcome!";
            public static string PageTitle = "GitHub User Search";
            public static string UsernamePromptText = "Which GitHub user would you like to check?";
            public static string UsernamePlaceholderText = "(GitHub Username)";
            public static string SearchButtonText = "Check";
        }

        public static class Results
        {
            public static string JoiningDateDescriptionTemplate = "Member since {0}";

            public static string NoReposDescription = "No public repos";
            public static string SolitaryRepoDescription = "1 public repo";
            public static string NumReposDescriptionTemplate = "{0} public repos";

            public static string NoGistsDescription = "No public gists";
            public static string SolitaryGistDescription = "1 public gist";
            public static string NumGistsDescriptionTemplate = "{0} public gists";

            public static string NumReposAndGistsTemplate = "{0}, {1}.";
            public static string NumFollowersFollowingTemplate = "Followers: {0}, Following: {1}.";
        }

        public static class RepoDetails
        {
            public static string UnknownRepo = "Unknown Repo";
        }
    }
}
