using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Expeditions.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Expeditions.DAL.Abstract
{
    public interface IAgencyRepository : IRepository<TrekkingAgency>
    {
        public List<TrekkingAgency> GetAgencies();

        public List<SelectListItem> LoadDropDown();
    }
}
