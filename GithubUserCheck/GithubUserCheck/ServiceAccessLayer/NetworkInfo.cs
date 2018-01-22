using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;

namespace GithubUserCheck.ServiceAccessLayer
{
    public class NetworkInfo
    {
        private static IConnectivity connectivityStatus;

        public static bool IsConnected()
        {
            if (connectivityStatus == null)
            {
                connectivityStatus = CrossConnectivity.Current; 
            }

            return connectivityStatus.IsConnected;
        }

        public static void DisposeResources()
        {
            CrossConnectivity.Dispose();
        }
    }
}
