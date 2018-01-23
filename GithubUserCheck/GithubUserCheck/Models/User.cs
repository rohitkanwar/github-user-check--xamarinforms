using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GithubUserCheck.ResponseModels
{
    public class User
    {
        public string Login { get; set; }
        public long Id { get; set; }
        public string AvatarUrl { get; set; }
        public string GravatarId { get; set; }
        public string Url { get; set; }
        public string HtmlUrl { get; set; }
        public string FollowersUrl { get; set; }
        public string FollowingUrl { get; set; }
        public string GistsUrl { get; set; }
        public string StarredUrl { get; set; }
        public string SubscriptionsUrl { get; set; }
        public string OrganizationsUrl { get; set; }
        public string ReposUrl { get; set; }
        public string EventsUrl { get; set; }
        public string ReceivedEventsUrl { get; set; }
        public string Type { get; set; }
        public bool SiteAdmin { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Blog { get; set; }
        public string Location { get; set; }
        public object Email { get; set; }
        public bool Hireable { get; set; }
        public string Bio { get; set; }
        public long PublicRepos { get; set; }
        public long PublicGists { get; set; }
        public long Followers { get; set; }
        public long Following { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
