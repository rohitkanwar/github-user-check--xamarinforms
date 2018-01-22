using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

using GithubUserCheck.Constants;
using GithubUserCheck.ResponseModels;
using GithubUserCheck.DataLayer;
using System.Net;
using System.IO;

namespace GithubUserCheck.ServiceAccessLayer
{
    /// <summary>
    /// Encapsulates access to network (web) services. Provides a simple API for accessing these services.
    /// </summary>
    public class NetworkManager
    {
        HttpClient client;

        // The data retrieved from the most recent web service access:
        User user;
        List<Repo> userRepos;

        // Private constructor
        private NetworkManager()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 1048576; // 1 MB
        }

        // Public static property to access an instance of this class.
        private static NetworkManager _instance;
        public static NetworkManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new NetworkManager();
                }
                return _instance;
            }
            private set { _instance = value; }
        }

        // Instance methods:
        public async Task<bool> GetUserAndReposData(string username)
        {
            bool userDataFound = false;
            bool reposDataFound = false;
            bool success = false;
 
            userDataFound = await GetUserData(username);
            if (userDataFound)
            {
                // TODO: Imple.
                //reposDataFound = await GetReposData(username);
                // TODO: remove hardcoding
                reposDataFound = true;
            }

            if ((userDataFound) && (reposDataFound))
            {
                Data.currentUser = user;
                Data.currentUserRepos = userRepos;
                success = true;
            }

            return success;
        }

        private async Task<bool> GetUserData(string username)
        {
            bool success = false;

            Debug.WriteLine("GetUserData called.");

            string resourceUrlString = AppConstants.Urls.ServicesRoot + string.Format(AppConstants.Urls.UserDetailsTemplate, username);

            // TODO: Delete hard-coding, and use the real API.
            resourceUrlString = "http://www.rohitkanwar.net/temp/mock-github-api/users.php";

            Debug.WriteLine("GetUserData: URL string is: {0}", resourceUrlString);

            try
            {
                Uri uri = new Uri(resourceUrlString);

                var response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("GetUserData: Received success status code");

                    var content = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrWhiteSpace(content))
                    {
                        Debug.WriteLine("GetUserData: content length = {0}, content = {1}", content.Length, content);

                        user = JsonConvert.DeserializeObject<User>(content);

                        if (user != null)
                        {
                            // We successfully got the user data.
                            success = true;
                        }
                        else
                        {
                            // There was a response, but it could not be deserialized as expected.
                            success = false;
                        }
                    }
                    else
                    {
                        // The response did not have a message body.
                        success = false;
                    }
                }
                else if (response.StatusCode.Equals(System.Net.HttpStatusCode.NotFound))
                {
                    // 404 Not Found. Most probably, the user doesn't exist.

                    Debug.WriteLine("GetUserData: Received status code 404");

                    // TODO: Inform the user that no such github user was found.
                    success = false;
                }
                else
                {
                    // Some other error.

                    Debug.WriteLine("GetUserData: Received error status code: {0}, reason: {1}", response.StatusCode, response.ReasonPhrase);
                    success = false;
                }
            }
            catch(Exception e)
            {
                // There was a problem using the web service.

                Debug.WriteLine("GetUserData: Exception: Msg = {0}, \nStackTrace = {1}", e.Message, e.StackTrace);
                success = false;
            }

            return success;
        }

        //private async Task<bool> GetUserData2(string username)
        //{
        //    bool success = false;

        //    Debug.WriteLine("GetUserData2 called.");

        //    string resourceUrlString = AppConstants.Urls.ServicesRoot + string.Format(AppConstants.Urls.UserDetailsTemplate, username);
        //    Debug.WriteLine("GetUserData2: resourceUrlString={0}", resourceUrlString);

        //    try
        //    {
        //        var request = HttpWebRequest.Create(resourceUrlString);
        //        var response = (HttpWebResponse)await Task.Factory.FromAsync<WebResponse>(request.BeginGetResponse, request.EndGetResponse, null);

        //        Debug.WriteLine("GetUserData2: response.StatusCode = {0}, StatusDescription = {1}", response.StatusCode, response.StatusDescription);

        //        // TODO: If request failed, inform user of error, and manage state:
        //        if (response.StatusCode != HttpStatusCode.OK)
        //        {
        //            Debug.WriteLine("GetUserData2: received error. response.StatusCode = {0}, StatusDescription = {1}", response.StatusCode, response.StatusDescription);
        //            success = false;
        //        }
        //        else
        //        {
        //            // We received a success response.
        //            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
        //            {
        //                string content = await reader.ReadToEndAsync();
        //                Debug.WriteLine("GetUserData2: Success. response content = {0}", content);

        //                // TODO: Set this value only after successful deserializing.
        //                success = true;
        //            }
        //        }
        //    }
        //    catch(Exception e)
        //    {
        //        // There was a problem using the web service.

        //        Debug.WriteLine("GetUserData2: Exception: Msg = {0}, \nStackTrace = {1}", e.Message, e.StackTrace);
        //        success = false;
        //    }

        //    return success;
        //}
    }
}
