using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFA.Models;
namespace TFA.DAL.Abstract
{
    public interface ICoachRepository : IRepository<Coach>
    {
        public int lastId();
    }
}
