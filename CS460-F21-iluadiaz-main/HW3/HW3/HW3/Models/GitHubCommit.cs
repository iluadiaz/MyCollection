using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using HW3.DAL.Abstract;

namespace HW3.Models
{
    public class GitHubCommit : GitHubModel
    {
        public string Sha { get; set; }
        public string Committer { get; set; }
        public DateTime WhenCommitted { get; set; }
        public string CommitMessage { get; set; }
        public string HtmlURL { get; set; }

        public override void FromJSON(JObject a)
        {
            Sha = (string)a["sha"];
            Committer = (string)a["commit"]["committer"]["name"];
            HtmlURL = (string)a["commit"]["url"];
            WhenCommitted = (DateTime)a["commit"]["committer"]["date"];
            CommitMessage = (string)a["message"];
        }
    }
}
