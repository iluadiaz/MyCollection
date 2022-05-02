using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using TFA.Models;

namespace TFA.DAL.Abstract
{
    public interface ILocationRepository : IRepository<Location>
    {
        public int lastId();
    }
}
