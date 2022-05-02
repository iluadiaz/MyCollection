using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Expeditions.DAL.Abstract;
using Expeditions.Models;
using Expeditions.DAL.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Collections;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Expeditions.DAL.Concrete
{
    public class PeakRepository : Repository<Peak>, IPeakRepository
    {
        private ExpeditionsDbContext _ctx;

        public PeakRepository(ExpeditionsDbContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }

        public StatsViewModel GetPeakInfo()
        {
            List<Peak> peaks = _ctx.Peaks.Include(a => a.Expeditions).ToList();
           
            StatsViewModel peakInfo = new StatsViewModel();

            peakInfo.climbedCount = peaks.Select(a => a.Id).Count();

            foreach (var x in peaks)
            {
                if (x.Height >= 8000)
                {
                    peakInfo.peaksOver8000++;
                }
                if (x.ClimbingStatus == false)
                {
                    peakInfo.notClimbedCount++;
                }
            }
            return peakInfo;
        }

        public HomeViewModel GetPeaks()
        {

            HomeViewModel sortedPeaks = new HomeViewModel();

            sortedPeaks.peaks = _ctx.Peaks.Include(a => a.Expeditions).OrderByDescending(a => a.Height).ToList();

            List<int> ranks = new List<int>();

            for(int i = 1; i < 16; i++)
            {
                sortedPeaks.rank.Add(i);
            }

            return sortedPeaks;
        }

        public List<Peak> Peaks()
        {
            List<Peak> peaks = _ctx.Peaks.ToList();

            return peaks;
        }

        public List<SelectListItem> LoadDropDown()
        {
            List<SelectListItem> peakList = new List<SelectListItem>();

            List<Peak> peaks = Peaks();

            for (int i = 0; i < peaks.Count(); i++)
            {
                peakList.Add(new SelectListItem
                {
                    Text = peaks[i].Name,
                    Value = (i + 1).ToString()
                }); 
            }

            return peakList;
        }
    }
}
