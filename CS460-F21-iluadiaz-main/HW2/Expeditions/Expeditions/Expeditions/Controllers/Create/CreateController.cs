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
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Expeditions.Controllers
{
    public class CreateController : Controller
    {
        private readonly ILogger<CreateController> _logger;
        private readonly ExpeditionsDbContext _ctx;
        private readonly IPeakRepository _peakRepo;
        private readonly IExpeditionsRepository _expeditionsRepo;
        private readonly IAgencyRepository _agencyRepository;

        public CreateController(ILogger<CreateController> logger, ExpeditionsDbContext ctx, IPeakRepository peakRepo,
            IExpeditionsRepository expeditionsRepo, IAgencyRepository agencyRepository)
        {
            _logger = logger;
            _ctx = ctx;
            _peakRepo = peakRepo;
            _expeditionsRepo = expeditionsRepo;
            _agencyRepository = agencyRepository;
        }
        [HttpGet]
        public IActionResult Create()
        {
            CreateViewModel create = _expeditionsRepo.GetUniqueTerminations();

            create.agencies = _agencyRepository.GetAgencies();
            create.expeditions = _expeditionsRepo.Expeditions();
            create.peaks = _peakRepo.Peaks();
            //ist<SelectListItem> alist = LoadDropDown(create.peaks);
            create.peakDropDown = _peakRepo.LoadDropDown();
            create.agencyDropDown = _agencyRepository.LoadDropDown();
            create.o2DropDown = _expeditionsRepo.LoadDropDownFor02();

            create.terminationDropDown = _expeditionsRepo.LoadDropDownForTerminations();
            return View(create);
        }
        [HttpPost]
        public IActionResult Confirmation(CreateViewModel create)//submit an expedition!
        {
            CreateViewModel tempModel = _expeditionsRepo.GetUniqueTerminations();
            create.agencies = _agencyRepository.GetAgencies();
            create.termReasons = tempModel.termReasons;
            //create.expeditions = _expeditionsRepo.Expeditions();
            create.peaks = _peakRepo.Peaks();
            CreateViewModel model = create.PrepModelData(create, create.peaks, create.agencies);



            //_peakRepo.AddOrUpdate(model.peakToDB);
            //_agencyRepository.AddOrUpdate(model.agencyToDb);
            //create.peakDropDown = _peakRepo.LoadDropDown();
            _expeditionsRepo.AddOrUpdate(model.expeditionToDb);
            return View(create);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
