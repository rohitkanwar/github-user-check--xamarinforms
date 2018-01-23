using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GithubUserCheck.Models
{
    public partial class Plan
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("space")]
        public long Space { get; set; }

        [JsonProperty("collaborators")]
        public long Collaborators { get; set; }

        [JsonProperty("private_repos")]
        public long PrivateRepos { get; set; }
    }
}
