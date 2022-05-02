using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;
using HW3.Models;
using HW3.DAL.Abstract;


namespace HW3.DAL.Concrete
{
    public class GitHub : IGitHubService
    {
        public string BaseSource { get; }
        public string RepoSource { get; }
        public string Username { get; set; }
        public string Token { get; set; }

        public GitHub()
        {
            BaseSource = "https://api.github.com/user";

        }

        private string SendRequest(string uri, string token, string username)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Headers.Add("Authorization", "token " + token);
            request.UserAgent = username;       // Required, see: https://developer.github.com/v3/#user-agent-required
            request.Accept = "application/json";

            string jsonString = null;
            // TODO: You should handle exceptions here
            using (WebResponse response = request.GetResponse())
            {
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                jsonString = reader.ReadToEnd();
                reader.Close();
                stream.Close();
            }
            return jsonString;
        }

        public GitHubUser GetUser()
        {
            string source = string.Format(BaseSource);
            string jsonResponse = SendRequest(BaseSource, "Token:ServiceApiKey", "iluadiaz");
            Debug.WriteLine(jsonResponse);

            JObject x = JObject.Parse(jsonResponse);

            GitHubUser t = new GitHubUser();
            t.FromJSON(x);
            
            Debug.WriteLine(t.HtmlURL);

            return t;   
        }

        public IEnumerable<GitHubRepository> GetRepositories()
        {
            string source = string.Format("https://api.github.com/user/repos");
            string jsonResponse = SendRequest(source, "Token:ServiceApiKey", "iluadiaz");
            Debug.WriteLine(jsonResponse);
            
            List<GitHubRepository> t = new List<GitHubRepository>();           
            JArray x = JArray.Parse(jsonResponse);
            GitHubRepository s = new GitHubRepository();

            foreach (JObject a in x)
            {
               
                s.FromJSON(a);
                t.Add(new GitHubRepository { Owner = s.Owner, FullName = s.FullName, HtmlURL = s.HtmlURL, OwnerAvatarUrl = s.OwnerAvatarUrl });
            }

            s = t[0];
            Debug.WriteLine(t[0].FullName);

            return t;
        }
        public void SetCredentials(string username, string token)
        {
            Username = username;
            Token = token;
        }
        public GitHubRepository GetRepository(string _owner, string _repositoryName)
        {
            List<GitHubRepository> t = new List<GitHubRepository>();
            IEnumerable<GitHubRepository> y = GetRepositories();
            GitHubRepository z= new GitHubRepository();

            foreach(GitHubRepository s in y)
            {
                if(s.Owner == _owner && s.FullName == _repositoryName)
                {
                    z = s;
                }
            }
            Debug.WriteLine(z.OwnerAvatarUrl);
            return z;
        }

        public IEnumerable<GitHubCommit> GetCommits(string _owner, string _repositoryName)
        {
            string source = string.Format($"https://api.github.com/repos/{_owner}/{_repositoryName}/commits");
            string jsonResponse = SendRequest(source, "Token:ServiceApiKey", "iluadiaz");
            Debug.WriteLine(jsonResponse);

            List<GitHubCommit> t = new List<GitHubCommit>();
            JArray x = JArray.Parse(jsonResponse);
            GitHubCommit s = new GitHubCommit();

            foreach (JObject a in x)
            {
                s.FromJSON(a);
                t.Add(new GitHubCommit { Sha = s.Sha, Committer = s.Committer, WhenCommitted = s.WhenCommitted, CommitMessage = s.CommitMessage, HtmlURL = s.HtmlURL });
            }

            s = t[0];
            Debug.WriteLine(t[0].Committer);

            return t;
        }
        public IEnumerable<GitHubBranch> GetBranches(string _owner, string _repositoryName)
        {
            string source = string.Format($"https://api.github.com/repos/{_owner}/{_repositoryName}/branches");
            string jsonResponse = SendRequest(source, "Token:ServiceApiKey", "iluadiaz");
            Debug.WriteLine(jsonResponse);

            List<GitHubBranch> t = new List<GitHubBranch>();
            JArray x = JArray.Parse(jsonResponse);
            GitHubBranch s = new GitHubBranch();

            foreach (JObject a in x)
            {
                s.FromJSON(a);
                t.Add(new GitHubBranch {Name = s.Name });
            }

            s = t[0];
            Debug.WriteLine(s.Name);

            return t;
        }

    }
}
