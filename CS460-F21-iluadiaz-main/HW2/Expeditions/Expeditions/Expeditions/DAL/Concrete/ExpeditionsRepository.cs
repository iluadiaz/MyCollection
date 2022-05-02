using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Expeditions.DAL.Concrete;
using Expeditions.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Expeditions.DAL.Abstract
{
    public class ExpeditionsRepository : Repository<Expedition>, IExpeditionsRepository
    {
        private ExpeditionsDbContext _ctx;
        public ExpeditionsRepository(ExpeditionsDbContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }
        public StatsViewModel GetExpeditionInfo()
        {
            StatsViewModel peakInfo = new StatsViewModel();
            List<Expedition> expeditions = _ctx.Expeditions.ToList();

            peakInfo.ExpeditionsCount = expeditions.Count();

             foreach (var y in expeditions)
            {

                if (y.OxygenUsed == true)
                {
                    peakInfo.o2Used++;
                }

                if (y.TerminationReason == "Accident (death or serious injury)")
                    peakInfo.deathCount++;
            }

        peakInfo.deathCount = Math.Round((peakInfo.deathCount / peakInfo.ExpeditionsCount) * 100, 2);

        peakInfo.o2Used = Math.Round((peakInfo.o2Used / peakInfo.ExpeditionsCount) * 100, 2);

        return peakInfo;

        }

        public CreateViewModel GetUniqueTerminations()
        {
            CreateViewModel createViewModel = new CreateViewModel();

            List<Expedition> expeditions = _ctx.Expeditions.ToList();

            createViewModel.termReasons = expeditions.Select(a => a.TerminationReason).Distinct().ToList();

            return createViewModel;
        }

        public List<Expedition> Expeditions()
        {
            List<Expedition> expeditions = _ctx.Expeditions.ToList();
            
            return expeditions;
        }

        public List<SelectListItem> LoadDropDownFor02()
        {

            List<string> boolList = new List<string>();

            boolList.Add("yes");
            boolList.Add("no");

            List<SelectListItem> o2 = new List<SelectListItem>();

            for (int i = 0; i < 2; i++)
            {
                o2.Add(new SelectListItem
                {
                    Text = boolList[i],
                    Value = (i + 1).ToString()
                });
            }

            return o2;
        }

        public List<SelectListItem> LoadDropDownForTerminations()
        {
            CreateViewModel createViewModel = new CreateViewModel();

            createViewModel = GetUniqueTerminations();

            List<SelectListItem> terminations = new List<SelectListItem>();
            for (int i = 0; i < createViewModel.termReasons.Count(); i++)
            {
                terminations.Add(new SelectListItem
                {
                    Text = createViewModel.termReasons[i],
                    Value = (i + 1).ToString()
                });
            }

            return terminations;
        }


        //need method to pull the year
        //might have to make the before getting season since we must part the year out anyways. it is an int in the db
  }
}
