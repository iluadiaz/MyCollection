using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TFA.Models
{
    public class AthleteViewModel
    {
        string name = null;

        public IEnumerable<RaceResultDisplay> resultList = null;
    }
}
