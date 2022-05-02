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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
namespace TFA.Controllers
{
    [AllowAnonymous]
    [DelimitedRecord(",")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository<Athlete> _athleteRepository;
        private readonly IRepository<Coach> _coachRepository;
        private readonly IRepository<Classification> _eventClassification;
        private readonly IRepository<TrackEvent> _eventRepository;
        private readonly IRepository<Location> _meetRepository;
        private readonly IRepository<RaceResult> _timeRepository;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IRepository<Team> _teamRepository;
        public HomeController(ILogger<HomeController> logger, IRepository<Athlete> athleteRepository, IRepository<Coach> coachRepository,
            IRepository<Classification> eventClassification, IRepository<TrackEvent> eventRepository, IRepository<Location> meetRepository,
            IRepository<RaceResult> timeRepository, IHostingEnvironment hostingEnvironment, IRepository<Team> teamRepository)
        {
            _logger = logger;
            _athleteRepository = athleteRepository;
            _coachRepository = coachRepository;
            _eventClassification = eventClassification;
            _eventRepository = eventRepository;
            _meetRepository = meetRepository;
            _timeRepository = timeRepository;
            _teamRepository = teamRepository;
            this.hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
