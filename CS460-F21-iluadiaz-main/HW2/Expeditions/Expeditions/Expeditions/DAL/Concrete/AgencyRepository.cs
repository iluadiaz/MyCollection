using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Expeditions.DAL.Concrete;
using Expeditions.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Expeditions.DAL.Abstract
{
    public class AgencyRepository : Repository<TrekkingAgency>, IAgencyRepository
    {
        private ExpeditionsDbContext _ctx;
        public AgencyRepository(ExpeditionsDbContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }
        public List<TrekkingAgency> GetAgencies()
        {
            List<TrekkingAgency> agencies = _ctx.TrekkingAgencies.ToList();

            return agencies;
        }

        public List<SelectListItem> LoadDropDown()
        {
            List<SelectListItem> agencyList = new List<SelectListItem>();

            List<TrekkingAgency> agencies = GetAgencies();


            for (int i = 0; i < agencies.Count(); i++)
            {
                agencyList.Add(new SelectListItem
                {
                    Text = agencies[i].Name,
                    Value = (i + 1).ToString()
                });
            }

            return agencyList;
        }
    }
}
