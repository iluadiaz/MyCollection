using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Expeditions.Models;
using Expeditions.DAL.Abstract;
using Expeditions.DAL.Concrete;

namespace Expeditions.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ExpeditionsDbContext _ctx;
        private readonly IPeakRepository _peakRepo;
        private readonly IExpeditionsRepository _expeditionsRepo;

        public HomeController(ILogger<HomeController> logger, ExpeditionsDbContext ctx, IPeakRepository peakRepo,
            IExpeditionsRepository expeditionsRepo)
        {
            _logger = logger;
            _ctx = ctx;
            _peakRepo = peakRepo;
            _expeditionsRepo = expeditionsRepo;
        }

        public IActionResult Index()
        {
            HomeViewModel peaks = _peakRepo.GetPeaks();

            return View(peaks);
        }

        public IActionResult Stats()
        {
            StatsViewModel stats = new StatsViewModel();
            StatsViewModel stats2 = new StatsViewModel();
            stats  = _peakRepo.GetPeakInfo();
            stats2 = _expeditionsRepo.GetExpeditionInfo();

            stats.ExpeditionsCount = stats2.ExpeditionsCount;
            stats.o2Used = stats2.o2Used;
            stats.deathCount = stats2.deathCount;

            return View(stats);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
