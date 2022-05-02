using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TFA.Models;
using TFA.DAL.Abstract;
using TFA.DAL.Concrete;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using FileHelpers;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
namespace TFA.Controllers
{
    public class TeamsController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly __TFADbContext ctx;
        private readonly IAthleteRepository _athleteRepo;
        private readonly IRaceResultRepository _timeRepo;
        private readonly ITeamRepository _teamRepository;

        public TeamsController(ILogger<HomeController> logger, __TFADbContext _ctx, ITeamRepository teamRepo)
        {
            ctx = _ctx;
            _logger = logger;
            _teamRepository = teamRepo;
        }

        [HttpGet]
        public IActionResult Index(string x)
        {
            TeamViewModel generateData = new TeamViewModel();

            generateData.teamList = _teamRepository.GetTeamsWithCoaches().ToList();

            if (x == null)
            {
                return View(generateData);
            }
            else
            {
                generateData.athleteList = _teamRepository.GetAthletesFor(x).ToList();
                generateData.coachPair = _teamRepository.GetTeamWithCoach(x);
                return View(generateData);
            } 
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
