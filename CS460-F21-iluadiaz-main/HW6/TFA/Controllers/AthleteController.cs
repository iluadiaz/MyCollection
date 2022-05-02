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
    public class AthleteController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly __TFADbContext ctx;
        private readonly IAthleteRepository _athleteRepo;

        

        public AthleteController(ILogger<HomeController> logger, __TFADbContext _ctx, IAthleteRepository athleteRepo,
                IRaceResultRepository timeRepo)
        {
            ctx = _ctx;
            _logger = logger;
            _athleteRepo = athleteRepo;

        }
        [HttpGet]
        public IActionResult full_name(string x)
        {
            AthleteViewModel generateData = new AthleteViewModel();

            if (x == null)
            {
                return View();
            }
            else
            {
                generateData.resultList = _athleteRepo.GetRaceResultsFor(x).ToList();
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
