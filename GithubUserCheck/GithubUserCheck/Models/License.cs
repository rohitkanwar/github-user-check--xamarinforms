using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GithubUserCheck.ResponseModels
{
    public class License
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public string SpdxId { get; set; }
        public string Url { get; set; }
    }
}
