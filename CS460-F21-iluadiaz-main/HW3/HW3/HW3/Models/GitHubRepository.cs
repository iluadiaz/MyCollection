using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using HW3.DAL.Abstract;

namespace HW3.Models
{
    public class GitHubRepository : GitHubModel
    {
        public string Name { get; set; }
        public string Owner { get; set; }
        public string HtmlURL { get; set; }
        public string FullName { get; set; }
        public string OwnerAvatarUrl { get; set; }
        public DateTime LastUpdated { get; set; }

        public override void FromJSON(JObject a)
        {
                Owner = (string)a["owner"]["login"];
                FullName = (string)a["full_name"];
                HtmlURL = (string)a["html_url"];
                OwnerAvatarUrl = (string)a["owner"]["avatar_url"];
                LastUpdated = (DateTime)a["updated_at"];
                Name = (string)a["name"];
    }
  }
}
