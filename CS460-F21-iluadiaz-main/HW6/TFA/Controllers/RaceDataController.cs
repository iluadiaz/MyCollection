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
using System.Data;
using System.Data.SqlClient;

namespace TFA.Controllers
{
    [DelimitedRecord(",")]
    public class RaceDataController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly __TFADbContext ctx;
        private readonly IRepository<Athlete> _athleteRepo;
        private readonly IRepository<Coach> _coachRepo;
        private readonly IRepository<TrackEvent> _eventRepo;
        private readonly IRepository<RaceResult> _timeRepo;
        private readonly IRepository<Classification> _eventClassificationRepo;
        private readonly IRepository<Location> _MeetRepo;
        private readonly IRepository<Team> _teamRepository;

        public RaceDataController(ILogger<HomeController> logger,IHostingEnvironment hostingEnvironment, __TFADbContext _ctx, IRepository<Athlete> athleteRepo,
            IRepository<Coach> coachRepo, IRepository<TrackEvent> eventRepo, IRepository<RaceResult> timeRepo, IRepository<Classification> eventClassificationRepo,
            IRepository<Location> meetRepo, IRepository<Team> teamRepository)
        {
            ctx = _ctx; 
            _logger = logger;
            this.hostingEnvironment = hostingEnvironment;
            _athleteRepo = athleteRepo;
            _coachRepo = coachRepo;
            _eventRepo = eventRepo;
            _timeRepo = timeRepo;
            _eventClassificationRepo = eventClassificationRepo;
            _MeetRepo = meetRepo;
            _teamRepository = teamRepository;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Import()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Import(UploadModel data, TheFile aFile)
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
