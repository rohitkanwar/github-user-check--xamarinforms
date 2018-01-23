using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GithubUserCheck.ResponseModels;
using GithubUserCheck.Constants;

namespace GithubUserCheck.DataLayer
{
    /// <summary>
    /// An in-memory copy of the most recently searched user's data.
    /// </summary>
    public class Data
    {
        public static User currentUser;
        public static List<Repo> currentUserRepos;

        // Ugly hack :)
        public static int mostRecentServiceAccessResult = AppConstants.ServiceAccessResult.Success;
    }
}
