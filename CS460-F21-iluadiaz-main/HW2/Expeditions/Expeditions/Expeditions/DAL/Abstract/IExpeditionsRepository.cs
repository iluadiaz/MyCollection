using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Expeditions.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Expeditions.DAL.Abstract
{
    public interface IExpeditionsRepository : IRepository<Expedition>
    {
        public StatsViewModel GetExpeditionInfo();

        public CreateViewModel GetUniqueTerminations();

        public List<Expedition> Expeditions();

        public List<SelectListItem> LoadDropDownFor02();

        public List<SelectListItem> LoadDropDownForTerminations();
    }
}
