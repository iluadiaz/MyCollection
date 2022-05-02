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
        private readonly IAthleteRepository _athleteRepo;
        private readonly ICoachRepository _coachRepo;
        private readonly ITrackEventRepository _eventRepo;
        private readonly IRaceResultRepository _timeRepo;
        private readonly IClassificationRepository _eventClassificationRepo;
        private readonly ILocationRepository _MeetRepo;
        private readonly ITeamRepository _teamRepository;

        public RaceDataController(ILogger<HomeController> logger,IHostingEnvironment hostingEnvironment, __TFADbContext _ctx, IAthleteRepository athleteRepo,
            ICoachRepository coachRepo, ITrackEventRepository eventRepo, IRaceResultRepository timeRepo, IClassificationRepository eventClassificationRepo,
            ILocationRepository meetRepo, ITeamRepository teamRepository)
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
        public IActionResult Import(UploadModel data, TheFile file)
        {
            UploadFile upload = new UploadFile();
            if (ModelState.IsValid)
            {
                upload.UploadData(file, _athleteRepo, _coachRepo, _eventClassificationRepo, _eventRepo, _MeetRepo, _timeRepo, _teamRepository, data,
                    hostingEnvironment, ctx);

                ViewBag.SuccessMessage = "Your form has been successfully uploaded! A total of " + file.successfulRecordCount + " successful records where uploaded. Additionally, there where " +
                                                        Environment.NewLine + file.negTimes + " negative times found, " +
                                                        Environment.NewLine + file.invalidEvent + " invalid or duplicate Event Catagorizations encountered, " +
                                                        Environment.NewLine + file.invalidCoach + " Invalid or duplicate Coaches encountered, " +
                                                        Environment.NewLine + file.invalidTeam + " Invalid or duplicate Teams encountered, " +
                                                        Environment.NewLine + "and " + file.invalidAthleticEvent + " Invalid or duplicate Athletic Events encountered.";
                ModelState.Clear();
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
