using System;
using System.Collections.Generic;
using HW3.DAL.Abstract;
using Newtonsoft.Json.Linq;

namespace HW3.Models
{
    public class GitHubUser : GitHubModel
    {
        public string UserName { get; set; }
        public string AvatarURL { get; set; }
        public string HtmlURL { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }

        public override void FromJSON(JObject a)
        {
            UserName = (string)a["login"];
            AvatarURL = (string)a["avatar_url"];
            HtmlURL = (string)a["html_url"];
            Company = (string)a["company"];
            Location = (string)a["location"];
            Email = (string)a["email"];
            Name = (string)a["name"];         
        }
    }
}
