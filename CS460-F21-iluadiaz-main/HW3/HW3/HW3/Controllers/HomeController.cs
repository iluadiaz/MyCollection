using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HW3.Models;
using System.IO;
using System.Net;
using Microsoft.Extensions.Configuration;
using HW3.DAL.Abstract;
using HW3.DAL.Concrete;

namespace HW3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

		private readonly IGitHubService _userRepository;

        private readonly IConfiguration _configuration;

        public 

        HomeController(ILogger<HomeController> logger, IGitHubService user, IConfiguration configuration)
        {
            _logger = logger;
			_userRepository = user;
            _configuration = configuration;
        }
		public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetRepositoriesList()
        {
            Debug.WriteLine("Getting the Repo!");
            _userRepository.SetCredentials("iluadiaz", _configuration["Token:ServiceApiKey"]);
            IEnumerable<GitHubRepository> repos = _userRepository.GetRepositories();
            return Json(repos);
        }

        [HttpGet]
        public IActionResult GetARepository(string _owner, string _repositoryName)
        {
            Debug.WriteLine("Getting the Repo!");
            _userRepository.SetCredentials("iluadiaz", _configuration["Token:ServiceApiKey"]);
            GitHubRepository repo = (GitHubRepository)_userRepository.GetRepository(_owner, _repositoryName);//new GitHubRepository();
            return Json(repo);
        }

        [HttpGet]
        public IActionResult GetAUser()
        {
            Debug.WriteLine("Getting the Repo!");
            _userRepository.SetCredentials("iluadiaz", _configuration["Token:ServiceApiKey"]);// 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
            GitHubUser user = _userRepository.GetUser();
            return Json(user);
        }

        [HttpGet]
        public IActionResult GetCommitList(string _owner, string _repositoryName)
        {
            Debug.WriteLine("Getting the Repo!");
            _userRepository.SetCredentials("iluadiaz", _configuration["Token:ServiceApiKey"]);
            List<GitHubCommit> commits = (List<GitHubCommit>)_userRepository.GetCommits(_owner, _repositoryName);
            return Json(commits);
        }
        [HttpGet]
        public IActionResult GetBranchList(string _owner, string _repositoryName)
        {
            Debug.WriteLine("Getting the Repo!");
            _userRepository.SetCredentials("iluadiaz", _configuration["Token:ServiceApiKey"]);
            List<GitHubBranch> branches = (List<GitHubBranch>)_userRepository.GetBranches(_owner, _repositoryName);
            return Json(branches);
        }
    }
}
