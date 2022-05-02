using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HW3.Models;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Configuration;

namespace HW3.DAL.Abstract
{
    public interface IGitHubService
    {
        void SetCredentials(string username, string token);
         GitHubUser GetUser();
         IEnumerable<GitHubRepository> GetRepositories();
         GitHubRepository GetRepository(string _owner, string _repositoryName);
         IEnumerable<GitHubCommit> GetCommits(string _owner, string _repositoryName);
         IEnumerable<GitHubBranch> GetBranches(string _owner, string _repositoryName);

    }
}
