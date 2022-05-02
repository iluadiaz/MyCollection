using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Expeditions.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Expeditions.DAL.Abstract
{
    public interface IPeakRepository : IRepository<Peak> 
    {
        public StatsViewModel GetPeakInfo();

        public HomeViewModel GetPeaks();

        public List<Peak> Peaks();

        public List<SelectListItem> LoadDropDown();
    }
}
